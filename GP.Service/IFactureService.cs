using GP.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public interface IFactureService : IService<Facture>
    {
       IEnumerable<Facture> GetFacturesByClient(Client C);
    }
}
