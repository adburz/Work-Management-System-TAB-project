﻿using System.Collections.Generic;

namespace WorkManagementSystemTAB.Services
{
    public interface IService<T1, T2> where T1 : class
    {
        public IEnumerable<T1> GetAll();
        public T1 GetById(T2 id);
        public T1 Add(T1 entity);
        public void Delete(T2 id);
    }
}
