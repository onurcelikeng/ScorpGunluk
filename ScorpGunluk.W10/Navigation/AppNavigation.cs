using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using AppStudio.Uwp;
using AppStudio.Uwp.Controls;
using AppStudio.Uwp.Navigation;
using Windows.System;
using AppStudio.DataProviders;
using ScorpGunluk.ViewModels;

namespace ScorpGunluk.Navigation
{
    public static class AppNavigation
    {
        private static Brush NavigationItemColor { get { return "NavigationPaneText".Resource() as Brush; } }

        public static void Navigate(ItemViewModel item, IEnumerable<SchemaBase> items)
        {
            if (item.NavInfo != null)
            {
                if (item.NavInfo.NavigationType == NavType.Page)
                {
                    if (item.NavInfo.IsDetail)
                    {
                        var param = new NavDetailParameter
                        {
                            SelectedId = item.Id,
                            Items = items
                        };
                        NavigationService.NavigateToPage(item.NavInfo.TargetPage, param);
                    }
                    else
                    {
                        NavigationService.NavigateToPage(item.NavInfo.TargetPage);
                    }
                }
                else if (item.NavInfo.NavigationType == NavType.DeepLink)
                {
                    Launcher.LaunchUriAsync(item.NavInfo.TargetUri).AsTask().FireAndForget();
                }
            }
        }

        public static NavigationItem NodeFromAction(string id, string caption, Action<NavigationItem> onClick, IconElement icon = null, Image image = null)
        {
            var node = new NavigationItem(id, caption);
            node.OnClick = onClick;
            node.Icon = icon;
            node.Image = image;
            return node;
        }

        public static IconElement IconFromGlyph(string glyph) => NavigationItem.CreateIcon(glyph, NavigationItemColor);
        public static IconElement IconFromSymbol(Symbol symbol) => NavigationItem.CreateIcon(symbol, NavigationItemColor);
        public static Action<NavigationItem> ActionFromPage(string pageName) => (ni) => NavigationService.NavigateToPage(pageName);
    }
}