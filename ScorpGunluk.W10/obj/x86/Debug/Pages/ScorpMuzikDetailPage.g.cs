﻿#pragma checksum "C:\Users\onurcelikeng\Documents\Visual Studio 2015\Projects\ScorpGunluk\ScorpGunluk.W10\Pages\ScorpMuzikDetailPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8954368EAB27DA355937360743D61CCC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScorpGunluk.Pages
{
    partial class ScorpMuzikDetailPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_ScorpGunluk_Layouts_Detail_BaseDetailLayout_ViewModel(global::ScorpGunluk.Layouts.Detail.BaseDetailLayout obj, global::ScorpGunluk.ViewModels.DetailViewModel value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::ScorpGunluk.ViewModels.DetailViewModel) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::ScorpGunluk.ViewModels.DetailViewModel), targetNullValue);
                }
                obj.ViewModel = value;
            }
        };

        private class ScorpMuzikDetailPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IScorpMuzikDetailPage_Bindings
        {
            private global::ScorpGunluk.Pages.ScorpMuzikDetailPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::ScorpGunluk.Layouts.Detail.YouTubeDetailLayout obj3;

            public ScorpMuzikDetailPage_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3:
                        this.obj3 = (global::ScorpGunluk.Layouts.Detail.YouTubeDetailLayout)target;
                        break;
                    default:
                        break;
                }
            }

            // IScorpMuzikDetailPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // ScorpMuzikDetailPage_obj1_Bindings

            public void SetDataRoot(global::ScorpGunluk.Pages.ScorpMuzikDetailPage newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::ScorpGunluk.Pages.ScorpMuzikDetailPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::ScorpGunluk.ViewModels.DetailViewModel obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_ScorpGunluk_Layouts_Detail_BaseDetailLayout_ViewModel(this.obj3, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.root = (global::Windows.UI.Xaml.Controls.Page)(target);
                }
                break;
            case 2:
                {
                    this.commandBar = (global::AppStudio.Uwp.Actions.ActionsCommandBar)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ScorpMuzikDetailPage_obj1_Bindings bindings = new ScorpMuzikDetailPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

