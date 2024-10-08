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
            
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(150, 30);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "WebPファイルを選択";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            
            // 
            // lstSelectedFiles
            // 
            this.lstSelectedFiles.FormattingEnabled = true;
            this.lstSelectedFiles.ItemHeight = 15;
            this.lstSelectedFiles.Location = new System.Drawing.Point(12, 48);
            this.lstSelectedFiles.Name = "lstSelectedFiles";
            this.lstSelectedFiles.Size = new System.Drawing.Size(776, 304);
            this.lstSelectedFiles.TabIndex = 1;
            
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 358);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(150, 30);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "PDFに変換";
            this.btnConvert.UseVisualStyleBackColor = true;
            
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 394);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 23);
            this.progressBar.TabIndex = 3;
            
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
            this.Name = "MainFrom";
            this.Text = "WebP to PDF 変換ツール";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnSelectFiles; // WebPファイル選択ボタン
        private System.Windows.Forms.ListBox lstSelectedFiles; // 選択されたファイル一覧表示領域
        private System.Windows.Forms.Button btnConvert; // PDF変換実行ボタン
        private System.Windows.Forms.ProgressBar progressBar; // 進捗状況表示バー
    }
}

