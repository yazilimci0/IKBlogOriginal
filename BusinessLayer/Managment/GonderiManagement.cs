using BusinessLayer.Services;
using DataAccessLayer.EntittyFramework;
using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managment
{
    public class GonderiManagement : IGonderisServices<Gonderiler>
    {
        EfGonderiRepo GonderiRepo;

        public GonderiManagement(EfGonderiRepo GonderiRepo)
        {
            this.GonderiRepo = GonderiRepo;
        }
        public void add(Gonderiler gonderiler)
        {
            GonderiRepo.add(gonderiler);
        }

        public List<Gonderiler> getAllList()
        {
            return GonderiRepo.getAllList();
        }

	
		public void remove(int id)
        {
            GonderiRepo.remove(id);
        }

        public void update(Gonderiler gonderiler)
        {
            GonderiRepo.update(gonderiler);
        }
    }
}
