using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MK.HtmlAnalyzer.AppLogic;
using MK.HtmlAnalyzer.Model;
using MK.HtmlAnalyzer.AppLogic.Presenters.Stats;
using MK.HtmlAnalyzer.AppLogic.Interfaces.Stats;

namespace MK.HtmlAnalyzer.App.Stats
{
    public partial class StatsListControl : UserControl, IStatsListView
    {
        StatsListPresenter presenter = new StatsListPresenter();

        public StatsListControl()
        {
            InitializeComponent();

            presenter.Initialize(this);
        }

        public IList<KeywordStat> Stats
        {
            set
            {
                statsBindingSource.DataSource = value;
                statsBindingSource.ResetBindings(false);
            }
        }

        public string Url
        {
            get { return txtUrl.Text; }
        }

        public string Info
        {
            set => lblInfo.Text = value;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            presenter.Initialize(this);
        }
    }
}
