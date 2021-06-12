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
    public partial class CreateTeamForm : Form
    {

        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        private ITeamRequester callingForm;

        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();

            callingForm = caller;

            WireUpLists();
        }

        /// <summary>
        /// Refreshes the list.
        /// </summary>
        private void WireUpLists()
        {
            selectPlayerDropDown.DataSource = null;

            selectPlayerDropDown.DataSource = availableTeamMembers;
            selectPlayerDropDown.DisplayMember = "FullName";

            playersListBox.DataSource = null;

            playersListBox.DataSource = selectedTeamMembers;
            playersListBox.DisplayMember = "FullName";
        }

        /// <summary>
        /// Click function that triggers CreatePlayer() in the respective connector classes.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void createPlayerButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailAddressValue.Text;
                p.CellphoneNumber = cellphoneValue.Text;

                GlobalConfig.Connection.CreatePlayer(p);

                selectedTeamMembers.Add(p);

                WireUpLists();

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailAddressValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("All fields required.");
            }
        }

        /// <summary>
        /// Validates the fields in the Create New Player form.
        /// </summary>
        /// <returns>True; if data is valid.</returns>
        private bool ValidateForm()
        {
            // TODO: Improve validation
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (emailAddressValue.Text.Length == 0)
            {
                return false;
            }

            if (cellphoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds a player from the dropdown to the list box.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectPlayerDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists(); 
            }
        }

        /// <summary>
        /// Removes a player from the list box and adds to the dropdown.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void removePlayerButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)playersListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists(); 
            }
        }

        /// <summary>
        /// Creates a new team.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();

            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(t);

            callingForm.TeamComplete(t);

            this.Close();
        }
    }
}
