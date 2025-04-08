using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.DataAccess.Context;
using Test4.DataAccess.Entityes;

namespace Test4.Data
{
    class DbInitializer
    {
        private readonly Test4DB _db;
        private readonly ILogger<DbInitializer> _Logger;

        public DbInitializer(Test4DB db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Ініціювання БД...");

            _Logger.LogInformation("Видалення існуючої БД...");
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            _Logger.LogInformation("Видалення існуючої БД виконано за {0} мс", timer.ElapsedMilliseconds);


            _Logger.LogInformation("Міграція БД...");
            await _db.Database.MigrateAsync();
            _Logger.LogInformation("Міграція БД виконано за {0} мс", timer.ElapsedMilliseconds);

            if (await _db.Customers.AnyAsync()) return;

            await InitializeAccountants();
            await InitializeReports();
            await InitializeCustomers();

            _Logger.LogInformation("Ініціювання БД виконано за {0} с", timer.Elapsed.TotalSeconds);
        }

        private const int __AccountantsCount = 10;

        private Accountant[] _Accountants;
        private async Task InitializeAccountants()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Ініціювання бухгалтерів...");

            _Accountants = Enumerable.Range(1, __AccountantsCount)
                .Select(i => new Accountant { Name = $"Бухглатер {i + 1}", Surname = $"Прізвище {i + 1}" })
                .ToArray();

            await _db.Accountants.AddRangeAsync(_Accountants);
            await _db.SaveChangesAsync();


            _Logger.LogInformation("Ініціювання бухгалтерів виконано за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int __CustomersCount = 10;

        private Customer[] _Customers;

        private async Task InitializeCustomers()
        {
            _Customers = new Customer[__CustomersCount];
            var rnd = new Random();

            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Ініціювання клієнтів...");

            for (var i = 0; i < __CustomersCount; i++)
            {
                _Customers[i] = new Customer
                {
                    Name = $"Клієнт {i + 1}",
                    Surname = $"Прізвище {i + 1}",
                    Accountant = rnd.NextItem(_Accountants)
                };
            }

            await _db.Customers.AddRangeAsync(_Customers);
            await _db.SaveChangesAsync();

            _Logger.LogInformation("Ініціювання клієнтів виконано за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int __ReportsCount = 10;

        private Report[] _Reports;

        private async Task InitializeReports()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Ініціювання звітів...");

            _Reports = Enumerable.Range(1, __ReportsCount)
                    .Select(i => new Report { Name = $"Звіт {i + 1}" })
                    .ToArray();

            await _db.Reports.AddRangeAsync(_Reports);
            await _db.SaveChangesAsync();

            _Logger.LogInformation("Ініціювання звітів виконано за {0} мс", timer.ElapsedMilliseconds);

        }
    }
}
