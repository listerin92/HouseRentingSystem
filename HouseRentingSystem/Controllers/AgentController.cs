using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Extensions;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService _agents;
        public AgentController(IAgentService agents)
        {
            _agents = agents;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await _agents.ExistsById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already an Agent";
                return RedirectToAction("Index", "Home");
            }

            var model = new BecomeAgentModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _agents.ExistsById(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "Agent already exists";
                return RedirectToAction("Index", "Home");
            }

            if (await _agents.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "Phone number already exists";
                return RedirectToAction("Index", "Home");
            }

            if (await _agents.UserHasRents(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You should have no rents to become an agent!";
                return RedirectToAction("Index", "Home");
            }

            await _agents.Create(userId, model.PhoneNumber);

            return RedirectToAction("All", "House");
        }
    }
}
