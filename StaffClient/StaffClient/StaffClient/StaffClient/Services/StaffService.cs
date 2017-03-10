using Microsoft.Azure.Documents;
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
                .ToArray()
                .OrderByDescending(x => x.Id);
            return Task.FromResult<IEnumerable<Party>>(result);
        }

        public Task<IEnumerable<Sheet>> GetSheetsByStatus(SheetStatus status)
        {
            var result = this.Client.CreateDocumentQuery<Sheet>(
                UriFactory.CreateDocumentCollectionUri("store", "sheet"))
                .ToArray()
                .Where(x => x.Status == status);
            return Task.FromResult(result);
        }

        public async Task DeletePartyByIdAsync(int id)
        {
            var party = this.Client.CreateDocumentQuery(
                UriFactory.CreateDocumentCollectionUri("store", "party"))
                .ToArray()
                .FirstOrDefault(x => ((dynamic)x).Id == id.ToString());
            await this.Client.DeleteDocumentAsync(party.SelfLink, 
                new RequestOptions { PartitionKey = new PartitionKey(party.Id) });
        }

        public async Task UpdateSheetAsync(Sheet sheet)
        {
            var status = this.Client.CreateDocumentQuery(
                UriFactory.CreateDocumentCollectionUri("store", "sheet"))
                .ToArray()
                .First(x => ((dynamic)x).Id == sheet.Id.ToString());
            status.SetPropertyValue("status", sheet.Status);
            await this.Client.ReplaceDocumentAsync(status);
        }
    }
}
