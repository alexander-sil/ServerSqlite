using System;
using Server.Data;
using Server.Data.Models;

namespace Server.Repos
{
    public interface IEntryRepository
    {
        EntryDbContext _context { get; set; }

        public int Create(Entry data);

        public bool BindNewBorrower(int id, Person borrower);

        public bool UpdateBorrowerName(int id, string expression, string newName);

        public bool UpdateBorrowerClass(int id, string expression, string className);

        public bool UpdateBorrowerBuilding(int id, string expression, string building);

        public bool UnbindBorrower(int entryId, string expression);

        public Entry GetById(int id);

        public List<Entry> GetAll();

        public List<Entry> Search(string seacrhTerm);

        public bool UpdateState(int id, string state);

        public bool UpdateName(int id, string name);

        public bool UpdateQuantity(int id, uint quantity);

        public bool UpdateUnit(int id, string unit);

        public bool UpdateDescription(int id, string description);

        public bool UpdateOwner(int id, string owner);

        public bool Delete(int id);
    }
}

