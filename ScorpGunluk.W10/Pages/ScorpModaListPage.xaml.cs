//---------------------------------------------------------------------------
//
// <copyright file="ScorpModaListPage.xaml.cs" company="Microsoft">
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
    public sealed partial class ScorpModaListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public ScorpModaListPage()
        {
			ViewModel = ViewModelFactory.NewList(new ScorpModaSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("da61f7f1-d17a-4fcf-a509-ced53a6a8695");
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
