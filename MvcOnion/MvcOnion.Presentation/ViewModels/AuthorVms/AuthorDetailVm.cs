using MvcOnion.Application.Dtos.AuthorDtos;
using MvcOnion.Application.Dtos.BookDtos;

namespace MvcOnion.Presentation.ViewModels.AuthorVms
{
    public class AuthorDetailVm
    {
        public AuthorDetailVm(AuthorCreateDto authorCreateDto, List<BooklistDto> bookList)
        {
            AuthorName = authorCreateDto.FirstName;
            AuthorLastName = authorCreateDto.LastName;
            BookList = bookList;
        }

        public string AuthorName { get; set; }

        public string AuthorLastName { get; set; }

        public List<BooklistDto> BookList { get; set; }
    }
}
