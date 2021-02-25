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

                            xr.MoveToContent();
                            while (xr.Read())
                            {
                                if (xr.NodeType == XmlNodeType.Element)
                                {

                                    if (xr.Name.Equals("String"))
                                    {

                                        Object obj = xr.GetAttribute("Value");
                                        _list.Add((T)obj);


                                    }
                                    else
                                    {
                                        var t = typeof(T);
                                        var octor = t.GetConstructors()[0];

                                        if (octor.GetParameters().Length == 0)
                                        {
                                            instance = Activator.CreateInstance(t);
                                        }

                                        if (xr.HasAttributes)
                                        {
                                            while (xr.MoveToNextAttribute())
                                            {

                                                var item = t.GetProperty( xr.Name);
                                                if ( null !=t &&item.CanWrite)
                                                {
                                                    Object obj = xr.Value;
                                                    item.SetValue(instance, obj);
                                             
                                                }

                                            }
                                            xr.MoveToElement();

                                        }
                                        _list.Add((T)instance);


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

            try
            {
                if (File.Exists(_fileName))
                {
                    File.Delete(_fileName);
                }


                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";

                using (XmlWriter sw = XmlWriter.Create(_fileName, settings))
                {

                    sw.WriteStartElement("List");

                    foreach (var item in _list)
                    {
                        sw.WriteStartElement(item.GetType().Name);
                        sw.WriteAttributeString("Value", item.ToString());

                        foreach (var prop in item.GetType().GetProperties(BindingFlags.Public))
                        {
                            sw.WriteStartElement(prop.Name);
                            sw.WriteAttributeString("Value", prop.GetValue(item).ToString());
                            sw.WriteEndElement();


                        }
                        sw.WriteEndElement();

                    }

                    sw.WriteEndElement();

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


