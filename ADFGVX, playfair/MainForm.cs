using Cryptography.Uc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptography
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnBtnHomophonicClick(object sender, EventArgs e)
        {
            var homophonicUc = new Homophonic_Uc
            {
                Dock = DockStyle.Fill
            };
            var f = new Form()
            {
                Text = "Homophonic",
                Size = new Size(600, 400),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            f.Controls.Add(homophonicUc);
            f.Show();
        }

        private void OnBtnADFGVXClick(object sender, EventArgs e)
        {
            var adfgvxUc = new ADFGVX_Uc
            {
                Dock = DockStyle.Fill
            };
            var f = new Form()
            {
                Text = "ADFGVX",
                Size = new Size(600, 400),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            f.Controls.Add(adfgvxUc);
            f.Show();
        }

        private void OnBtnPlayfairClick(object sender, EventArgs e)
        {
            var playFairUc = new PlayFair_Uc()
            {
                Dock = DockStyle.Fill
            };
            var f = new Form()
            {
                Text = "Playfair",
                Size = new Size(600, 400),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            f.Controls.Add(playFairUc);
            f.Show();
        }
    }
}
