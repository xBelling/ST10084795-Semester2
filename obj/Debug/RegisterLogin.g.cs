﻿#pragma checksum "..\..\RegisterLogin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "75E4ACB9B41B495C43F0D500AC379B7ED6E810E8C5B9EA18C0982966E63F8430"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ST10084795_POE_Part2;
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


namespace ST10084795_POE_Part2 {
    
    
    /// <summary>
    /// RegisterLogin
    /// </summary>
    public partial class RegisterLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\RegisterLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRegUse;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\RegisterLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRegPass;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\RegisterLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtConfirmPass;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\RegisterLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button subReg;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\RegisterLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLogUse;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\RegisterLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLogPass;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\RegisterLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button subLog;
        
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
            System.Uri resourceLocater = new System.Uri("/ST10084795-POE-Part2;component/registerlogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegisterLogin.xaml"
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
            this.txtRegUse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtRegPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtConfirmPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.subReg = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\RegisterLogin.xaml"
            this.subReg.Click += new System.Windows.RoutedEventHandler(this.RegisterBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtLogUse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtLogPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.subLog = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\RegisterLogin.xaml"
            this.subLog.Click += new System.Windows.RoutedEventHandler(this.loginBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

