﻿using DataAccessLayer.Interface;
using DataAccessLayer.Repostory;
using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntittyFramework
{
    public class EfUserRepo : DataUserRepostory,IUserData<User>
    {
    }
}
