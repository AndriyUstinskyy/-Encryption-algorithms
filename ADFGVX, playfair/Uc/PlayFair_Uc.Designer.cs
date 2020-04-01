namespace Cryptography.Uc
{
    partial class PlayFair_Uc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayFair_Uc));
            this.labelPlayFairOutput = new System.Windows.Forms.Label();
            this.labelPlayFairInput = new System.Windows.Forms.Label();
            this.textBoxPlayFairkey = new System.Windows.Forms.TextBox();
            this.labelkey = new System.Windows.Forms.Label();
            this.textBoxPlayFairOutput = new System.Windows.Forms.RichTextBox();
            this.textBoxPlayFairInput = new System.Windows.Forms.RichTextBox();
            this.btnPlayFairEncrypt = new System.Windows.Forms.Button();
            this.buttonPlayFairDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPlayFairOutput
            // 
            this.labelPlayFairOutput.AutoSize = true;
            this.labelPlayFairOutput.Location = new System.Drawing.Point(12, 147);
            this.labelPlayFairOutput.Name = "labelPlayFairOutput";
            this.labelPlayFairOutput.Size = new System.Drawing.Size(39, 13);
            this.labelPlayFairOutput.TabIndex = 42;
            this.labelPlayFairOutput.Text = "Output";
            // 
            // labelPlayFairInput
            // 
            this.labelPlayFairInput.AutoSize = true;
            this.labelPlayFairInput.Location = new System.Drawing.Point(12, 46);
            this.labelPlayFairInput.Name = "labelPlayFairInput";
            this.labelPlayFairInput.Size = new System.Drawing.Size(31, 13);
            this.labelPlayFairInput.TabIndex = 41;
            this.labelPlayFairInput.Text = "Input";
            // 
            // textBoxPlayFairkey
            // 
            this.textBoxPlayFairkey.Location = new System.Drawing.Point(52, 13);
            this.textBoxPlayFairkey.Name = "textBoxPlayFairkey";
            this.textBoxPlayFairkey.Size = new System.Drawing.Size(190, 20);
            this.textBoxPlayFairkey.TabIndex = 40;
            this.textBoxPlayFairkey.Text = "First Amendment";
            // 
            // labelkey
            // 
            this.labelkey.AutoSize = true;
            this.labelkey.Location = new System.Drawing.Point(12, 16);
            this.labelkey.Name = "labelkey";
            this.labelkey.Size = new System.Drawing.Size(25, 13);
            this.labelkey.TabIndex = 39;
            this.labelkey.Text = "Key";
            // 
            // textBoxPlayFairOutput
            // 
            this.textBoxPlayFairOutput.Location = new System.Drawing.Point(15, 163);
            this.textBoxPlayFairOutput.Name = "textBoxPlayFairOutput";
            this.textBoxPlayFairOutput.Size = new System.Drawing.Size(524, 74);
            this.textBoxPlayFairOutput.TabIndex = 38;
            this.textBoxPlayFairOutput.Text = "";
            // 
            // textBoxPlayFairInput
            // 
            this.textBoxPlayFairInput.Location = new System.Drawing.Point(12, 62);
            this.textBoxPlayFairInput.Name = "textBoxPlayFairInput";
            this.textBoxPlayFairInput.Size = new System.Drawing.Size(527, 73);
            this.textBoxPlayFairInput.TabIndex = 37;
            this.textBoxPlayFairInput.Text = resources.GetString("textBoxPlayFairInput.Text");
            // 
            // btnPlayFairEncrypt
            // 
            this.btnPlayFairEncrypt.Location = new System.Drawing.Point(15, 252);
            this.btnPlayFairEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlayFairEncrypt.Name = "btnPlayFairEncrypt";
            this.btnPlayFairEncrypt.Size = new System.Drawing.Size(74, 30);
            this.btnPlayFairEncrypt.TabIndex = 36;
            this.btnPlayFairEncrypt.Text = "Encrypt";
            this.btnPlayFairEncrypt.UseVisualStyleBackColor = true;
            this.btnPlayFairEncrypt.Click += new System.EventHandler(this.PlayFairEncryptClick);
            // 
            // buttonPlayFairDecrypt
            // 
            this.buttonPlayFairDecrypt.Location = new System.Drawing.Point(465, 252);
            this.buttonPlayFairDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlayFairDecrypt.Name = "buttonPlayFairDecrypt";
            this.buttonPlayFairDecrypt.Size = new System.Drawing.Size(74, 30);
            this.buttonPlayFairDecrypt.TabIndex = 35;
            this.buttonPlayFairDecrypt.Text = "Decrypt";
            this.buttonPlayFairDecrypt.UseVisualStyleBackColor = true;
            this.buttonPlayFairDecrypt.Click += new System.EventHandler(this.PlayFairDecryptClick);
            // 
            // PlayFair_Uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPlayFairOutput);
            this.Controls.Add(this.labelPlayFairInput);
            this.Controls.Add(this.textBoxPlayFairkey);
            this.Controls.Add(this.labelkey);
            this.Controls.Add(this.textBoxPlayFairOutput);
            this.Controls.Add(this.textBoxPlayFairInput);
            this.Controls.Add(this.btnPlayFairEncrypt);
            this.Controls.Add(this.buttonPlayFairDecrypt);
            this.Name = "PlayFair_Uc";
            this.Size = new System.Drawing.Size(569, 347);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayFairOutput;
        private System.Windows.Forms.Label labelPlayFairInput;
        private System.Windows.Forms.TextBox textBoxPlayFairkey;
        private System.Windows.Forms.Label labelkey;
        private System.Windows.Forms.RichTextBox textBoxPlayFairOutput;
        private System.Windows.Forms.RichTextBox textBoxPlayFairInput;
        private System.Windows.Forms.Button btnPlayFairEncrypt;
        private System.Windows.Forms.Button buttonPlayFairDecrypt;
    }
}
