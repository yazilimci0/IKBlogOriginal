using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IUserData<User>
    {
        void add(User user);
        void remove(int id);
        void update(User user);
        List<User> getAllList();

    }
}
