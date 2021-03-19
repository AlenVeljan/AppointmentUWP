using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentUWP
{
    class Appointment
    {
        public int appointment_id { get; set; }

        public DateTime date { get; set; }
        public string note { get; set; }


        public int patient_id { get; set; }
        public Patient Patient { get; set; }


    }
}
