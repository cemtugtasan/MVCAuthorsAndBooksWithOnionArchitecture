using MvcOnion.Application.Dtos.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.IServices
{
    public interface IBookService
    {
        Task<bool> BookCreate(BookCreateDto bookCreateDto);

        Task<bool> BookUpdate(BookUpdateDto bookUpdateDto);

        Task<bool> BookDelete(int bookId);

        Task<List<BooklistDto>> GetBooksByAuthorId(int authorId);

        Task<bool> BookCreateRange(List<BookCreateDto> bookCreateDtos);
    }
}
