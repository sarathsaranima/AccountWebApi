using AccountWebApi.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccountWebApi.Helpers
{
    /// <summary>
    /// This is a helper class for setting up the database using some dummy data.
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// This method deletes and recreates the database file everytime the application is started.
        /// </summary>
        public static void Initialize()
        {
            string dbName = "TestDatabase.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }
            using (var dbContext = new AccountDbContext())
            {
                //Ensure database is created.
                dbContext.Database.EnsureCreated();
                if (!dbContext.Accounts.Any())
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"Helpers\Account.json");
                    if (File.Exists(path))
                    {
                        String JSONtxt = File.ReadAllText(path);
                        var accounts = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Account>>(JSONtxt);
                        foreach (var account in accounts)
                        {
                            dbContext.Accounts.Add(account);
                        }
                    }  
                }
                if (!dbContext.Transactions.Any())
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"Helpers\Transaction.json");
                    if (File.Exists(path))
                    {
                        String JSONtxt = File.ReadAllText(path);
                        var transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<AccountTransaction>>(JSONtxt);
                        foreach (var tran in transactions)
                        {
                            dbContext.Transactions.Add(tran);
                        }
                    }
                }
                // Save changes to database.
                dbContext.SaveChanges();
            }
        }
    }
}
