using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;

namespace DataService
{
    public class XMLSerializableDataSource<T> : IDataSource<T>
    {

        private List<T> _list = new List<T>();
        private String _fileName;


        public XMLSerializableDataSource(String fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader sr = File.OpenText(fileName))
                    {
                        using (XmlReader xr = XmlReader.Create(sr))
                        {
                            Object instance = null;
                            if (xr.HasValue)
                            {
                                xr.MoveToContent();
                                xr.MoveToFirstAttribute();
                                while (xr.Read())
                                {
                                    String propertyName = xr.Name;
                                    Object propertyValue = xr.Value;
                                    while (xr.HasAttributes)
                                    {

                                        var t = typeof(T);
                                        var octor = t.GetConstructors()[0];

                                        if (octor.GetParameters().Length == 0)
                                        {
                                            instance = Activator.CreateInstance(t);
                                        }

                                        var members = t.GetProperties(BindingFlags.DeclaredOnly);
                                        var item = t.GetProperty(propertyName, BindingFlags.DeclaredOnly);
                                        if (item.CanWrite)
                                        {
                                            item.SetValue(instance, propertyName);
                                        }

                                        xr.MoveToNextAttribute();
                                        propertyName = xr.Name;
                                        propertyValue = xr.Value;

                                    }


                                }
                            }
                        }


                    }
                }
                catch (Exception x)
                {
                    Debug.Write(x);
                    throw;
                }



            }

            _fileName = fileName;
        }

        private void SerializeAll()
        {

            XmlSerializer ser = new XmlSerializer(typeof(T));

            try
            {
                if (File.Exists(_fileName))
                {
                    File.Delete(_fileName);
                }

                using StreamWriter sw = File.CreateText(_fileName);
                foreach (T item in _list)
                {
                    ser.Serialize(sw, item);
                }

            }
            catch (Exception x)
            {
                Debug.Write(x);
                throw;
            }

        }

        public void Add(T value)
        {
            _list.Add(value);

        }

        public T Get(Predicate<T> key)
        {
            return _list.Find(key);
        }

        public IEnumerable<T> GetALL()
        {
            return _list;
        }

        public T Remove(T value, Predicate<T> key)
        {

            if (_list.Remove(value))
            {

                return value;
            }
            else
            {
                return default;
            }

        }

        public T Update(T value, Predicate<T> key)
        {
            T val = _list.Find(key);
            if (val != null)
            {
                _list.Remove(val);
                _list.Add(value);
            }
            return val;
        }

        public void CommitAll(IEnumerable<T> all)
        {
            _list.AddRange(all);
            SerializeAll();
        }

        public void CommitChanges()
        {
            SerializeAll();
        }

    }
}


