using DataAccess.Context;
using DataAccessLayer.Interface;
using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repostory
{
    public class DataGonderiRepostory : IGonderiData<Gonderiler>
    {
        IKBlokContex IKBlokContex=new IKBlokContex();
        public void add(Gonderiler gonderiler)
        {
            IKBlokContex.Add(gonderiler);
            IKBlokContex.SaveChanges();
        }

        public List<Gonderiler> getAllList()
        {
            var list = IKBlokContex.Set<Gonderiler>()
                 .ToList();
            return list;
        }

	
		public void remove(Gonderiler gonderiler)
        {
            IKBlokContex.Remove(gonderiler);
            IKBlokContex.SaveChanges(); 
        }

        public void update(Gonderiler gonderiler)
        {
            IKBlokContex.Update(gonderiler);
            IKBlokContex.SaveChanges(); 
        }
    }
}
