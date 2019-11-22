using CommonServiceLocator;
using SolrNet;
using SolrNet.Attributes;
using SolrNet.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrConsoleCSharp
{
    class Program
    {

        const String SolrBaseURL = "http://192.168.1.105:8983/solr";
        const String ABCoreName = "SolrASPNetCRUDv2";
        const String SolrABURL = SolrBaseURL + @"/" + ABCoreName;


        public class MyAddressBookEntry
        {
            [SolrUniqueKey("id")]
            public string id { get; set; }

            [SolrField("FirstName")]
            public string FirstName { get; set; }

            [SolrField("LastName")]
            public string LastName { get; set; }

            [SolrField("Email")]
            public string Email { get; set; }

            [SolrField("Phone")]
            public string Phone { get; set; }
        }


        static void Main(string[] args)
        {
            Startup.Init<MyAddressBookEntry>(SolrABURL);

            var mapper = new AllPropertiesMappingManager();
            mapper.SetUniqueKey(typeof(MyAddressBookEntry).GetProperty("id"));

            MyAddressBookEntry na = new MyAddressBookEntry
            {
                id = Guid.NewGuid().ToString(),
                FirstName = "FN",
                LastName = "LN",
                Email = "a@a.com",
                Phone = "1123"
            };


            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<MyAddressBookEntry>>();
            solr.Delete(new SolrQuery("*"));
            solr.Add(na);
            solr.Commit();
        }
    }
}
