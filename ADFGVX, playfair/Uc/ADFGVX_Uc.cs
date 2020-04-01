using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptography.Uc
{
    public partial class ADFGVX_Uc : UserControl
    {
        private enum EncodeMode
        {
            Encrypt = 1,
            Decrypt = 2
        };
        public ADFGVX_Uc()
        {
            InitializeComponent();
        }

       
        private bool ValidateInputs(EncodeMode? encodeMode)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Introduceti cheile!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (encodeMode != null && encodeMode == EncodeMode.Encrypt)
            {
                if (string.IsNullOrEmpty(richTextBox1.Text))
                {
                    MessageBox.Show("Introduceti textul pe care doriti sa il criptati!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(richTextBox1.Text))
                {
                    MessageBox.Show("Introduceti mesajul criptat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!Cryptography.Extensions.Extensions.TextContainsOnlyAllowedChars(richTextBox1.Text))
                {
                    MessageBox.Show("Mesajul criptat introdus contine caractere nepermise!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void ADFGVXEncrypt(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs(EncodeMode.Encrypt))
                {
                    var encoder = new ADFGVX(textBox4.Text, textBox3.Text);
                    richTextBox2.Text = encoder.Encrypt(richTextBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ADFGVXDecrypt(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs(EncodeMode.Decrypt))
                {
                    var encoder = new ADFGVX(textBox4.Text, textBox3.Text.ToUpper());
                    richTextBox2.Text = encoder.Decrypt(richTextBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
