using Microsoft.EntityFrameworkCore;
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
    public class AuthorRepository : BaseRepository<Author, ApplicationDbContext>, IAuthorRepository
    {
        private readonly ApplicationDbContext context;

        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> GetIdByNameAndLastName(string name, string lastName)
        {
            Author? author = await context.Set<Author>().FirstOrDefaultAsync(x => x.IsActive && x.FirstName == name && x.LastName == lastName);

            return author!.Id;
        }
    }
}
