﻿#pragma checksum "C:\Users\AlenV\source\repos\AppointmentUWP\AppointmentUWP\AddPatient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D404C33BC67558EE98A37290C87D036D57108BD4043B71F07172EEF8E882FDD0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppointmentUWP
{
    partial class AddPatient : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // AddPatient.xaml line 13
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element2 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element2).Click += this.btnSave_Click;
                }
                break;
            case 3: // AddPatient.xaml line 14
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element3 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element3).Click += this.btnCancel_Click;
                }
                break;
            case 4: // AddPatient.xaml line 15
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element4 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element4).Click += this.AppBarButton_Click;
                }
                break;
            case 5: // AddPatient.xaml line 21
                {
                    this.LayoutRoot = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // AddPatient.xaml line 40
                {
                    this.patientFirstNameTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // AddPatient.xaml line 41
                {
                    this.patientLastNameTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
