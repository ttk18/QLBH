using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace CommonlibHCE
{
    public partial class FrmPrintreview : DevExpress.XtraEditors.XtraForm
    {
        public FrmPrintreview()
        {
            InitializeComponent();
        }

        private void FrmPrintreview_Load(object sender, EventArgs e)
        {
            crv.ReportSource = lcrpDoc;
        }

        private ReportDocument lcrpDoc;

        public ReportDocument ReportDoc
        {
            get { return this.lcrpDoc; }
            set { this.ReportDoc = value; }

        }
    }
}