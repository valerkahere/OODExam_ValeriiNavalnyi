using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace OODExam_ValeriiNavalnyi
{
    /// <summary>
    /// Interaction logic for NewTrainingSession.xaml
    /// </summary>
    public partial class NewTrainingSession : Window
    {
        // Reference to the DB
        private ClubData db = new ClubData();

        // Store the member this trainingSession belongs to
        private Member _member;

        // Store trainingSession being edited (null if adding new)
        private TrainingSession trainingSessionToEdit;
        public NewTrainingSession(Member member)
        {
            InitializeComponent();
            _member = member;
        }

      
    }
}
