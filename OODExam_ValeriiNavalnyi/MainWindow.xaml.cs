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
                    RefreshScreen();
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

        public void RefreshScreen()
        {
            lbx_Members.ItemsSource = null;
            lbx_Members.ItemsSource = members;

     
        }
    }
}
