//---------------------------------------------------------------------------
//
// <copyright file="TwitterListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>12/9/2016 6:32:03 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Twitter;
using ScorpGunluk.Sections;
using ScorpGunluk.ViewModels;
using AppStudio.Uwp;

namespace ScorpGunluk.Pages
{
    public sealed partial class TwitterListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public TwitterListPage()
        {
			ViewModel = ViewModelFactory.NewList(new TwitterSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("8ccfc771-8bd9-4b5b-b2ea-d6b593081a82");
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
