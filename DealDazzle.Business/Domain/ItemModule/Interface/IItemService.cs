using DealDazzle.Business.Domain.ItemModule.DTO;
using DealDazzle.Business.Domain.UserModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain.ItemModule.Interface
{
	public interface IItemService
	{
		Task<ItemDTO> UploadorEditItem(ItemCreateDTO payLoad);
		Task<ApiResult<ItemDTO>> DeleteItem(long id);

		Task<ItemDTO> GetItem(long id);
		Task<IEnumerable<ItemDTO>> GetAllItems();
		Task<IEnumerable<Category>> GetAllCategory();
		Task<IEnumerable<ItemDTO>> GetItemsBySubCategoryId(long id);
		Task<IEnumerable<SubCategory>> GetAllSubCategory();
		Task<IEnumerable<ItemDTO>> SearchItem(string searchTerm);


	}
}
