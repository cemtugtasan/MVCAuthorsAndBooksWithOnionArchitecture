using MvcOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Domain.IRepositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<int> GetIdByNameAndLastName(string name, string lastName);
    }
}
