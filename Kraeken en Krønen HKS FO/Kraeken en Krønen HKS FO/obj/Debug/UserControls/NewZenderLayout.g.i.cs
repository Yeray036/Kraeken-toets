// Updated by XamlIntelliSenseFileGenerator 14-4-2020 15:56:22
#pragma checksum "..\..\..\UserControls\NewZenderLayout.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "109E1D1E34D137D9F8FE676D1C1A18F5B7E775DB943E8D3C0EB478F86B26ED84"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Kraeken_en_Krønen_HKS_FO.UserControls;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Kraeken_en_Krønen_HKS_FO.UserControls
{


    /// <summary>
    /// NewZenderLayout
    /// </summary>
    public partial class NewZenderLayout : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 32 "..\..\..\UserControls\NewZenderLayout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel NewZenderGrid;

#line default
#line hidden


#line 33 "..\..\..\UserControls\NewZenderLayout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NewZender;

#line default
#line hidden


#line 34 "..\..\..\UserControls\NewZenderLayout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NewOmschrijving;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kraeken en Krønen HKS FO;component/usercontrols/newzenderlayout.xaml", System.UriKind.Relative);

#line 1 "..\..\..\UserControls\NewZenderLayout.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.NewZenderControl = ((Kraeken_en_Krønen_HKS_FO.UserControls.NewZenderLayout)(target));
                    return;
                case 2:
                    this.NewZenderGrid = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 3:
                    this.NewZender = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 4:
                    this.NewOmschrijving = ((System.Windows.Controls.TextBlock)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.UserControl NewZenderControl;
        internal System.Windows.Controls.Button wijzigBtn;
        internal System.Windows.Controls.Button verwijderBtn;
    }
}

