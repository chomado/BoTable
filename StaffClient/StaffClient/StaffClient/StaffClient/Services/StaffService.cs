using Microsoft.Azure.Documents.Client;
using StaffClient.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffClient.Services
{
    public class StaffService
    {
        private DocumentClient Client { get; }

        public StaffService(DocumentClient client)
        {
            this.Client = client;
        }
        public Task<IEnumerable<Party>> GetWaitingPartyAsync()
        {
            var result = this.Client.CreateDocumentQuery<Party>(
                UriFactory.CreateDocumentCollectionUri("store", "party"))
                .OrderByDescending(x => x.Id)
                .ToArray();
            return Task.FromResult<IEnumerable<Party>>(result);
        }
    }
}
