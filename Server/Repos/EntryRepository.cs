using Server.Data.Models;
using Server.Data;
using System;
using System.Collections.Generic;

namespace Server.Repos
{
    public class EntryRepository : IEntryRepository
    {
        public EntryDbContext _context { get; set; }

        public EntryRepository(EntryDbContext context)
        {
            _context = context;
        }

        public int Create(Entry data)
        {
            _context.Entries.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public bool BindNewBorrower(int id, Person borrower)
        {
            Entry entry = _context.Entries.FirstOrDefault(f => f.Id == id);

            if (entry != null)
            {
                entry.BorrowingPeople.Add(borrower);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateBorrowerName(int id, string expression, string newName)
        {
            Entry entry = _context.Entries.FirstOrDefault(f => f.Id == id);
            Person person = entry.BorrowingPeople.FirstOrDefault(f => f.Name.Contains(expression));

            if (entry != null && person != null)
            {
                person.Name = newName;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateBorrowerClass(int id, string expression, string className)
        {
            Entry entry = _context.Entries.FirstOrDefault(f => f.Id == id);
            Person borrower = entry.BorrowingPeople.FirstOrDefault(f => f.Class.Contains(expression));

            if (entry != null && borrower != null)
            {
                borrower.Class = className;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateBorrowerBuilding(int id, string expression, string building)
        {
            Entry entry = _context.Entries.FirstOrDefault(f => f.Id == id);
            Person borrower = entry.BorrowingPeople.FirstOrDefault(f => f.Building.Contains(expression));

            if (entry != null && borrower != null)
            {
                borrower.Building = building;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UnbindBorrower(int entryId, string expression)
        {
            Entry entry = _context.Entries.FirstOrDefault(f => f.Id == entryId);
            Person borrower = _context.People.FirstOrDefault(f => f.Name.Contains(expression));

            if (entry != null && borrower != null)
            {
                entry.BorrowingPeople.Remove(borrower);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Entry GetById(int id)
        {
            return _context.Entries.FirstOrDefault(f => f.Id == id);
        }

        public List<Entry> GetAll()
        {
            return _context.Entries.ToList();
        }

        public List<Entry> Search(string seacrhTerm)
        {
            return _context.Entries.ToList().Where(f => f.Name.Contains(seacrhTerm)).ToList();
        }

        public bool UpdateState(int id, string state)
        {
            Entry entry = GetById(id);

            if (entry != null)
            {
                entry.State = state;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateName(int id, string name)
        {
            Entry entry = GetById(id);

            if (entry != null)
            {
                entry.Name = name;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateQuantity(int id, uint quantity)
        {
            Entry entry = GetById(id);

            if (entry != null)
            {
                entry.Quantity = quantity;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUnit(int id, string unit)
        {
            Entry entry = GetById(id);

            if (entry != null)
            {
                entry.Unit = unit;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateDescription(int id, string description)
        {
            Entry entry = GetById(id);

            if (entry != null)
            {
                entry.Description = description;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateOwner(int id, string owner)
        {
            Entry entry = GetById(id);

            if (entry != null)
            {
                entry.Owner = owner;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            Entry entry = GetById(id);

            if ((entry != null) && (entry.BorrowingPeople.Count < 1))
            {
                _context.Entries.Remove(entry);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

