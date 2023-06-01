using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.Dtos.BookDtos
{
    public class BookCreateDto
    {
        public string BookName { get; set; }

        public DateTime CreateDate => DateTime.Now;

        public bool IsActive => true;

        public int AuthorId { get; set; }
    }
}
