﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussme.DAL.Interfaces
{
    interface IRepository<T> where T : class
    {
        //CRUD

        //Create
        void Create(T item);

        //Read
        IEnumerable<T> ReadList();
        IEnumerable<T> FindAll(Func<T, bool> predicate);
        T ReadItemById(int id);

        //Update
        void Update(T item);

        //Delete
        void DeleteById(int id);
    }
}
