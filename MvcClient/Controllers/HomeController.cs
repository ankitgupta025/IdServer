﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        //private readonly SignInManager<IdentityUser> _signInManager;

        //public HomeController(SignInManager<IdentityUser> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

        //  [Route("/home")]
        public IActionResult Index() 
        {
            return View();
        }
        
        [Authorize]
        public async Task<IActionResult> Secret() 
        {
          
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            
            //var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
           // var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var claims = User.Claims.ToList();

            return View(claims);
        }
        //public async Task<IActionResult> SignOut(SignOutViewModel vm)
        //{
        //    if (!ModelState.IsValid)
        //        return View(vm);

        //    await _signInManager.SignOutAsync();

        //    return RedirectToAction("Index");

        //}
    }
}
