namespace Cryptography.Uc
{
    partial class Homophonic_Uc
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
            this.labelHomoOutput = new System.Windows.Forms.Label();
            this.labelHomoInput = new System.Windows.Forms.Label();
            this.richTextBoxHomoOutput = new System.Windows.Forms.RichTextBox();
            this.richTextBoxHomoInput = new System.Windows.Forms.RichTextBox();
            this.buttonHomoEncrypt = new System.Windows.Forms.Button();
            this.buttonHomoDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHomoOutput
            // 
            this.labelHomoOutput.AutoSize = true;
            this.labelHomoOutput.Location = new System.Drawing.Point(16, 87);
            this.labelHomoOutput.Name = "labelHomoOutput";
            this.labelHomoOutput.Size = new System.Drawing.Size(39, 13);
            this.labelHomoOutput.TabIndex = 44;
            this.labelHomoOutput.Text = "Output";
            // 
            // labelHomoInput
            // 
            this.labelHomoInput.AutoSize = true;
            this.labelHomoInput.Location = new System.Drawing.Point(16, 12);
            this.labelHomoInput.Name = "labelHomoInput";
            this.labelHomoInput.Size = new System.Drawing.Size(31, 13);
            this.labelHomoInput.TabIndex = 43;
            this.labelHomoInput.Text = "Input";
            // 
            // richTextBoxHomoOutput
            // 
            this.richTextBoxHomoOutput.Location = new System.Drawing.Point(16, 103);
            this.richTextBoxHomoOutput.Name = "richTextBoxHomoOutput";
            this.richTextBoxHomoOutput.Size = new System.Drawing.Size(520, 67);
            this.richTextBoxHomoOutput.TabIndex = 42;
            this.richTextBoxHomoOutput.Text = "";
            // 
            // richTextBoxHomoInput
            // 
            this.richTextBoxHomoInput.Location = new System.Drawing.Point(16, 28);
            this.richTextBoxHomoInput.Name = "richTextBoxHomoInput";
            this.richTextBoxHomoInput.Size = new System.Drawing.Size(520, 56);
            this.richTextBoxHomoInput.TabIndex = 41;
            this.richTextBoxHomoInput.Text = "cryptography";
            // 
            // buttonHomoEncrypt
            // 
            this.buttonHomoEncrypt.Location = new System.Drawing.Point(16, 200);
            this.buttonHomoEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHomoEncrypt.Name = "buttonHomoEncrypt";
            this.buttonHomoEncrypt.Size = new System.Drawing.Size(77, 29);
            this.buttonHomoEncrypt.TabIndex = 40;
            this.buttonHomoEncrypt.Text = "Encrypt";
            this.buttonHomoEncrypt.UseVisualStyleBackColor = true;
            this.buttonHomoEncrypt.Click += new System.EventHandler(this.HomoEncrypt);
            // 
            // buttonHomoDecrypt
            // 
            this.buttonHomoDecrypt.Location = new System.Drawing.Point(462, 200);
            this.buttonHomoDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHomoDecrypt.Name = "buttonHomoDecrypt";
            this.buttonHomoDecrypt.Size = new System.Drawing.Size(74, 29);
            this.buttonHomoDecrypt.TabIndex = 39;
            this.buttonHomoDecrypt.Text = "Decrypt";
            this.buttonHomoDecrypt.UseVisualStyleBackColor = true;
            this.buttonHomoDecrypt.Click += new System.EventHandler(this.HomoDecrypt);
            // 
            // Homophonic_Uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelHomoOutput);
            this.Controls.Add(this.labelHomoInput);
            this.Controls.Add(this.richTextBoxHomoOutput);
            this.Controls.Add(this.richTextBoxHomoInput);
            this.Controls.Add(this.buttonHomoEncrypt);
            this.Controls.Add(this.buttonHomoDecrypt);
            this.Name = "Homophonic_Uc";
            this.Size = new System.Drawing.Size(575, 257);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHomoOutput;
        private System.Windows.Forms.Label labelHomoInput;
        private System.Windows.Forms.RichTextBox richTextBoxHomoOutput;
        private System.Windows.Forms.RichTextBox richTextBoxHomoInput;
        private System.Windows.Forms.Button buttonHomoEncrypt;
        private System.Windows.Forms.Button buttonHomoDecrypt;
    }
}
