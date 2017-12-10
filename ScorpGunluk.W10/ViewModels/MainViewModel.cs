using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Navigation;
using AppStudio.Uwp.Commands;
using AppStudio.DataProviders;

using AppStudio.DataProviders.YouTube;
using AppStudio.DataProviders.Twitter;
using AppStudio.DataProviders.Facebook;
using AppStudio.DataProviders.LocalStorage;
using ScorpGunluk.Sections;


namespace ScorpGunluk.ViewModels
{
    public class MainViewModel : PageViewModelBase
    {
        public ListViewModel ScorpApp { get; private set; }
        public ListViewModel ScorpSakalar { get; private set; }
        public ListViewModel ScorpMuzik { get; private set; }
        public ListViewModel ScorpIliskiler { get; private set; }
        public ListViewModel ScorpFenomen { get; private set; }
        public ListViewModel ScorpModa { get; private set; }
        public ListViewModel Twitter { get; private set; }
        public ListViewModel Facebook { get; private set; }

        public MainViewModel(int visibleItems) : base()
        {
            Title = "Scorp Günlük";
            ScorpApp = ViewModelFactory.NewList(new ScorpAppSection(), visibleItems);
            ScorpSakalar = ViewModelFactory.NewList(new ScorpSakalarSection(), visibleItems);
            ScorpMuzik = ViewModelFactory.NewList(new ScorpMuzikSection(), visibleItems);
            ScorpIliskiler = ViewModelFactory.NewList(new ScorpIliskilerSection(), visibleItems);
            ScorpFenomen = ViewModelFactory.NewList(new ScorpFenomenSection(), visibleItems);
            ScorpModa = ViewModelFactory.NewList(new ScorpModaSection(), visibleItems);
            Twitter = ViewModelFactory.NewList(new TwitterSection(), visibleItems);
            Facebook = ViewModelFactory.NewList(new FacebookSection(), visibleItems);

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = RefreshCommand,
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

		#region Commands
		public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var refreshDataTasks = GetViewModels()
                        .Where(vm => !vm.HasLocalData).Select(vm => vm.LoadDataAsync(true));

                    await Task.WhenAll(refreshDataTasks);
					LastUpdated = GetViewModels().OrderBy(vm => vm.LastUpdated, OrderType.Descending).FirstOrDefault()?.LastUpdated;
                    OnPropertyChanged("LastUpdated");
                });
            }
        }
		#endregion

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);
			LastUpdated = GetViewModels().OrderBy(vm => vm.LastUpdated, OrderType.Descending).FirstOrDefault()?.LastUpdated;
            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<ListViewModel> GetViewModels()
        {
            yield return ScorpApp;
            yield return ScorpSakalar;
            yield return ScorpMuzik;
            yield return ScorpIliskiler;
            yield return ScorpFenomen;
            yield return ScorpModa;
            yield return Twitter;
            yield return Facebook;
        }
    }
}
