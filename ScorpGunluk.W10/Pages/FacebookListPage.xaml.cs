//---------------------------------------------------------------------------
//
// <copyright file="FacebookListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>12/9/2016 6:32:03 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Facebook;
using ScorpGunluk.Sections;
using ScorpGunluk.ViewModels;
using AppStudio.Uwp;

namespace ScorpGunluk.Pages
{
    public sealed partial class FacebookListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public FacebookListPage()
        {
			ViewModel = ViewModelFactory.NewList(new FacebookSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("178024a3-715a-421b-81ce-f43d8d078601");
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
