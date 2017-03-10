using System;
using System.Linq;
using System.Threading.Tasks;
using BoTable.Model;
using Microsoft.Azure.Documents.Client;

namespace BoTable.Services
{
    public class Registration
    {
		public Registration(DocumentClient documentClient)
        {
            this.documentClient = documentClient;
        }

        private DocumentClient documentClient;

        // 何人が待っているか返す（ことになる）
        public Task<int> GetWaitingPartyNumber(string id)
        {
            var waitingPeople = this.documentClient.CreateDocumentQuery<Party>(
                UriFactory.CreateDocumentCollectionUri(databaseId: "store", collectionId: "party")
            ).ToList()
            .OrderBy(x => x.Id)
            .ToList();

            var target = waitingPeople.FirstOrDefault(x => x.Id == id);
            if (target == null) { return Task.FromResult(-1); }

            return Task.FromResult(waitingPeople.IndexOf(target) + 1);
        }
    }
}
