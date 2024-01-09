using MongoDB.Driver;
using MongoDbCRUDapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbCRUDapp.Data
{
    internal class MongoCRUD
    {
        private IMongoDatabase db;
        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb://elliotmcintyre:bIThLyE1oVxyPP0kJMiSZvw1UOYT5eBXxFlzbz53IegDBhdA750NjxGyCCnpzfVArimUeUVqVG86ACDbsO3ELA==@elliotmcintyre.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@elliotmcintyre@");
            db = client.GetDatabase(database);
        }

        public void AddFighter(string table, Fighter fighter)
        {
            var collection = db.GetCollection<Fighter>(table);
            collection.InsertOne(fighter);
        }

        public List<Fighter> GetFighters(string table) 
        {
            var collection = db.GetCollection<Fighter>(table);
            return collection.Find(_ => true).ToList();
        }

        public Fighter GetFighterById(string table, Guid id)
        {
            var collection = db.GetCollection<Fighter>(table);
            return collection.AsQueryable().ToList().Find(x => x.Id == id);
        }

        public void UpdateFighter(string table, Fighter fighter)
        {
            var collection = db.GetCollection<Fighter>(table);

            var existingFighter = collection.Find(x => x.Id == fighter.Id).FirstOrDefault();

            if (existingFighter != null)
            {
                Console.WriteLine("Enter the new name:");
                existingFighter.Name = Console.ReadLine();
                Console.WriteLine("Enter the new fighting style:");
                existingFighter.FightingStyle = Console.ReadLine();
                Console.WriteLine("Enter the new special ability:");
                existingFighter.SpecialAbility = Console.ReadLine();

                collection.ReplaceOne(x => x.Id == fighter.Id, existingFighter);
                Console.WriteLine($"{existingFighter.Name} has been updated.");
            }
            else
            {
                Console.WriteLine("Fighter not found.");
            }

            Console.ReadKey();
        }


        public void DeleteFighter(string table, Guid id)
        {
            var collection = db.GetCollection<Fighter>(table);

            var existingFighter = collection.Find(x => x.Id == id).FirstOrDefault();

            if (existingFighter != null)
            {
                collection.DeleteOne(x => x.Id == id);
                Console.WriteLine($"{existingFighter.Name} has been deleted.");
            }
            else
            {
                Console.WriteLine("Fighter not found.");
            }

            Console.ReadKey();
        }


    }
}
