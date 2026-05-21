using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODExam_ValeriiNavalnyi
{
    // TrainingSession.cs — the "many" side
    public class TrainingSession
    {

        public int TrainingSessionId { get; set; }
        public DateTime TrainingSessionDate { get; set; }
        public string TrainingSessionType { get; set; }
        public int DurationMinutes { get; set; }
        public string CoachNotes { get; set; }

        // Foreign Key — links back to Member
        public int MemberId { get; set; }

        // Navigation property — a Training BELONGS TO one Member
        public virtual Member Member { get; set; }

        public override string ToString()
        {
            return $"{TrainingSessionDate.ToShortDateString()}: {CoachNotes}";
        }
    }
}
