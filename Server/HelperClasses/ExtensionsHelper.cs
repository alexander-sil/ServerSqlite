using Server.Data.Models;
using Server.Models;
using System;

namespace Server.HelperClasses
{
    public static class ExtensionsHelper
    {
        public static EntryOutModel ToEntryOutModel(this Entry entry)
        {
            List<Person> people = entry.BorrowingPeople;
            List<PersonOutModel> tempList = new List<PersonOutModel>();

            foreach (Person item in people)
            {
                tempList.Add(item.ToPersonOutModel());
            }

            return new EntryOutModel()
            {
                BorrowingPeople = tempList,
                Description = entry.Description,
                Id = entry.Id,
                Name = entry.Name,
                Owner = entry.Owner,
                Quantity = entry.Quantity,
                State = entry.State,
                Unit = entry.Unit
            };
        }

        public static IEnumerable<EntryOutModel> ToEntryOutModelBulk(this List<Entry> entries)
        {
            foreach (Entry entry in entries)
            {
                List<Person> people = entry.BorrowingPeople;
                List<PersonOutModel> tempList = new List<PersonOutModel>();

                foreach (Person item in people)
                {
                    tempList.Add(item.ToPersonOutModel());
                }

                yield return new EntryOutModel()
                {
                    BorrowingPeople = tempList,
                    Description = entry.Description,
                    Id = entry.Id,
                    Name = entry.Name,
                    Owner = entry.Owner,
                    Quantity = entry.Quantity,
                    State = entry.State,
                    Unit = entry.Unit
                };
            }
        }

        public static PersonOutModel ToPersonOutModel(this Person person)
        {
            return new PersonOutModel()
            {
                Building = person.Building,
                Class = person.Class,
                Id = person.Id,
                Name = person.Name
            };
        }

        public static Entry ToEntryDBModel(this EntryInModel entry)
        {
            return new Entry()
            {
                Description = entry.Description,
                Name = entry.Name,
                Owner = entry.Owner,
                Quantity = entry.Quantity,
                State = entry.State,
                Unit = entry.Unit
            };
        }

        public static Person ToPersonDBModel(this PersonInModel person)
        {
            return new Person()
            {
                Name = person.Name,
                Building = person.Building,
                Class = person.Class
            };
        }
    }
}

