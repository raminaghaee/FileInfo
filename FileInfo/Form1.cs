using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region DragForm & Style
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void TittelBar_MouseDown(object sender, MouseEventArgs e)
        {
            this.BringToFront();
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string path;
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    DateTime Create = File.GetCreationTime(path);
                    DateTime Write = File.GetLastWriteTime(path);
                    DateTime Access = File.GetLastAccessTime(path);
                    lblCreate.Text = Create.ToString();
                    lblWrite.Text = Write.ToString();
                    lblAccess.Text = Access.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
