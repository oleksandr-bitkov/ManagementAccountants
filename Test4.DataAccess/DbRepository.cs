using Microsoft.EntityFrameworkCore;
using Test4.DataAccess.Context;
using Test4.DataAccess.Entityes;
using Test4.DataAccess.Entityes.Base;
using Test4.Interfaces;

namespace Test4.DataAccess
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly Test4DB _db;
        private readonly DbSet<T> _Set;
        public bool AutoSaveChanges { get; set; } = true;
        public DbRepository(Test4DB db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _Set;
        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);


        public async Task<T> GetAsync(int id, CancellationToken Cancel = default) => await Items
            .SingleOrDefaultAsync(item => item.Id == id, Cancel)
            .ConfigureAwait(false);
        public T Add(T item)
        {
            if (item is null) throw new ArgumentException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                _db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _db.SaveChanges();

        }

        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public void Remove(int id)
        {

            _db.Remove(new T { Id = id });

            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new T { Id = id });

            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }

    class AccountantRepository : DbRepository<Accountant>
    {
        public override IQueryable<Accountant> Items => base.Items.Include(item => item.Customers);
        public AccountantRepository(Test4DB db) : base(db)
        {
        }
    }

    class CustomerRepository : DbRepository<Customer>
    {
        public override IQueryable<Customer> Items => base.Items
            .Include(item => item.Accountant)
            .Include(item => item.Reports);
        public CustomerRepository(Test4DB db) : base(db)
        {
        }
    }

    class ReportRepository : DbRepository<Report>
    {
        public override IQueryable<Report> Items => base.Items
            .Include(item => item.Customers);
        public ReportRepository(Test4DB db) : base(db)
        {
        }
    }
}
