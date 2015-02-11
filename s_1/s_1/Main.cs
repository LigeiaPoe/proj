using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace s_1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            HideAllMenu();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config.DatabaseFile = f.FileName;
                toolStripStatusLabel1.Text = config.DataSource;
                if (TestConnection())
                    RevealAllMenu();
                else
                    HideAllMenu();
            }
        }

        void RevealAllMenu()
        {
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                toolStrip1.Items[i].Visible = true;
            }
        }

        void HideAllMenu()
        {
            for (int i = 1; i < toolStrip1.Items.Count; i++)
            {
                toolStrip1.Items[i].Visible = false;
            }
        }

        bool TestConnection()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))
                {
                    conn.Open();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
