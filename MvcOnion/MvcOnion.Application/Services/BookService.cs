using MvcOnion.Application.Dtos.BookDtos;
using MvcOnion.Application.IServices;
using MvcOnion.Domain.Entities;
using MvcOnion.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> BookCreate(BookCreateDto bookCreateDto)
        {
            Book book = new Book
            {
                BookName = bookCreateDto.BookName,
                CreateDate = bookCreateDto.CreateDate,
                IsActive = bookCreateDto.IsActive,
                AuthorId = bookCreateDto.AuthorId
            };

            return await _bookRepository.Create(book);
        }

        public async Task<bool> BookCreateRange(List<BookCreateDto> bookCreateDtos)
        {
            List<Book> books = bookCreateDtos.Select(x => new Book
            {
                BookName = x.BookName,
                CreateDate = x.CreateDate,
                IsActive = x.IsActive,
                AuthorId = x.AuthorId
            }).ToList();

            return await _bookRepository.CreateRange(books);
        }

        public async Task<bool> BookDelete(int bookId)
        {
            Book book = await _bookRepository.GetById(bookId);

            return await _bookRepository.Delete(book);
        }

        public async Task<bool> BookUpdate(BookUpdateDto bookUpdateDto)
        {
            Book book = await _bookRepository.GetById(bookUpdateDto.BookId);

            book.UpdateDate = bookUpdateDto.UpdateDate;
            book.BookName = bookUpdateDto.BookName;

            return await _bookRepository.Update(book);
        }

        public async Task<List<BooklistDto>> GetBooksByAuthorId(int authorId)
        {
            return _bookRepository.GetFilteredAll(x => x.AuthorId == authorId && x.IsActive).Result.Select(x => new BooklistDto
            {
                BookId = x.Id,
                BookName = x.BookName
            }).ToList();
        }
    }
}
