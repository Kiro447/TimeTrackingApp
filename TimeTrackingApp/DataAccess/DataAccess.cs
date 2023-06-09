﻿using Newtonsoft.Json;
using TimeTrackingAppDataAccess.Interfaces;
using TimeTrackingAppDomain.Entities;

namespace TimeTrackingAppDataAccess;

public class DataAccess<T> : IDataAccess<T> where T : BaseEntity
{
    private readonly string _dbDirectory;
    private readonly string _dbFile;

    private List<T> dataB;
    private int _IdCount { get; set; }

    public DataAccess()
    {
        _dbDirectory = $@"..\..\..\Database\";
        _dbFile = $@"{_dbDirectory} {typeof(T)}s.json";

        if (!Directory.Exists(_dbDirectory))
        {
            Directory.CreateDirectory(_dbDirectory);
        }

        if (!File.Exists(_dbFile))
        {
            File.Create(_dbFile).Close();
        }

        dataB = Read();

        if (dataB == null)
        {
            Write(new List<T>());
        }

        _IdCount = 1;
    }

    private List<T> Read()
    {
        try
        {
            using (StreamReader sr = new StreamReader(_dbFile))
            {
                string content = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return null;
        }
    }

    private bool Write(List<T> entities)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(_dbFile))
            {
                string content = JsonConvert.SerializeObject(entities, Formatting.Indented);
                sw.Write(content);
            }
            return true;
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public List<T> GetAll()
    {
        return Read();
    }

    public T GetUserById(int id)
    {
        List<T> dataB = Read();
        return dataB.FirstOrDefault(u => u.Id == id);
    }

    public int Insert(T entity)
    {
        List<T> dataB = Read();
        if (dataB.Count == 0)
        {
            entity.Id = _IdCount;
            _IdCount++;
        }
        else if (dataB.Count > 0)
        {
            _IdCount = dataB.Count + 1;
            entity.Id = _IdCount;
        }

        dataB.Add(entity);
        Write(dataB);
        return entity.Id;
    }

    public void UpdateUser(T entity)
    {
        List<T> dataB = Read();
        T item = dataB.FirstOrDefault(x => x.Id == entity.Id);
        var index = dataB.IndexOf(item);
        RemoveUser(item.Id, dataB);
        item = entity;
        dataB.Insert(index, item);
        Write(dataB);
    }

    public void RemoveUser(int id, List<T> data)
    {
        //List<T> dataB = Read();
        T entity = data.FirstOrDefault(e => e.Id == id);
        data.RemoveAll(x => x.Id == entity.Id);
        Write(data);
    }

    public void ClearDb()
    {
        Write(new List<T>());
    }
}