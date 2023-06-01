using MvcOnion.Application.Dtos.AuthorDtos;
using MvcOnion.Application.IServices;
using MvcOnion.Domain.Entities;
using MvcOnion.Domain.IRepositories;
using System.Linq.Expressions;

namespace MvcOnion.Application.Services
{
    public class AutorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AutorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<bool> AuthorCreate(AuthorCreateDto authorCreateDto)
        {
            Author author = new Author
            {
                FirstName = authorCreateDto.FirstName,
                LastName = authorCreateDto.LastName,
                CreateDate = authorCreateDto.CreateDate,
                IsActive = authorCreateDto.IsActive
            };

            return await authorRepository.Create(author);
        }

        public async Task<bool> AuthorDelete(int authorId)
        {
            Author author = await authorRepository.GetById(authorId);

            return await authorRepository.Delete(author);
        }

        public async Task<IEnumerable<AuthorListDto>> AuthorList(Expression<Func<Author, bool>> filter = null)
        {
            List<Author> authorList = authorRepository.GetFilteredAll(filter).Result.ToList();

            List<AuthorListDto> authorLists = authorList.Select(x => new AuthorListDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            return authorLists;
        }

        public async Task<bool> AuthorUpdate(AuthorUpdateDto authorUpdateDto)
        {
            Author author = await authorRepository.GetById(authorUpdateDto.Id);

            author.FirstName = authorUpdateDto.FirstName;
            author.LastName = authorUpdateDto.LastName;
            author.UpdateDate = authorUpdateDto.UpdateDate;

            return await authorRepository.Update(author);
        }

        public async Task<AuthorCreateDto> GetByAuthorId(int authorId)
        {
            Author author = await authorRepository.GetById(authorId);

            AuthorCreateDto authorCreateDto = new AuthorCreateDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return authorCreateDto;
        }

        public async Task<int> GetIdByAuthorNameAndLastName(string name, string lastname)
        {
            return await authorRepository.GetIdByNameAndLastName(name, lastname);
        }
    }
}
