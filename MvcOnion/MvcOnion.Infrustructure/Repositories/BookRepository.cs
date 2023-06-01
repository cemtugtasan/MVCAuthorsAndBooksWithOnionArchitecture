using MvcOnion.Domain.Entities;
using MvcOnion.Domain.IRepositories;
using MvcOnion.Infrustructure.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Infrustructure.Repositories
{
    public class BookRepository : BaseRepository<Book, ApplicationDbContext>, IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }

        public async Task<bool> CreateRange(List<Book> books)
        {
            await _db.AddRangeAsync(books);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
