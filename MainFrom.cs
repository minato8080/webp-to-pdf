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
        private int selectedSizeOption = 0; // デフォルトで画像に合わせるオプション

        // コンストラクタ
        public MainFrom()
        {
            // UIコンポーネントの初期化
            InitializeComponent();
            // ボタンのクリックイベントにメソッドを登録
            btnSelectFiles.Click += BtnSelectFiles_Click;
            btnConvert.Click += BtnConvert_Click;
            
            // 新しいイベントハンドラを追加
            btnMoveUp.Click += BtnMoveUp_Click;
            btnMoveDown.Click += BtnMoveDown_Click;
            btnClearFiles.Click += BtnClearFiles_Click;
            radioButtonImageSize.CheckedChanged += RadioButtonSizeOption_CheckedChanged;
            radioButtonA4Portrait.CheckedChanged += RadioButtonSizeOption_CheckedChanged;
            radioButtonA4Landscape.CheckedChanged += RadioButtonSizeOption_CheckedChanged;
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

        // ファイルを上に移動
        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(-1);
        }

        // ファイルを下に移動
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(1);
        }

        // 選択されたアイテムを移動
        private void MoveSelectedItem(int direction)
        {
            if (lstSelectedFiles.SelectedIndex == -1 || lstSelectedFiles.Items.Count == 0) return;

            int newIndex = lstSelectedFiles.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= lstSelectedFiles.Items.Count) return;

            var selectedIndex = lstSelectedFiles.SelectedIndex;
            var item = lstSelectedFiles.SelectedItem;
            var file = selectedFiles[selectedIndex];

            lstSelectedFiles.Items.RemoveAt(selectedIndex);
            selectedFiles.RemoveAt(selectedIndex);

            lstSelectedFiles.Items.Insert(newIndex, item);
            selectedFiles.Insert(newIndex, file);

            lstSelectedFiles.SelectedIndex = newIndex;
        }

        // 選択したファイルをクリア
        private void BtnClearFiles_Click(object sender, EventArgs e)
        {
            selectedFiles.Clear();
            lstSelectedFiles.Items.Clear();
        }

        // PDFサイズオプションの変更
        private void RadioButtonSizeOption_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonImageSize.Checked)
            {
                selectedSizeOption = 0;
            }
            else if (radioButtonA4Portrait.Checked)
            {
                selectedSizeOption = 1;
            }
            else if (radioButtonA4Landscape.Checked)
            {
                selectedSizeOption = 2;
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
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    using (SixLabors.ImageSharp.Image image = await SixLabors.ImageSharp.Image.LoadAsync(webpFile))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            await image.SaveAsPngAsync(ms);
                            ms.Position = 0;
                            XImage xImage = XImage.FromStream(ms);

                            if (selectedSizeOption == 0)
                            {
                                // ページ単位サイズモード
                                page.Width = xImage.PixelWidth;
                                page.Height = xImage.PixelHeight;
                                gfx.DrawImage(xImage, 0, 0, xImage.PixelWidth, xImage.PixelHeight);
                            }
                            else if (selectedSizeOption == 1)
                            {
                                // A4縦向きモード
                                page.Width = XUnit.FromMillimeter(210); // A4横向きの幅
                                page.Height = XUnit.FromMillimeter(297); // A4横向きの高さ
                                double scale = Math.Min(page.Width / xImage.PixelWidth, page.Height / xImage.PixelHeight);
                                double width = xImage.PixelWidth * scale;
                                double height = xImage.PixelHeight * scale;
                                gfx.DrawImage(xImage, (page.Width - width) / 2, (page.Height - height) / 2, width, height);
                            }
                            else if (selectedSizeOption == 2)
                            {
                                // A4横向きモード
                                page.Width = XUnit.FromMillimeter(297); // A4横向きの幅
                                page.Height = XUnit.FromMillimeter(210); // A4横向きの高さ
                                double scale = Math.Min(page.Width / xImage.PixelWidth, page.Height / xImage.PixelHeight);
                                double width = xImage.PixelWidth * scale;
                                double height = xImage.PixelHeight * scale;
                                gfx.DrawImage(xImage, (page.Width - width) / 2, (page.Height - height) / 2, width, height);
                            }
                        }
                    }

                    int progress = (i + 1) * 100 / webpFiles.Count;
                    UpdateProgress(progress);
                }

                document.Save(outputPath);
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
