using System.ComponentModel.DataAnnotations;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace LoginRegistration.Pages;

public class RegistrationModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            User user = new User
            {
                Username = Username,
                Email = Email,
                PasswordHash = Password
            };

            bool isRegistered = UserRepository.RegisterUser(user);
            if (isRegistered)
            {
                // Redirect to the login page upon successful registration
                Response.Redirect("/Login");
            }
            else
            {
                // Display an error message
                ModelState.AddModelError(string.Empty, "Username already exists");
            }
        }
    }
}