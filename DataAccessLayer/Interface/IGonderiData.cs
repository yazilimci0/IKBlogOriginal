﻿using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IGonderiData<Gonderiler>
    {
        void add(Gonderiler gonderiler);
        void remove(Gonderiler gonderiler);
        void update(Gonderiler gonderiler);
        List<Gonderiler> getAllList();
        List<Gonderiler> getAllListWithKategori();
        //Gonderiler getWithLastPost();
        Gonderiler getCategoryById(int id);

        List<Gonderiler> getGonderiByKategoriId(int id);


	}
}
