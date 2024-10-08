using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

// WebPからPDFへの変換ツールのフォームクラス
namespace webp_to_pdf
{
    public partial class MainFrom : Form
    {
        // 選択されたファイルのリスト
        private List<string> selectedFiles = new List<string>();

        // コンストラクタ
        public MainFrom()
        {
            // UIコンポーネントの初期化
            InitializeComponent();
            // ボタンのクリックイベントにメソッドを登録
            btnSelectFiles.Click += BtnSelectFiles_Click;
            btnConvert.Click += BtnConvert_Click;
        }

        // WebPファイル選択ボタンのクリックイベント
        private void BtnSelectFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // ファイルフィルタを設定
                openFileDialog.Filter = "WebP files (*.webp)|*.webp";
                openFileDialog.Multiselect = true; // 複数選択を許可

                // ダイアログを表示し、選択された場合
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFiles.Clear(); // 以前の選択をクリア
                    selectedFiles.AddRange(openFileDialog.FileNames); // 新しいファイルを追加
                    UpdateFileList(); // ファイルリストを更新
                }
            }
        }

        // 選択されたファイルのリストを更新するメソッド
        private void UpdateFileList()
        {
            lstSelectedFiles.Items.Clear(); // リストをクリア
            foreach (string file in selectedFiles)
            {
                // ファイル名をリストに追加
                lstSelectedFiles.Items.Add(Path.GetFileName(file));
            }
        }

        // PDF変換ボタンのクリックイベント
        private async void BtnConvert_Click(object sender, EventArgs e)
        {
            // ファイルが選択されていない場合のエラーメッセージ
            if (selectedFiles.Count == 0)
            {
                MessageBox.Show("WebPファイルを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // 保存するPDFファイルのフィルタを設定
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = "convert.pdf"; // デフォルトのファイル名

                // ダイアログを表示し、選択された場合
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // WebPからPDFへ変換
                        await ConvertWebPToPdfAsync(selectedFiles, saveFileDialog.FileName);
                        MessageBox.Show("変換が完了しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // エラーメッセージを表示
                        MessageBox.Show($"変換中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // WebPファイルをPDFに変換する非同期メソッド
        private async Task ConvertWebPToPdfAsync(List<string> webpFiles, string outputPath)
        {
            using (PdfDocument document = new PdfDocument())
            {
                for (int i = 0; i < webpFiles.Count; i++)
                {
                    string webpFile = webpFiles[i];
                    PdfPage page = document.AddPage(); // 新しいページを追加
                    XGraphics gfx = XGraphics.FromPdfPage(page); // ページに描画するためのオブジェクトを取得

                    using (SixLabors.ImageSharp.Image image = await SixLabors.ImageSharp.Image.LoadAsync(webpFile)) // WebP画像を非同期で読み込み
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            await image.SaveAsPngAsync(ms); // PNG形式でメモリストリームに保存
                            ms.Position = 0; // ストリームの位置をリセット
                            XImage xImage = XImage.FromStream(ms); // ストリームから画像を作成

                            // 画像をページに合わせてスケーリング
                            double scale = Math.Min(page.Width / xImage.PixelWidth, page.Height / xImage.PixelHeight);
                            double width = xImage.PixelWidth * scale;
                            double height = xImage.PixelHeight * scale;

                            // 画像をページの中央に描画
                            gfx.DrawImage(xImage, (page.Width - width) / 2, (page.Height - height) / 2, width, height);
                        }
                    }

                    // 進捗状況の更新
                    int progress = (i + 1) * 100 / webpFiles.Count;
                    UpdateProgress(progress); // 進捗を更新
                }

                document.Save(outputPath); // PDFファイルを保存
            }
        }

        // 進捗状況を更新するメソッド
        private void UpdateProgress(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateProgress), value); // スレッド間での呼び出し
                return;
            }

            progressBar.Value = value; // プログレスバーの値を更新
        }
    }
}
