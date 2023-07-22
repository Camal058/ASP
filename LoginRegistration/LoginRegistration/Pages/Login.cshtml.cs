using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginRegistration.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            bool isAuthenticated = UserRepository.AuthenticateUser(Username, Password);
            if (isAuthenticated)
            {
                // Redirect to the desired page upon successful login
                Response.Redirect("/");
            }
            else
            {
                // Display an error message
                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }
        }
    }
}