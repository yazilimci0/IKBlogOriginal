using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
   public interface IGonderisServices<Gonderi>
    {
        void add(Gonderiler gonderiler);
        void remove(Gonderiler gonderiler);
        void update(Gonderiler gonderiler);
        List<Gonderi> getAllList();
		Gonderi getCategoryById(int id);



	}
}
