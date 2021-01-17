using GP.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public class FactureService : Service<Facture>, IFactureService
    {
        public IEnumerable<Facture> GetFacturesByClient(Client C)
        {
            return GetMany(F => F.ClientFk == C.CIN);
        }
    }
}
