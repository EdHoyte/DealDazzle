using DealDazzle.Business.Domain.ItemModule.Concrete;
using DealDazzle.Business.Domain.ItemModule.DTO;
using DealDazzle.Business.Domain.ItemModule.Interface;
using DealDazzle.Business.Domain.UserModule.DTO;
using DealDazzle.Business.Domain.UserModule.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealDazzle.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IItemService _itemService;


        public AccountController(IUserService userService, IItemService itemService)
        {
            _userService = userService;
            _itemService = itemService;
        }

        [HttpGet]
        public async Task <ActionResult> Dashboard()
        {
            IEnumerable<ItemDTO> items = await _itemService.GetAllItems();
            return View(items);
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserDto model)
        {
            UserCreatedDTO payload = new UserCreatedDTO
            {
                
                Email = model.Email,
                FullName = model.FullName,
                Password = model.Password,
                Phone = model.Phone
            };

            var response = await _userService.RegisterUser(payload);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDto loginModel)
        {
            
            var response = await _userService.LoginUser(loginModel);
            if (string.IsNullOrEmpty(response.ErrorMessage))
                return RedirectToAction("Dashboard");

            loginModel.ErrorMessage=response.ErrorMessage;
            return View(loginModel);
        }

        [HttpGet]
        public ActionResult Login()
        {
            UserLoginDto model = new() { Password = "Roseline07011169508" };

			return View(model);
        }


    }
}
