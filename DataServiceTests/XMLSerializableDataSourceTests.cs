using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataService.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataService.UI.Tests
{
    [TestClass()]
    public class XMLSerializableDataSourceTests
    {
        [TestMethod()]
        public void XMLSerializableDataSourceTest()
        {
            IDataSource<String> ds = new XMLSerializableDataSource<String>("strings.xml");
            Assert.IsTrue(ds != null);
        }

        [TestMethod()]
        public void CreatWithValueTest()
        {
            if (File.Exists("testXML.xml"))
            {
                File.Delete("testXML.xml");
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<?xml version = \"1.0\" encoding = \"utf - 8\" ?>");
            sb.AppendLine("<List>");
            sb.AppendLine("   <String Value = \"a\" />");
            sb.AppendLine("   <String Value = \"b\" />");
            sb.AppendLine("   <String Value = \"c\" />");
            sb.AppendLine("</List>");

            File.AppendAllText("testXML.xml", sb.ToString());

            IDataSource <String> ds = new XMLSerializableDataSource<String>("testXML.xml");

            Assert.IsTrue(ds != null);
            Assert.IsTrue(ds.GetALL().GetEnumerator().MoveNext());

        }


        [TestMethod()]
        public void FileCreateText()
        {
            IDataSource<String> ds = new XMLSerializableDataSource<String>("strings.xml");
            ds.Add("String a");
            ds.Add("String b");
            ds.CommitChanges();
            Assert.IsTrue(File.Exists("strings.xml"));
        }

        [TestMethod()]
        public void AddValueTest()
        {
            IDataSource<String> ds = new XMLSerializableDataSource<String>("strings.xml");
            ds.Add("String a");
            Assert.IsTrue(ds.GetALL().GetEnumerator().MoveNext()); ;
        }

        [TestMethod()]
        public void RemoveValueTest()
        {
            IDataSource<String> ds = new XMLSerializableDataSource<String>("strings.xml");
            ds.Add("String a");
            ds.Add("String");
            Assert.IsTrue(ds.Remove("String",x =>  x.Equals("String") )!= null); ;
        }

        [TestMethod()]
        public void RecoveryValueTest()
        {
            IDataSource<String> ds = new XMLSerializableDataSource<String>("strings.xml");
            ds.Add("String a");
            ds.Add("String");
            String expected = ds.Get(x => x.Equals("String"));
            Assert.IsTrue(expected != null); ;
        }


        [TestMethod()]
        public void UpdateValueTest()
        {
            IDataSource<String> ds = new XMLSerializableDataSource<String>("strings.xml");
            ds.Add("abc");            
            ds.Update("abcde", x => x.EndsWith("bc"));
            String expected = ds.Get(x => x.EndsWith("de"));

            Assert.IsTrue(expected != null); ;
        }

        [TestMethod()]
        public void RecoveryAllValueTest()
        {
            IDataSource<String> ds = new XMLSerializableDataSource<String>("strings.xml");
            ds.Add("String a");
            ds.Add("String");

            IEnumerable<String> expected = ds.GetALL();
            Assert.IsTrue(expected != null); ;
        }

        [TestMethod()]
        public void CommitAllValues()
        {
            IDataSource<String> ds = new XMLSerializableDataSource<String>("strings.xml");

            List<String> values = new List<String> { "a","b","c" };
            ds.CommitAll(values);
            Assert.IsTrue(File.Exists("strings.xml")); ;
        }



    }
}