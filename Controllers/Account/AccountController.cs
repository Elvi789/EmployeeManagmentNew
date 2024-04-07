using EmployeeManagment.Data.UserManagement;
using EmployeeManagment.Models.AccountModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager; // klasa userManager eshte nje class e Idenity e cila na dhuron nje API qe na ben te mundur menaxhimin e userve 
        private readonly SignInManager<ApplicationUser> _signInManager; //klasa SignIn Manager eshte nje class e IDentity e cila na dhuron nje API per tu ber sign in
        private readonly ILogger _logger; //eshte nje klas e cila ekzekutohet  sa her qe ne behemi Log In

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }
        [HttpGet]
        [AllowAnonymous] //eshte nje attribute i Authorization e cila na lejon ne te therrasim metoden pa u ber Log in ne sistem
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost] //metoda qe do te kryej login ne sistem
        [AllowAnonymous] //na lejon qe ne te ekzekutojme metoden pa qen i loguar ne sistem
        [ValidateAntiForgeryToken] // eshte nje class e cila na verifikon tokenin a eshte invalid ose jo
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            // resulti si variabel ben te mundur SignIn duke i cuar si parameter emailin , passwordin , isPresiste dhe lockonfailure 
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded) //resulti kthen disa pergjigje si psh Succeded ose Failure
            {
                _logger.LogInformation("User logged in."); // me krijo nje copes te dhene kur i thua qe useri eshte loguar
                //shkruaj ne loger qe useri eshte loguar
                return RedirectToLocal(returnUrl); // me kthe metoden RedirectToLocal(me nje url)
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt."); // me krijo nje error ku i thua user qe ka problem
                //neqoftese kemi nje problem ne thirrje le ti themi userit qe eshte invalid
                return View(model); //hap serish View e Loginit me errorin perkates
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ViewBag.LastElement = "Add User";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            //var files = HttpContext.Request.Form.Files;
            //var uploadDir = _configuration["Uploads:Users"];
            //var usedFileName = await _fileHandleService.UploadAsync(files, uploadDir);
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
            };
            // variabla result theret usermanager i cili menagon userat dhe me emailin dhe passwording e marre nga view ai therret nje API te krijoje userin
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) //vaiabla result kthen disa pergjgie si Succeded dhe failure 
            {
                _logger.LogInformation("User created a new account with password."); //krijoj nje copez te dhene e cila na thot qe eshte eshte krijuar nje user  i ri


                if (User.Identity.IsAuthenticated)
                {
                    TempData["message"] = $"User {model.Email} added successfully!";
                    return RedirectToAction("Index", "Users");
                }
                else 
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }

            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View(); //kthen mbrapsh view e Login
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {

            //neqoftese URl eshte e manipuluatr atehere hap sersih view e loginit

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else  //nqs jo atehere na hy te kontrolleri dhe view Home
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
