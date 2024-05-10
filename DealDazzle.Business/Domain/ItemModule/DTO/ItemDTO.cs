using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain.ItemModule.DTO
{
    public class ItemDTO
	{
        public string UserId { get; set; }
        public string ItemName { get; set; }
        public decimal Price {  get; set; }
        public string Description { get; set; }
        public string SubCategory {  get; set; }
        public byte[] Images { get; set; }
    }
}
