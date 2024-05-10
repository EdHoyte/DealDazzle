﻿using DealDazzle.Business.Domain.ItemModule.Concrete;
using DealDazzle.Business.Domain.ItemModule.DTO;
using DealDazzle.Business.Domain.ItemModule.Interface;
using DealDazzle.Business.Domain.UserModule.DTO;
using DealDazzle.Business.Domain.UserModule.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealDazzle.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IItemService _itemService;


        public UserController(IUserService userService, IItemService itemService)
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
                Address = model.Address,
                DateOfBirth = model.Dob,
                Email = model.Email,
                FirstName = model.FirstName,
                Gender = model.Gender,
                LastName = model.LastName,
                Password = model.Password,
                Phone = model.Phone,
            };

            var response = await _userService.RegisterUser(payload);
            return View(response);
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLogin loginModel)
        {
            UserLoginDto payload = new UserLoginDto
            {
                Email = loginModel.Email,
                Password = loginModel.Password,
                RememberMe = loginModel.RememberMe
            };

            var response = await _userService.LoginUser(payload);
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }


    }
}