using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace AppointmentUWP
{
   class Patient
    {
       
        public int patient_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

       public List<Appointment> Appointments { get; set; }

        public Patient()
        {
            Appointments = new List<Appointment>();
        }

        public string FullName => $"{firstName} {lastName}";
    }
}
