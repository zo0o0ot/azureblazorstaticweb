using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public interface IDraftData
    {
        Task<Draft> AddDraft(Draft draft);
        Task<bool> DeleteDraft(int id);
        Task<IEnumerable<Draft>> GetDrafts();
        Task<Draft> UpdateDraft(Draft draft);
    }

    public class DraftData : IDraftData
    {
        private readonly List<Draft> drafts = new List<Draft>
        {
            new Draft
            {
                Id = 10,
                Name = "Super Awesome Fun",
                Participants = "Tilo, AJ, Ross",
                PlayersDrafted = 0,
                Sport = "Fantasy Football"
            },
            new Draft
            {
                Id = 20,
                Name = "Leagify",
                Participants = "Tilo, AJ, Jared, Ross",
                PlayersDrafted = 0,
                Sport = "Fantasy NFL Draft"
            },
            new Draft
            {
                Id = 30,
                Name = "Rings",
                Participants = "Tilo, AJ, Ross",
                PlayersDrafted = 0,
                Sport = "Fantasy Olympics"
            }
        };

        private int GetRandomInt()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        public Task<Draft> AddDraft(Draft draft)
        {
            draft.Id = GetRandomInt();
            drafts.Add(draft);
            return Task.FromResult(draft);
        }

        public Task<Draft> UpdateDraft(Draft draft)
        {
            var index = drafts.FindIndex(p => p.Id == draft.Id);
            drafts[index] = draft;
            return Task.FromResult(draft);
        }

        public Task<bool> DeleteDraft(int id)
        {
            var index = drafts.FindIndex(p => p.Id == id);
            drafts.RemoveAt(index);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Draft>> GetDrafts()
        {
            return Task.FromResult(drafts.AsEnumerable());
        }
    }
}
