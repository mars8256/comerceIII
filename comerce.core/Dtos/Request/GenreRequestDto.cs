using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Core.Dtos.Request
{
    public class GenreRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
