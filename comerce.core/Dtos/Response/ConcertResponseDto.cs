using comerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Core.Dtos.Response
{
    public class ConcertResponseDto
    {
        public int Id { get; set; }
        public int IdGenre { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = default!;
        public DateTime DateEvent { get; set; }
        public string? ImageUrl { get; set; }
        public string? Place { get; set; }
        public int TicketsQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Finalized { get; set; }

        public Genre Genre { get; set; } = default!;
    }
}
