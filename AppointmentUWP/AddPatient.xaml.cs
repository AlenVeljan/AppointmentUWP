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
    public sealed partial class AddPatient : Page
    {

        private Patient patient = new Patient();
        public AddPatient()
        {
            this.InitializeComponent();
           
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
          
            if (string.IsNullOrEmpty(patientFirstNameTB.Text))
            {

                Msg.ShowMessage("Error", "Please Enter a First Name.");
                return;
            }
            else
            {
                patient.firstName = patientFirstNameTB.Text;
            }
           
            if (string.IsNullOrEmpty(patientLastNameTB.Text))
            {

                Msg.ShowMessage("Error", "Please Enter a Last Name.");
                return;
            }
            else
            {
                patient.lastName = patientLastNameTB.Text;
            }


            var patientJson = JsonConvert.SerializeObject(patient);

            var client = new HttpClient();
            var HttpContent = new StringContent(patientJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            await client.PostAsync("https://appointments20210314125325.azurewebsites.net/api/patients/", HttpContent);

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
