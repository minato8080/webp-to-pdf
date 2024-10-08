namespace webp_to_pdf
{
    partial class MainFrom
    {
        /// <summary>
        ///  必要なデザイナ変数。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  使用中のリソースをクリーンアップします。
        /// </summary>
        /// <param name="disposing">管理リソースを解放する場合はtrue、それ以外はfalse。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  デザイナサポートのために必要なメソッドです - コードエディタで内容を変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectFiles = new System.Windows.Forms.Button(); // WebPファイル選択ボタン
            this.lstSelectedFiles = new System.Windows.Forms.ListBox(); // 選択されたファイル一覧表示領域
            this.btnConvert = new System.Windows.Forms.Button(); // PDF変換実行ボタン
            this.progressBar = new System.Windows.Forms.ProgressBar(); // 進捗状況表示バー
            this.btnClearFiles = new System.Windows.Forms.Button(); // 選択したファイルをクリアするボタン
            this.btnMoveUp = new System.Windows.Forms.Button(); // 選択したファイルの並び順を上に移動するボタン
            this.btnMoveDown = new System.Windows.Forms.Button(); // 選択したファイルの並び順を下に移動するボタン
            this.groupBoxSizeOption = new System.Windows.Forms.GroupBox(); // PDFファイルサイズオプション
            this.radioButtonImageSize = new System.Windows.Forms.RadioButton(); // 画像に合わせるラジオボタン
            this.radioButtonA4Portrait = new System.Windows.Forms.RadioButton(); // A4縦向きラジオボタン
            this.radioButtonA4Landscape = new System.Windows.Forms.RadioButton(); // A4横向きラジオボタン
            
            // 
            // lstSelectedFiles
            // 
            this.lstSelectedFiles.FormattingEnabled = true;
            this.lstSelectedFiles.ItemHeight = 15;
            this.lstSelectedFiles.Location = new System.Drawing.Point(12, 48);
            this.lstSelectedFiles.Name = "lstSelectedFiles";
            this.lstSelectedFiles.Size = new System.Drawing.Size(776, 204);
            this.lstSelectedFiles.TabIndex = 1;
            
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(150, 30);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "WebPファイルを追加";
            this.btnSelectFiles.UseVisualStyleBackColor = true;

            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 358);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(150, 30);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "PDFに変換";
            this.btnConvert.UseVisualStyleBackColor = true;

            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 394);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 23);
            this.progressBar.TabIndex = 3;

            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Location = new System.Drawing.Point(168, 12);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(150, 30);
            this.btnClearFiles.TabIndex = 4;
            this.btnClearFiles.Text = "選択をクリア";
            this.btnClearFiles.UseVisualStyleBackColor = true;

            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(330, 12);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 30);
            this.btnMoveUp.TabIndex = 5;
            this.btnMoveUp.Text = "上へ移動";
            this.btnMoveUp.UseVisualStyleBackColor = true;

            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(417, 12);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 30);
            this.btnMoveDown.TabIndex = 6;
            this.btnMoveDown.Text = "下へ移動";
            this.btnMoveDown.UseVisualStyleBackColor = true;

            // 
            // groupBoxSizeOption
            // 
            this.groupBoxSizeOption.Location = new System.Drawing.Point(12, 258);
            this.groupBoxSizeOption.Name = "groupBoxSizeOption";
            this.groupBoxSizeOption.Size = new System.Drawing.Size(776, 80);
            this.groupBoxSizeOption.TabIndex = 7;
            this.groupBoxSizeOption.TabStop = false;
            this.groupBoxSizeOption.Text = "PDF変換オプション";

            // 
            // radioButtonImageSize
            // 
            this.radioButtonImageSize.AutoSize = true;
            this.radioButtonImageSize.Location = new System.Drawing.Point(6, 22);
            this.radioButtonImageSize.Name = "radioButtonImageSize";
            this.radioButtonImageSize.Size = new System.Drawing.Size(100, 19);
            this.radioButtonImageSize.TabIndex = 8;
            this.radioButtonImageSize.TabStop = true;
            this.radioButtonImageSize.Text = "画像に合わせる";
            this.radioButtonImageSize.UseVisualStyleBackColor = true;
            this.radioButtonImageSize.Checked = true;

            // 
            // radioButtonA4Portrait
            // 
            this.radioButtonA4Portrait.AutoSize = true;
            this.radioButtonA4Portrait.Location = new System.Drawing.Point(6, 47);
            this.radioButtonA4Portrait.Name = "radioButtonA4Portrait";
            this.radioButtonA4Portrait.Size = new System.Drawing.Size(100, 19);
            this.radioButtonA4Portrait.TabIndex = 9;
            this.radioButtonA4Portrait.TabStop = true;
            this.radioButtonA4Portrait.Text = "A4縦向き";
            this.radioButtonA4Portrait.UseVisualStyleBackColor = true;

            // 
            // radioButtonA4Landscape
            // 
            this.radioButtonA4Landscape.AutoSize = true;
            this.radioButtonA4Landscape.Location = new System.Drawing.Point(112, 47);
            this.radioButtonA4Landscape.Name = "radioButtonA4Landscape";
            this.radioButtonA4Landscape.Size = new System.Drawing.Size(100, 19);
            this.radioButtonA4Landscape.TabIndex = 10;
            this.radioButtonA4Landscape.TabStop = true;
            this.radioButtonA4Landscape.Text = "A4横向き";
            this.radioButtonA4Landscape.UseVisualStyleBackColor = true;

            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 429);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lstSelectedFiles);
            this.Controls.Add(this.btnSelectFiles);
            this.Controls.Add(this.btnClearFiles);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.groupBoxSizeOption);
            this.groupBoxSizeOption.Controls.Add(this.radioButtonImageSize);
            this.groupBoxSizeOption.Controls.Add(this.radioButtonA4Portrait);
            this.groupBoxSizeOption.Controls.Add(this.radioButtonA4Landscape);
            this.Name = "MainFrom";
            this.Text = "WebP to PDF 変換ツール";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSelectFiles; // WebPファイル選択ボタン
        private System.Windows.Forms.ListBox lstSelectedFiles; // 選択されたファイル一覧表示領域
        private System.Windows.Forms.Button btnConvert; // PDF変換実行ボタン
        private System.Windows.Forms.ProgressBar progressBar; // 進捗状況表示バー
        private System.Windows.Forms.Button btnClearFiles; // 選択したファイルをクリアするボタン
        private System.Windows.Forms.Button btnMoveUp; // 選択したファイルの並び順を上に移動するボタン
        private System.Windows.Forms.Button btnMoveDown; // 選択したファイルの並び順を下に移動するボタン
        private System.Windows.Forms.GroupBox groupBoxSizeOption; // PDFファイルサイズオプション
        private System.Windows.Forms.RadioButton radioButtonImageSize; // 画像に合わせるラジオボタン
        private System.Windows.Forms.RadioButton radioButtonA4Portrait; // A4縦向きラジオボタン
        private System.Windows.Forms.RadioButton radioButtonA4Landscape; // A4横向きラジオボタン
    }
}

