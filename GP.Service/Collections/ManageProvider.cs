using GP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public class ManageProvider
    {
        private List<Provider> Providers;

        public ManageProvider(List<Provider> providers)
        {
            this.Providers = providers;
        }
        public List<Provider> GetProviderByName(string name)
        {
            var query = from P in Providers
                        where P.UserName.Contains(name)
                        select P;
            return query.ToList<Provider>();
        }

        public Provider GetFirstProviderByName(string name)
        {
            var query = from P in Providers
                        where P.UserName.Contains(name)
                        select P;
            return query.First();
        }

        public Provider GetProviderById(int id)
        {
            var query = from P in Providers
                        where P.Id == id
                        select P;
            return query.Single();
        }
    }
}
