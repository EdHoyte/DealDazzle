using DealDazzle.Business.Domain.ItemModule.DTO;
using DealDazzle.Business.Domain.ItemModule.Interface;
using DealDazzle.Business.Domain.UserModule.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain.ItemModule.Concrete
{
	public class ItemService : IItemService
	{
		private static HttpClient _client;

		public ItemService(HttpClient httpClient)
		{
			_client = httpClient;
		}

		#region Items
		public async Task<ApiResult<ItemDTO>> DeleteItem(long id)
		{
			var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7266/api/Item/delete-item/{id}");
			var response = await _client.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<ApiResult<ItemDTO>>(json);
		}

		public async Task<IEnumerable<ItemDTO>> GetAllItems()
		{
			IEnumerable<ItemDTO> Items = new List<ItemDTO>();

			var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7266/api/Item/get-items");
			var response = await _client.SendAsync(request);
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

			var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<IEnumerable<ItemDTO>>>(json);
			if (result.StatusCode == System.Net.HttpStatusCode.OK)
			{
				Items = result.Result;
			}
			return Items;
		}

		public async Task<ItemDTO> GetItem(long id)
		{
			var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7266/api/Item/get-item-by-id/{id}");
			var response = await _client.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<ApiResult<ItemDTO>>(json);
			return result.Result;
		}

		public async Task<IEnumerable<ItemDTO>> GetItemsBySubCategoryId(long id)
		{
			IEnumerable<ItemDTO> Items = new List<ItemDTO>();

			var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7266/api/Item/get-items-by-subcategory/{id}");
			var response = await _client.SendAsync(request);
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

			var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<IEnumerable<ItemDTO>>>(json);
			if (result.StatusCode == System.Net.HttpStatusCode.OK)
			{
				Items = result.Result;
			}
			return Items;
		}

		public async Task<IEnumerable<ItemDTO>> SearchItem(string searchTerm)
		{
			IEnumerable<ItemDTO> Items = new List<ItemDTO>();

			var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7266/api/Item/search/{searchTerm}");
			var response = await _client.SendAsync(request);
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

			var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<IEnumerable<ItemDTO>>>(json);
			if (result.StatusCode == System.Net.HttpStatusCode.OK)
			{
				Items = result.Result;
			}
			return Items;
		}

		public async Task<ItemDTO> UploadorEditItem(ItemCreateDTO payLoad)
		{
			var content = new StringContent(JsonConvert.SerializeObject(payLoad), Encoding.UTF8, "application/json");
			var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7266/api/Account/create-item");
			request.Content = content;
			var response = await _client.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<ApiResult<ItemDTO>>(json);
			return result.Result;
		}
#endregion

		#region SubCategory
		public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategory()
		{

			IEnumerable<SubCategoryDto> Items = new List<SubCategoryDto>();

			var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7266/api/Item/get-subcategories");
			var response = await _client.SendAsync(request);
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

			var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<IEnumerable<SubCategoryDto>>>(json);
			if (result.StatusCode == System.Net.HttpStatusCode.OK)
			{
				Items = result.Result;
			}
			return Items;

		
		}
		
		#endregion

		#region Category
		public async Task<IEnumerable<CategoryDto>> GetAllCategory()
		{

			IEnumerable<CategoryDto> Items = new List<CategoryDto>();

			var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7266/api/Item/get-categories");
			var response = await _client.SendAsync(request);
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

			var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<IEnumerable<CategoryDto>>>(json);
			if (result.StatusCode == System.Net.HttpStatusCode.OK)
			{
				Items = result.Result;
			}
			return Items;
		}
		#endregion

	}
}
