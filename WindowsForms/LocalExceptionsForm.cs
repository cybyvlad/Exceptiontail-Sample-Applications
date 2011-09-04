using System;
using System.ComponentModel;
using System.Windows.Forms;

using ExceptionTail;

namespace BuggyApp
{
    public partial class LocalExceptionsForm : Form
    {
        public LocalExceptionsForm()
        {
            InitializeComponent();
        }

        private void LocalExceptionsForm_Load(object sender, EventArgs e)
        {
            UpdateSendAllBtnState();
            eTExceptionBindingSource.DataSource = ET.GetExceptions();
        }

        private void UpdateSendAllBtnState()
        {
            btnSendAll.Enabled = ETSettings.SendMode == ESendMode.OnDemand;
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            btnSendAll.Enabled = false;
            bwSend.RunWorkerAsync();
        }

        private void bwSend_DoWork(object sender, DoWorkEventArgs e)
        {
            var etExceptions = ET.GetExceptions();
            ET.SendExceptions(etExceptions);
        }

        private void bwSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateSendAllBtnState();
        }
    }
}