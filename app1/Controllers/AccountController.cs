using app1.Models;
using app1.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace app1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task< IActionResult> SaveRegister(RegisterUser_View_Model user_View_Model)
        {
            if (ModelState.IsValid == true) 
            {
                //Mapping
                ApplicationUser appuaser = new ApplicationUser();
                appuaser.UserName = user_View_Model.User_Name;
                appuaser.address = user_View_Model.Address;
                appuaser.PasswordHash = user_View_Model.Password;




                //save in database
              IdentityResult result=  await userManager.CreateAsync(appuaser, user_View_Model.Password);
                if (result.Succeeded==true) 
                {
                    //assign to role

                    await userManager.AddToRoleAsync(appuaser, "admin");
                    //cookie 
                    await signInManager.SignInAsync(appuaser, false);

                    return RedirectToAction("showall", "Department");

                }
                foreach(var error in result.Errors) 
                {
                    ModelState.AddModelError("",error.Description);
                
                
                }

            }
            
            return View("Register", user_View_Model);


        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//_RequestverificationToken
        public async Task< IActionResult> SaveLogin(Login_user_view_model LoginViewModel)
        {

            if (ModelState.IsValid == true)

            {
                //check found
               ApplicationUser applicationUser=  await userManager.FindByNameAsync(LoginViewModel.Name);

                if (applicationUser != null) 
                {
                   bool found=  await userManager.CheckPasswordAsync(applicationUser, LoginViewModel.password);

                    if (found == true) 
                    
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("addressuser", applicationUser.address));
                        //cookie
                        await signInManager.SignInWithClaimsAsync(applicationUser, LoginViewModel.RememeberMe, claims);
                        //await signInManager.SignInAsync(applicationUser, LoginViewModel.RememeberMe);
                        return RedirectToAction("showall", "Department");
                    
                    }
                
                
                }
                ModelState.AddModelError("", "Password or UserName inCorrect");
             
            //create Cookie


            }
            return View("Login",LoginViewModel);
        }

        public async Task < IActionResult> SignOut()
        {
           await signInManager.SignOutAsync();

            return View("Login");
        }
    }
}
