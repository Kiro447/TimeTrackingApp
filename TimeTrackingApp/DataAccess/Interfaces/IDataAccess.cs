﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingAppDomain.Entities;

namespace TimeTrackingAppDataAccess.Interfaces;

public interface IDataAccess<T> where T : BaseEntity
{
    List<T> GetAll();
    T GetUserById(int id);
    int Insert(T entity);
    void UpdateUser(T user);
    void RemoveUser(int id, List<T> data);
}
