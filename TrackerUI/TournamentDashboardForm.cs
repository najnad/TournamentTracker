using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();

        public TournamentDashboardForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        /// <summary>
        /// Loads tournaments into the drop down.
        /// </summary>
        private void WireUpLists()
        {
            loadExistingTournamentDropDown.DataSource = tournaments;
            loadExistingTournamentDropDown.DisplayMember = "TournamentName";
        }

        /// <summary>
        /// Launches CreateTournament form.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm frm = new CreateTournamentForm();
            frm.Show();
        }

        /// <summary>
        /// Launches TournamentViewer form.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel) loadExistingTournamentDropDown.SelectedItem;
            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
        }
    }
}
