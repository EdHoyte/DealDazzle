using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain.ItemModule.DTO
{
    public class LandingPageDto
    {
        public BrowseCategoriesDto BrowseCategoryComponent { get; set; }
        public FilterComponent FilterComponent { get; set; }
        public ProductGrid ProductGrid { get; set; }
    }

    public class BrowseCategoriesDto
    {
        public List<CategoryDto> Categories { get; set; }=new List<CategoryDto>();
    }

    public class FilterComponent
    {
        public List<string> PriceList { get; set; } = new List<string>();
        public List<string> DateList { get; set; }= new List<string>();
    }

    public class ProductGrid
    {
        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
    }
}
