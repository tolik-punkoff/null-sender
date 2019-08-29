using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chaos_Software
{
    public partial class frmDSun : Form
    {
        int i = 0;
        public frmDSun()
        {
            InitializeComponent();
        }

        private void tmrShow_Tick(object sender, EventArgs e)
        {
            i++;
            if (i >= 5) this.Hide();
        }
    }
}