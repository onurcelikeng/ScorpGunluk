using System;
using System.Collections.Generic;
using AppStudio.Uwp;
using AppStudio.Uwp.Commands;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ScorpGunluk.Sections;
namespace ScorpGunluk.ViewModels
{
    public class SearchViewModel : PageViewModelBase
    {
        public SearchViewModel() : base()
        {
			Title = "Scorp Günlük";
            ScorpApp = ViewModelFactory.NewList(new ScorpAppSection());
            ScorpSakalar = ViewModelFactory.NewList(new ScorpSakalarSection());
            ScorpMuzik = ViewModelFactory.NewList(new ScorpMuzikSection());
            ScorpIliskiler = ViewModelFactory.NewList(new ScorpIliskilerSection());
            ScorpFenomen = ViewModelFactory.NewList(new ScorpFenomenSection());
            ScorpModa = ViewModelFactory.NewList(new ScorpModaSection());
            Twitter = ViewModelFactory.NewList(new TwitterSection());
            Facebook = ViewModelFactory.NewList(new FacebookSection());
                        
        }

        private string _searchText;
        private bool _hasItems = true;

        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        public bool HasItems
        {
            get { return _hasItems; }
            set { SetProperty(ref _hasItems, value); }
        }

		public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand<string>(
                async (text) =>
                {
                    await SearchDataAsync(text);
                }, SearchViewModel.CanSearch);
            }
        }      
        public ListViewModel ScorpApp { get; private set; }
        public ListViewModel ScorpSakalar { get; private set; }
        public ListViewModel ScorpMuzik { get; private set; }
        public ListViewModel ScorpIliskiler { get; private set; }
        public ListViewModel ScorpFenomen { get; private set; }
        public ListViewModel ScorpModa { get; private set; }
        public ListViewModel Twitter { get; private set; }
        public ListViewModel Facebook { get; private set; }
        public async Task SearchDataAsync(string text)
        {
            this.HasItems = true;
            SearchText = text;
            var loadDataTasks = GetViewModels()
                                    .Select(vm => vm.SearchDataAsync(text));

            await Task.WhenAll(loadDataTasks);
			this.HasItems = GetViewModels().Any(vm => vm.HasItems);
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
		private void CleanItems()
        {
            foreach (var vm in GetViewModels())
            {
                vm.CleanItems();
            }
        }
		public static bool CanSearch(string text) { return !string.IsNullOrWhiteSpace(text) && text.Length >= 3; }
    }
}
