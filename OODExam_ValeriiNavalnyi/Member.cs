using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OODExam_ValeriiNavalnyi
{
    // Member.cs — the "one" side
    public class Member
    {

        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string MembershipType { get; set; }

        // Navigation property — a patient HAS MANY appointments
        // "virtual" enables lazy loading
        public virtual List<TrainingSession> Members { get; set; }


        public override string ToString()
        {
            return $"{Surname}, {FirstName} — {ContactNumber}";
        }
    }
}
