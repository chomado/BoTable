using BoTable.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoTable.Model
{
    public class PartyInfo : BindableBase
    {
        private Registration Registration { get; }

        private string id;

        public string Id
        {
            get { return this.id; }
            set { this.SetProperty(ref this.id, value); }
        }

        private int partyCount;

        public int PartyCount
        {
            get { return this.partyCount; }
            set 
            { 
                this.SetProperty(ref this.partyCount, value); 
                this.OnPropertyChanged(nameof(PartyCountMessage));
                this.OnPropertyChanged(nameof(PartyCountMessageEn));
            }
        }

        private int waitingMinutes;

        public int WaitingMinutes
        {
            get { return this.waitingMinutes; }
            set 
            { 
                this.SetProperty(ref this.waitingMinutes, value); 
                this.OnPropertyChanged(nameof(WaitingMinutesMessage));
				this.OnPropertyChanged(nameof(WaitingMinutesMessageEn)); 
            }
        }

		public string PartyCountMessage => this.PartyCount == -1 ? "お客様は登録されていません" : $"あなたは {this.PartyCount} 組目です";
        public string PartyCountMessageEn => this.PartyCount == -1 ? "You are not registered yet." : $"You are {this.PartyCount}{OrderingWord(this.partyCount)} party.";

		public string WaitingMinutesMessage => this.PartyCount == -1 ? "" : $"だいたい {this.WaitingMinutes} 分待ちです";
        public string WaitingMinutesMessageEn => this.PartyCount == -1 ? "" : $"About {this.WaitingMinutes} min wait";

        private string OrderingWord(int number)
        {
			if (number == 1) return "st";
			if (number == 2) return "nd";
            if (number == 3) return "rd";
            return "th";
        }

        public PartyInfo(Registration registration)
        {
            this.Registration = registration;
        }

        public async Task UpdateAsync()
        {
            var count = await this.Registration.GetWaitingPartyNumber(this.Id);
            this.PartyCount = count;
            this.WaitingMinutes = count * 8;
        }
    }
}
