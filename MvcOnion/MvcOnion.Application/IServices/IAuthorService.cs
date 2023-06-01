using MvcOnion.Application.Dtos.AuthorDtos;
using MvcOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.IServices
{
    public interface IAuthorService
    {
        Task<bool> AuthorCreate(AuthorCreateDto authorCreateDto);

        Task<bool> AuthorUpdate(AuthorUpdateDto authorUpdateDto);

        Task<bool> AuthorDelete(int authorId);

        Task<IEnumerable<AuthorListDto>> AuthorList(Expression<Func<Author, bool>> filter = null);

        Task<AuthorCreateDto> GetByAuthorId(int authorId);

        Task<int> GetIdByAuthorNameAndLastName(string name, string lastname);
    }
}
