using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BacaIn
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        public void tLPBooks_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Mouse Clicked");
        }
    }
}
