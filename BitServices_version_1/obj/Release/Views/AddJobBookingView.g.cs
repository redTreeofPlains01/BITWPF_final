#pragma checksum "..\..\..\Views\AddJobBookingView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7EADAA0A56CFE87C138421673E72586AB2DAC1CB2F92CD0B4D4F8C440FB70EEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BitServices_version_1.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BitServices_version_1.Views {
    
    
    /// <summary>
    /// AddJobBookingView
    /// </summary>
    public partial class AddJobBookingView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 99 "..\..\..\Views\AddJobBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearchCustomer;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Views\AddJobBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgSearchCustomers;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\Views\AddJobBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFindSessions;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Views\AddJobBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\Views\AddJobBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBackToJobBookingManagement;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\Views\AddJobBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAvailableSessions;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Views\AddJobBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BitServices_version_1;component/views/addjobbookingview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AddJobBookingView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnSearchCustomer = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.dgSearchCustomers = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btnFindSessions = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\Views\AddJobBookingView.xaml"
            this.btnFindSessions.Click += new System.Windows.RoutedEventHandler(this.btnFindSessions_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.btnBackToJobBookingManagement = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\Views\AddJobBookingView.xaml"
            this.btnBackToJobBookingManagement.Click += new System.Windows.RoutedEventHandler(this.btnBackToJobBookingManagement_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgAvailableSessions = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 149 "..\..\..\Views\AddJobBookingView.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

