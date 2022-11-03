﻿using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService _houseService;

        public HomeController(IHouseService houseService)
        {
            _houseService = houseService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _houseService.LastThreeHouse();
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}