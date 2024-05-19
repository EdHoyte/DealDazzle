using DealDazzle.Business.Domain.ItemModule.DTO;
using DealDazzle.Business.Domain.UserModule.DTO;
using DealDazzle.Business.Domain.UserModule.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain.UserModule.Concrete
{
	public class UserService : IUserService
	{

		private static HttpClient _client;

		public UserService(HttpClient httpClient)
		{
			_client = httpClient;
		}


		//public async Task<UserDto> GetUser(string UserId)
		//{
		//	var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7056/api/Movies/get-movie-by-id/{UserId}");
		//	var response = await _client.SendAsync(request);
		//	var json = await response.Content.ReadAsStringAsync();

		//	var result = JsonConvert.DeserializeObject<ApiResult<UserDto>>(json);
		//	return result.Result;
		//}

		public async Task<UserDto> LoginUser(UserLoginDto userData)
		{
			UserDto result = new UserDto();

			var content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
			var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7266/api/Account/login");
			request.Content = content;
			var response = await _client.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				result = JsonConvert.DeserializeObject<ApiResult<UserDto>>(json).Result;
				return result;
			}
			if(response.StatusCode== System.Net.HttpStatusCode.InternalServerError) 
			{
				result.ErrorMessage = "The remote service returned an error";
			}

			return result;
		}

		public async Task<ApiResult<UserDto>> LogoutUser()
		{
			var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7266/api/Account/logout");
			var response = await _client.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<ApiResult<UserDto>>(json);
		}

		public async Task<UserDto> RegisterUser(UserCreatedDTO payload)
		{
			var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
			var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7266/api/Account/create-user");
			request.Content = content;
			var response = await _client.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<ApiResult<UserDto>>(json);
			return result.Result;
		}
	}
}
