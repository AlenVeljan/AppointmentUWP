using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AppointmentUWP
{
   public class Msg
    {
        public static Uri DBUri = new Uri("https://appointments20210314125325.azurewebsites.net");

        internal async static void ShowMessage(string strTitle, string Msg)
        {
            ContentDialog diag = new ContentDialog()
            {
                Title = strTitle,
                Content = Msg,
                PrimaryButtonText = "Ok",
                DefaultButton = ContentDialogButton.Primary
            };
            await diag.ShowAsync();
        }

        internal async static Task<ContentDialogResult> ConfirmDialog(string strTitle, string Msg)
        {
            ContentDialog diag = new ContentDialog()
            {
                Title = strTitle,
                Content = Msg,
                PrimaryButtonText = "No",
                SecondaryButtonText = "Yes",
                DefaultButton = ContentDialogButton.Primary
                
               
            };
            ContentDialogResult result = await diag.ShowAsync();
            return result;
        }

    }
}

