using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleLoginAssignment.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string Msg;

        public void OnGet()
        {

        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }

        public IActionResult OnPost()
        {
            
            if(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                Msg = "Please Enter Credentials To Gain Access...!";
                return Page();
            }
            else if (Username.Equals("wani") && Password.Equals("1234"))
            {
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("Welcome");
            }
            else if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Msg = "Please Enter Credentials To Gain Access...!";
                return Page();
            }

            else
            {
                Msg = "Please Enter Valid Credentias";
                return Page();

            }

        }
    }
}