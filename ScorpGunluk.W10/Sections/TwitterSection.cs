using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Twitter;
using ScorpGunluk.Navigation;
using ScorpGunluk.ViewModels;

namespace ScorpGunluk.Sections
{
    public class TwitterSection : Section<TwitterSchema>
    {
		private TwitterDataProvider _dataProvider;


		public TwitterSection()
		{
			_dataProvider = new TwitterDataProvider(new TwitterOAuthTokens
			{
				ConsumerKey = "AY0htcsmuiSNUzXZVahoX2s5a",
                    ConsumerSecret = "tqIXQ94yIPSYrFovyF8HZASqNNVbg7NxoqX0KFinHSN5bxn5hJ",
                    AccessToken = "2456546750-ephWGDu1WI5Ig8TPn6q5HAdNnCkkqv0oCBsdWd6",
                    AccessTokenSecret = "p8OF0ldLIX7ZZXMhx1ZaBXyVT9sUkQ2BQ6Qol56GufWu2"
			});
		}


		public override async Task<IEnumerable<TwitterSchema>> GetDataAsync(SchemaBase connectedItem = null)
        {
            var config = new TwitterDataConfig
            {
                QueryType = TwitterQueryType.User,
                Query = @"ScorpApp"
            };
            return await _dataProvider.LoadDataAsync(config, MaxRecords);
        }

        public override async Task<IEnumerable<TwitterSchema>> GetNextPageAsync()
        {
            return await _dataProvider.LoadMoreDataAsync();
        }

        public override bool HasMorePages
        {
            get
            {
                return _dataProvider.HasMoreItems;
            }
        }

        public override ListPageConfig<TwitterSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<TwitterSchema>
                {
                    Title = "Twitter",

                    Page = typeof(Pages.TwitterListPage),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.UserName.ToSafeString();
                        viewModel.SubTitle = item.Text.ToSafeString();
                        viewModel.ImageUrl = ItemViewModel.LoadSafeUrl(item.UserProfileImageUrl.ToSafeString());
                    },
                    DetailNavigation = (item) =>
                    {
                        return new NavInfo
                        {
                            NavigationType = NavType.DeepLink,
                            TargetUri = new Uri(item.Url)
                        };
                    }
                };
            }
        }

        public override DetailPageConfig<TwitterSchema> DetailPage
        {
            get { return null; }
        }
    }
}