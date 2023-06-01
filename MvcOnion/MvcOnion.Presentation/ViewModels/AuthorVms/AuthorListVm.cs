using MvcOnion.Application.Dtos.AuthorDtos;

namespace MvcOnion.Presentation.ViewModels.AuthorVms
{
    public class AuthorListVm
    {
        public AuthorListVm(AuthorListDto authorListDto)
        {
            AuthorId = authorListDto.Id;
            AuthorFirstName = authorListDto.FirstName;
            AuthorLastName = authorListDto.LastName;
        }

        public int AuthorId { get; }

        public string AuthorFirstName { get; }

        public string AuthorLastName { get; }
    }
}
