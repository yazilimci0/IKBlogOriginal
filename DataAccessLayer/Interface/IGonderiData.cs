using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IGonderiData<Gonderi>
    {
        void add(Gonderiler gonderiler);
        void remove(Gonderiler gonderiler);
        void update(Gonderiler gonderiler);
        List<Gonderiler> getAllList();
		Gonderi getCategoryById(int id);




	}
}
