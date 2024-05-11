using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain.ItemModule.DTO
{
	public class CategoryDto
	{
		public string CategoryName { get; set; }
		public List<SubCategoryDto> SubCategories { get; set; }
	}
}
