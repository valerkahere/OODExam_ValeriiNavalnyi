using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OODExam_ValeriiNavalnyi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // global vars to store data
        List<Member> members = new List<Member>();
        List<TrainingSession> trainingSessions = new List<TrainingSession>();

        // Connection to the db
        private ClubData db = new ClubData();

        public MainWindow()
        {
            InitializeComponent();

            // Query the database using LINQ for all members on window load.
            DisplayMembers();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        public void RefreshMembers()
        {
            lbx_Members.ItemsSource = null;
            lbx_Members.ItemsSource = members;

     
        }
        public void RefreshTrainingSessions()
        {
            lbx_trainingSessions.ItemsSource = null;
            lbx_trainingSessions.ItemsSource = trainingSessions;


        }

        public void DisplayMembers()
        {
            try
            {
                // Display members 
                // sorted by last name in the Members ListBox on the left in the following format:
                // Surname, FirstName – Contact Number
                var query = from member in db.Members
                            orderby member.Surname
                            select member;

                members = query.ToList();

                // if there are members present, display them
                if (members.Count > 0)
                {
                    RefreshMembers();
                }
                else
                {
                    MessageBox.Show("No members found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to a db: " + ex.Message);
            }


        }


        
        private void DisplayMemberInfo(Member member)
        {
            tbl_id.Text = null;
            tbl_fName.Text = null;
            tbl_lName.Text = null;
            tbl_contactNumber.Text = null;
            tbl_membershipType.Text = null;
            tbl_dateOfBirth.Text = null;

            tbl_id.Text = member.MemberId.ToString();
            tbl_fName.Text = member.FirstName.ToString();
            tbl_lName.Text = member.Surname.ToString();
            tbl_contactNumber.Text = member.ContactNumber.ToString();
            tbl_membershipType.Text = member.MembershipType.ToString();

            // excluding time component
            tbl_dateOfBirth.Text = member.DateOfBirth.ToShortDateString().ToString();


        }
        private void lbx_Members_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // When a member is selected from the Members ListBox, the details should populate 
                // the Member Details fields

                Member selectedMember = lbx_Members.SelectedItem as Member;

                if (selectedMember != null)
                {
                    DisplayMemberInfo(selectedMember);
                }

                // the Training Sessions should be displayed in the 
                // Training Sessions ListBox sorted by date.
                // only if training session has this member
                var query = from TrainingSession in db.TrainingSessions
                            where TrainingSession.MemberId == selectedMember.MemberId
                            orderby TrainingSession.TrainingSessionDate
                            select TrainingSession;




                trainingSessions = null;
                trainingSessions = query.ToList();



                // If a member has no sessions an 
                // appropriate message should be displayed.
                if (trainingSessions.Count > 0)
                {
                    RefreshTrainingSessions();
                }
                else
                {
                    MessageBox.Show("No training sessions found for this member");
                    trainingSessions = null;
                    RefreshTrainingSessions();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to a db: " + ex.Message);
            }
            


            
        }
    }
}
