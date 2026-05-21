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

        public int SessionId { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionType { get; set; }
        public int DurationMinutes { get; set; }
        public string CoachNotes { get; set; }

        // Foreign Key — links back to Member
        public int MemberId { get; set; }

        // Navigation property — a Training BELONGS TO one Member
        public virtual Member Member { get; set; }
    }
}
