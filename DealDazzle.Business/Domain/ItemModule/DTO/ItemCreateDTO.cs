using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain.ItemModule.DTO
{
    public class ItemCreateDTO
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int SubCategoryId { get; set; }
		public List<CreateItemImageDto> Images { get; set; } = new List<CreateItemImageDto>();
	}
}
