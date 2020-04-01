namespace Cryptography
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlayfair = new System.Windows.Forms.Button();
            this.btnHomophonic = new System.Windows.Forms.Button();
            this.btnADFGVX = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlayfair
            // 
            this.btnPlayfair.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayfair.Location = new System.Drawing.Point(73, 25);
            this.btnPlayfair.Name = "btnPlayfair";
            this.btnPlayfair.Size = new System.Drawing.Size(151, 98);
            this.btnPlayfair.TabIndex = 0;
            this.btnPlayfair.Text = "Playfair";
            this.btnPlayfair.UseVisualStyleBackColor = true;
            this.btnPlayfair.Click += new System.EventHandler(this.OnBtnPlayfairClick);
            // 
            // btnHomophonic
            // 
            this.btnHomophonic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomophonic.Location = new System.Drawing.Point(73, 129);
            this.btnHomophonic.Name = "btnHomophonic";
            this.btnHomophonic.Size = new System.Drawing.Size(151, 98);
            this.btnHomophonic.TabIndex = 1;
            this.btnHomophonic.Text = "Homophonic";
            this.btnHomophonic.UseVisualStyleBackColor = true;
            this.btnHomophonic.Click += new System.EventHandler(this.OnBtnHomophonicClick);
            // 
            // btnADFGVX
            // 
            this.btnADFGVX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADFGVX.Location = new System.Drawing.Point(73, 233);
            this.btnADFGVX.Name = "btnADFGVX";
            this.btnADFGVX.Size = new System.Drawing.Size(151, 98);
            this.btnADFGVX.TabIndex = 2;
            this.btnADFGVX.Text = "ADFGVX";
            this.btnADFGVX.UseVisualStyleBackColor = true;
            this.btnADFGVX.Click += new System.EventHandler(this.OnBtnADFGVXClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 370);
            this.Controls.Add(this.btnADFGVX);
            this.Controls.Add(this.btnHomophonic);
            this.Controls.Add(this.btnPlayfair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayfair;
        private System.Windows.Forms.Button btnHomophonic;
        private System.Windows.Forms.Button btnADFGVX;
    }
}