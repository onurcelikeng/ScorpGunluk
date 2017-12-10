using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppStudio.DataProviders;

namespace ScorpGunluk.Sections
{
    public abstract class Section<TSchema> where TSchema : SchemaBase
    {
        public abstract Task<IEnumerable<TSchema>> GetDataAsync(SchemaBase connectedItem = null);
        public abstract Task<IEnumerable<TSchema>> GetNextPageAsync();

        public abstract bool HasMorePages { get; }

        public abstract ListPageConfig<TSchema> ListPage { get; }
        public abstract DetailPageConfig<TSchema> DetailPage { get; }

        public virtual int MaxRecords
        {
            get
            {
                return 20;
            }
        }

        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public virtual bool NeedsNetwork
        {
            get
            {
                return true;
            }
        }

        public virtual TimeSpan CacheExpiration
        {
            get
            {
                //override in children sections if you want to modify cache expiration
                return new TimeSpan(2, 0, 0);
            }
        }
    }
}
