using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.DtoModels
{
    public class CharacteristicDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid ProductId { get; set; }

    }
}
