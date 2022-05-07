using n5now.Services;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n5now.Tests.ServicesTest
{
    public class ESClientProviderFake: IESClientProvider
    {
        
        private ElasticClient _client;

        public ESClientProviderFake()
        {

        }

        public ElasticClient GetClient()
        {
            if (_client != null)
                return _client;
            InitClient();
            return _client;
        }

        private void InitClient()
        {
            var node = new Uri("http://localhost:9201/");
            _client = new ElasticClient(new ConnectionSettings(node).DefaultIndex("demo"));
        }
    }
}
