﻿using Microsoft.AspNetCore.Mvc;
using Authorization.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Authorization.Controllers
{   
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
           _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(string userrole)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(userrole))
            {
                if(await _roleManager.RoleExistsAsync(userrole))
                {
                    msg = "Role[" + userrole + "] already exists!!!";
                }
                else
                {
                    IdentityRole r= new IdentityRole(userrole);
                    await _roleManager.CreateAsync(r);
                    msg="Role["+userrole+"] has been create successfull!!!!";
                }
            }
            else
            {
                msg = "Please enter a valid role name";
            }
            ViewBag.msg = msg;
            return View("Index");

        }
        public IActionResult AssignRole()
        {
            ViewBag.users = _userManager.Users;
            ViewBag.roles= _roleManager.Roles;
            ViewBag.msg = TempData["msg"];
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> AssignRole(string userdata, string roledata)
        {
            string msg = "";
            if(!string.IsNullOrEmpty(userdata)&& !string.IsNullOrEmpty(roledata))
            {
                ApplicationUser u = await _userManager.FindByEmailAsync(userdata);
                if (u!=null)
                {
                    if(await _roleManager.RoleExistsAsync(roledata))
                    {
                        await _userManager.AddToRoleAsync(u, roledata);
                        msg = "Role has been assign to user!!!";
                    }
                }
                else
                {
                    msg = "Role User not found!!!!!";
                }
            }
            else
            {
                msg = "Please select a valid user or role!!!";
            }
            TempData["msg"]= msg;
            return RedirectToAction("AssignRole");
        }
       
    }
}
