using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.Dtos.BookDtos
{
    public class BookUpdateDto
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public DateTime UpdateDate => DateTime.Now;
    }
}
