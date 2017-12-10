using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScorpGunluk.ViewModels
{
    public class ComposedItemViewModel : ItemViewModel, IEnumerable<ItemViewModel>
    {
        private ObservableCollection<ItemViewModel> _blocks;

        public ComposedItemViewModel()
        {
            _blocks = new ObservableCollection<ItemViewModel>();
        }

        public void Add(ItemViewModel item)
        {
            _blocks.Add(item);

            if (_blocks.Count == 1)
            {
                Sync(item);
            }
        }

        public IEnumerator<ItemViewModel> GetEnumerator()
        {
            return _blocks.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}