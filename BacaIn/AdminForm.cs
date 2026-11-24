using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BacaIn.Models;

namespace BacaIn
{
    public partial class AdminForm : Form
    {
        public bool LoggingOut { get; private set; } = false;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void manageStudents_OpenLoansRequested(object? sender, User user)
        {
            manageLoansReturns.BringToFront();
            manageLoansReturns.ShowLoansForUser(user);
            SetActiveSidebarItem(sbLoansReturns);
        }

        public AdminForm(User currentUser) : this()
        {
            label5.Text = string.IsNullOrWhiteSpace(currentUser.DisplayName)
                ? currentUser.Username
                : currentUser.DisplayName;
        }

        public void sbBooks_Click(object sender, EventArgs e)
        {
            manageBooks.BringToFront();
            SetActiveSidebarItem(sbBooks);
        }

        private void sbLoansReturns_Click(object sender, EventArgs e)
        {
            manageLoansReturns.BringToFront();
            manageLoansReturns.ShowSelectUser();
            SetActiveSidebarItem(sbLoansReturns);
        }

        private void sbStudents_Click(object sender, EventArgs e)
        {
            manageStudents.BringToFront();
            manageStudents.LoadStudents();
            SetActiveSidebarItem(sbStudents);
        }

        private void sbReports_Click(object sender, EventArgs e)
        {
            viewReports.BringToFront();
            viewReports.LoadReport();
            SetActiveSidebarItem(sbReports);
        }

        private void SetActiveSidebarItem(TableLayoutPanel item)
        {
            TableLayoutPanel[] sidebarItems = [sbBooks, sbLoansReturns, sbReports, sbStudents];

            foreach (var sidebarItem in sidebarItems)
            {
                if (sidebarItem != item)
                {
                    sidebarItem.BackColor = SystemColors.ControlLight;
                    sidebarItem.Cursor = Cursors.Hand;
                }
            }

            item.BackColor = Color.FromArgb(117, 194, 59);
            item.Cursor = Cursors.Default;
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                LoggingOut = true;
                Close();
            }
        }
    }
}
