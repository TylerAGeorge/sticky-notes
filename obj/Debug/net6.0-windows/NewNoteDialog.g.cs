﻿#pragma checksum "..\..\..\NewNoteDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1D8D3AFE3459D9F61538B403520942056EF87DDB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using sticky_notes;


namespace sticky_notes {
    
    
    /// <summary>
    /// NewNoteDialog
    /// </summary>
    public partial class NewNoteDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\NewNoteDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewNoteTextbox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\NewNoteDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton YellowRadio;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\NewNoteDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton PinkRadio;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\NewNoteDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton GreenRadio;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\NewNoteDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton OrangeRadio;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\NewNoteDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton BlueRadio;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\NewNoteDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\NewNoteDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/sticky-notes;component/newnotedialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NewNoteDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NewNoteTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.YellowRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\..\NewNoteDialog.xaml"
            this.YellowRadio.Checked += new System.Windows.RoutedEventHandler(this.SelectColor);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PinkRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\..\NewNoteDialog.xaml"
            this.PinkRadio.Checked += new System.Windows.RoutedEventHandler(this.SelectColor);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GreenRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 19 "..\..\..\NewNoteDialog.xaml"
            this.GreenRadio.Checked += new System.Windows.RoutedEventHandler(this.SelectColor);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OrangeRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 20 "..\..\..\NewNoteDialog.xaml"
            this.OrangeRadio.Checked += new System.Windows.RoutedEventHandler(this.SelectColor);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BlueRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\..\NewNoteDialog.xaml"
            this.BlueRadio.Checked += new System.Windows.RoutedEventHandler(this.SelectColor);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\NewNoteDialog.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NewButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\NewNoteDialog.xaml"
            this.NewButton.Click += new System.Windows.RoutedEventHandler(this.NewClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

