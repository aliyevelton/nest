﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nest.Helpers;
using Nest.Models;
using Nest.ViewModels;
using System.Data;

namespace Nest.Controllers;

public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private IConfiguration _configuration;

    public UserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {


        if (!ModelState.IsValid)
        {
            return View();
        }



        AppUser appUser = new AppUser()
        {
            FullName = registerViewModel.FullName,
            UserName = registerViewModel.Username,
            Email = registerViewModel.Email
        };
        IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerViewModel.Password);
        if (!identityResult.Succeeded)
        {
            foreach (var error in identityResult.Errors)
            {

                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        return RedirectToAction("Index", "Home");

        string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

        string link = Url.Action("ConfirmEmail", "Auth", new { email = appUser.Email, token }, HttpContext.Request.Scheme, HttpContext.Request.Host.Value);

        string body = $"<a href='{link}'>Confirm your email</a>";

        EmailHelper emailHelper = new EmailHelper(_configuration);
        await emailHelper.SendEmailAsync(new MailRequest { ToEmail = appUser.Email, Subject = "Confirm Email", Body = body });


        return RedirectToAction("Index", "Home");
    }
}
