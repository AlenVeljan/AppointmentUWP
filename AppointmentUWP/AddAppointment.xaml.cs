using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppointmentUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddAppointment : Page
    {
        private Patient patient = new Patient();
        private Appointment appointment = new Appointment();
        private static readonly List<Appointment> Appointments = new List<Appointment>();
        
        public AddAppointment()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            try
            {


                patient = e.Parameter as Patient;


                HttpClient client = new HttpClient();

                var JsonResponse = await client.GetStringAsync("https://appointments20210314125325.azurewebsites.net/api/byPatient/" + patient.patient_id);
                var patientResult = JsonConvert.DeserializeObject<List<Appointment>>(JsonResponse);

            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
                   
        }


        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var client = new HttpClient();

            
                
                    
                appointment.date = datePicker.Date.Date.Add(timePicker.SelectedTime.GetValueOrDefault());
           
                
                  
                         
          
                if (string.IsNullOrEmpty(noteTextBox.Text))
                {

                    Msg.ShowMessage("Error", "Please Enter a Note.");
                    return;
                }
                else
                {
                     appointment.note = noteTextBox.Text;
                }
                
                                 
                            
                                        
          
            appointment.patient_id = patient.patient_id;

            var appointmentJson = JsonConvert.SerializeObject(appointment);

            var HttpContent = new StringContent(appointmentJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            await client.PostAsync("https://appointments20210314125325.azurewebsites.net/api/Appointments/", HttpContent);
            Frame.GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
