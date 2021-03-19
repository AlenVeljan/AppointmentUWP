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
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppointmentUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private Patient patient = new Patient();
      
        private readonly object appointmentResult;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;
            try
            {

                HttpClient client = new HttpClient();

                var JsonResponse = await client.GetStringAsync("https://appointments20210314125325.azurewebsites.net/api/patients/");
                var patientResult = JsonConvert.DeserializeObject<List<Patient>>(JsonResponse);
                // patientResult.Insert(0, new Patient { patient_id = 0, lastName = " All Appointments" });

                PatientCombo.ItemsSource = patientResult;

                if (patient.patient_id == 0)
                {

                    var JsonResponse1 = await client.GetStringAsync("https://appointments20210314125325.azurewebsites.net/api/appointments/");
                    var appointmentResult = JsonConvert.DeserializeObject<List<Appointment>>(JsonResponse1);
                    appointmentsList.ItemsSource = appointmentResult;
                }
            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }


        private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
                Frame.Navigate(typeof(MainPage), null);
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddPatient));
        }

        private void appointmentsList_ItemClick(object sender, ItemClickEventArgs e)
        {

            var appointment = appointmentsList.SelectedItem as Appointment;

        }

        private async void PatientCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            try
            {
                var patient = PatientCombo.SelectedItem as Patient;

                HttpClient client = new HttpClient();

                var JsonResponse = await client.GetStringAsync("https://appointments20210314125325.azurewebsites.net/api/byPatient/" + patient.patient_id);
                var patientResultApp = JsonConvert.DeserializeObject<List<Appointment>>(JsonResponse);

                appointmentsList.ItemsSource = patientResultApp;
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("connection with the server"))
                {
                    Msg.ShowMessage("Error", "No connection with server.");
                }
                else
                {
                    Msg.ShowMessage("Error", "Could not complete operation.");
                }
            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;

            }
        }

        private void btnAddA_Click(object sender, RoutedEventArgs e)
        {

            var patient = PatientCombo.SelectedItem as Patient;

            if (PatientCombo.SelectedItem != null)
            {
                Frame.Navigate(typeof(AddAppointment), patient);
            }
            else
            {
                Msg.ShowMessage("Error", "Please Select Patient.");

            }

        }

        private async void btnDel_Click(object sender, RoutedEventArgs e)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;
            try
            {
                string striTitle = "Confirm Delete";
                string strMsg = "Are you certain that you want to delete Appointment ? ";
                ContentDialogResult result = await Msg.ConfirmDialog(striTitle, strMsg);

                var patient = PatientCombo.SelectedItem as Patient;
                var appointment = appointmentsList.SelectedItem as Appointment;

                if (result == ContentDialogResult.Secondary)
                {

                    if (PatientCombo.SelectedItem != null)
                    {

                        if (appointmentsList.SelectedItem != null)
                        {
                            var client = new HttpClient();
                            await client.DeleteAsync("https://appointments20210314125325.azurewebsites.net/api/appointments/" + appointment.appointment_id);
                            Msg.ShowMessage("Succes", "Appointment Deleted.");
                            Frame.Navigate(typeof(MainPage));
                        }
                        else
                        {
                            Msg.ShowMessage("Error", "Please Select Appointment.");
                        }

                    }
                    else
                    {
                        Msg.ShowMessage("Error", "Please Select Patent First.");
                    }

                }

            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }

        }

        private async void btnSDelete_Click(object sender, RoutedEventArgs e)
        {
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;
            try
            {

                var patient = PatientCombo.SelectedItem as Patient;
                var client = new HttpClient();

                string striTitle = "Confirm Delete";
                string strMsg = "Are you certain that you want to delete Patient ? " +
                                 " Please Delete first all appointments selected Patient";
                ContentDialogResult result = await Msg.ConfirmDialog(striTitle, strMsg);
                if (result == ContentDialogResult.Secondary)
                {

                    if (PatientCombo.SelectedItem != null)
                    {

                        await client.DeleteAsync("https://appointments20210314125325.azurewebsites.net/api/patients/" + patient.patient_id);
                        Frame.Navigate(typeof(MainPage));
                    }

                    else
                    {
                        Msg.ShowMessage("Error", "Please Select Patient.");
                    }

                }
            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    var dateappointment = datePicker.Date.Date.Add(timePicker.SelectedTime.GetValueOrDefault());

                    HttpClient client = new HttpClient();

                    var JsonResponse = await client.GetStringAsync("https://appointments20210314125325.azurewebsites.net/api/ByTime?date=" + dateappointment);
                    var patientResultApp = JsonConvert.DeserializeObject<List<Appointment>>(JsonResponse);

                    appointmentsList.ItemsSource = patientResultApp;

                }
                catch (Exception ex)
                {
                    if (ex.GetBaseException().Message.Contains("connection with the server"))
                    {
                        Msg.ShowMessage("Error", "No connection with server.");
                    }
                    else
                    {
                        Msg.ShowMessage("Error", "Please Enter correct Date.");
                    }
                }
        }
    }
}
  
    
