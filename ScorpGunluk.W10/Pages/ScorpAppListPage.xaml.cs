//---------------------------------------------------------------------------
//
// <copyright file="ScorpAppListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>12/9/2016 6:32:03 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.YouTube;
using ScorpGunluk.Sections;
using ScorpGunluk.ViewModels;
using AppStudio.Uwp;

namespace ScorpGunluk.Pages
{
    public sealed partial class ScorpAppListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public ScorpAppListPage()
        {
			ViewModel = ViewModelFactory.NewList(new ScorpAppSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("b197bb98-e8f3-48e0-908f-e0ece237a561");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
            base.OnNavigatedTo(e);
        }

    }
}
