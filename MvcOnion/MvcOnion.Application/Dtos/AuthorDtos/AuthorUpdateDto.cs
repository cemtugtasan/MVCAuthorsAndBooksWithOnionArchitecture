using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.Dtos.AuthorDtos
{
    public class AuthorUpdateDto : AuthorListDto
    {
        public DateTime UpdateDate { get { return DateTime.Now; } }

    }
}
