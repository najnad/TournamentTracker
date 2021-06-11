using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> matchupsInRound = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            WireUpLists();

            LoadFormData();
            LoadRounds();
        }

        /// <summary>
        /// Loads tournament name into the form.
        /// </summary>
        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        /// <summary>
        /// Assigns data sources for dropdown and list box.
        /// </summary>
        private void WireUpLists()
        {
            roundDropDown.DataSource = rounds;
            matchupListBox.DataSource = matchupsInRound;
            matchupListBox.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// Loads the number of rounds in the tournament.
        /// </summary>
        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1);
            int currentRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }

            LoadMatchups(1);
        }

        /// <summary>
        /// Reloads matchups when selected index is changed from dropdown.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        /// <summary>
        /// Helper method.
        /// Loads current round matchups in the listbox.
        /// </summary>
        /// <param name="round"></param>
        private void LoadMatchups(int round)
        {
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    matchupsInRound.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || !unplayedOnlyCheckBox.Checked)
                        {
                            matchupsInRound.Add(m);
                        }
                    }
                }
            }
            if (matchupsInRound.Count > 0)
            {
                LoadMatchInfo(matchupsInRound.First()); 
            }

            DisplayMatchupFields();
        }

        /// <summary>
        /// Displays matchup entry fields if matches are available.
        /// </summary>
        private void DisplayMatchupFields()
        {
            bool isVisible = (matchupsInRound.Count > 0);
            teamOneNameLabel.Visible = isVisible;
            teamTwoNameLabel.Visible = isVisible;
            teamOneScoreLabel.Visible = isVisible;
            teamTwoScoreLabel.Visible = isVisible;
            teamOneScoreValue.Visible = isVisible;
            teamTwoScoreValue.Visible = isVisible;
            saveScoreButton.Visible = isVisible;
            versusLabel.Visible = isVisible;
        }

        /// <summary>
        /// Reloads matchup info when selected index is changed from list box.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            if (m != null)
            {
                LoadMatchInfo(m);
            }
        }

        /// <summary>
        /// Loads matchup information to the form.
        /// </summary>
        /// <param name="m"></param>
        private void LoadMatchInfo(MatchupModel m)
        {
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneNameLabel.Text = m.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = m.Entries[0].Score.ToString();

                        teamTwoNameLabel.Text = "BYE";
                        teamTwoScoreValue.Text = "0";
                    }
                    else 
                    {
                        teamOneNameLabel.Text = "TBD";
                        teamOneScoreValue.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoNameLabel.Text = m.Entries[1].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoNameLabel.Text = "TBD";
                        teamTwoScoreValue.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// Reloads matchup list box depending on state.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        /// <summary>
        /// Saves the match entries into respective databases.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unusedddd</param>
        private void saveScoreButton_Click(object sender, EventArgs e)
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for Team 1.");
                            return;
                        }

                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);
                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for Team 2.");
                            return;
                        }

                    }
                }
            }

            if (teamOneScore > teamTwoScore)
            {
                m.Winner = m.Entries[0].TeamCompeting;
            }
            else if (teamTwoScore > teamOneScore)
            {
                m.Winner = m.Entries[1].TeamCompeting;
            }
            else
            {
                MessageBox.Show("Tie games are not allowed.");
            }

            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel rm in round)
                {
                    foreach (MatchupEntryModel me in rm.Entries)
                    {
                        if (me.ParentMatchup != null)
                        {
                            if (me.ParentMatchup.Id == m.Id)
                            {
                                me.TeamCompeting = m.Winner;
                                GlobalConfig.Connection.UpdateMatchup(rm);
                            } 
                        }
                    }
                }
            }

            LoadMatchups((int)roundDropDown.SelectedItem);

            GlobalConfig.Connection.UpdateMatchup(m);
        }
    }
}
