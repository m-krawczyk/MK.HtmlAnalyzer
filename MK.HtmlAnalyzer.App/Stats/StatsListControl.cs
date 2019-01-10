using MK.HtmlAnalyzer.AppLogic.Interfaces.Stats;
using MK.HtmlAnalyzer.AppLogic.Presenters.Stats;
using MK.HtmlAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
