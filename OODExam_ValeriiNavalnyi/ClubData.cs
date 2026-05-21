using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODExam_ValeriiNavalnyi
{
    // for DB context to be extended
    // Nu Get entity framework installed
    public class ClubData : DbContext
    {
        // overload constructor
        public ClubData() : base("OODExam_ValeriiNavalnyi") { } // the name of DB

        // Creates Members table in DB
        public DbSet<Member> Members { get; set; }

        // Creates TrainingSessions table in DB
        public DbSet<TrainingSession> TrainingSessions { get; set; }
    }

}
