using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Chaos_Software
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //показываем Черное Солнце, начальную заставку
            frmDSun fDSun = new frmDSun();
            fDSun.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtInNull.Text.Trim().Length == 0)
            {
                CommonFunction.ErrMessage("Ты ничего не ввел");
            }
            else
            {
                lstInNull.Items.Add(txtInNull.Text);
                txtInNull.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstInNull.Items.Count == 0) return;
            if (lstInNull.SelectedIndex == -1) return;
            lstInNull.Items.Remove(lstInNull.SelectedItem);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chaos Software v 0.0.1 (L) Hex_Laden, 2012 Dancing Star Image By Paperdaemon (www.paperdaemon.tk)","О программе",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\Help.txt"))
            {
                CommonFunction.ErrMessage("Иерархическая система украла файл помощи! Обратитесь к ближайшей зондеркоманде Хаогнозиса!");
            }
            else CommonFunction.OpenToView(Application.StartupPath + "\\Help.txt");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (lstInNull.Items.Count == 0)
            {
                CommonFunction.ErrMessage("Ты ничего не указал!");
                return;
            }
            Random r = new Random();
            string st = "";
            for (int i = 0; i < lstInNull.Items.Count; i++)
            {
                st = st + " " + lstInNull.Items[i];
            }
            st = st + "(Хаос-компонента " + r.Next().ToString() + ")";
            try
            {

                FileStream fs = CommonFunction.OpenNul();
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(st);
                sw.Close();
                fs.Close();
            }
            catch
            {
                CommonFunction.ErrMessage("Технически отправить не удалось. Но Ты все сделал правильно!");
            }
            frmDancingStar fDS = new frmDancingStar();
            fDS.ShowDialog();
            MessageBox.Show("У Тебя все получилось! Да будет Хаос!","Все отлично",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}