using DealDazzle.Business.Domain.UserModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain.UserModule.Interface
{
	public interface IUserService
	{
		Task<UserDto> RegisterUser(UserCreatedDTO request);

		//Task<UserDto> GetUser(string UserId);

		Task<UserDto> LoginUser(UserLoginDto UserId);
		Task<ApiResult<UserDto>> LogoutUser();
	}
}
