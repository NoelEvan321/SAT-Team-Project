using Microsoft.AspNetCore.Mvc;
using SAT_Team_Development.UI.MVC.Models;
using System.Diagnostics;
using MimeKit;
using MailKit.Net.Smtp;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace SAT_Team_Development.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }


            //Create the format for the message content we will recieve for the form
            string message = $"You have received a new email from your site's contact form!<br/>" +
                $"Sender: {cvm.Name}<br/>Email: {cvm.Email}<br />Subject: {cvm.Subject}<br/>Message: {cvm.Message}";

            //Create a MimeMessage object to assist with storing/transporting the email
            //information from the Contact form.
            var mm = new MimeMessage();

            //We can access the credentials for our email user from the appsetings.json file:
            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));

            //The recipient of this email will be our personal email address, also stored in appsettings.json
            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            //The Subject of the message will be the one provided by the user which is stored in the cvm object
            mm.Subject = cvm.Subject;

            //The body of the message will be the string we created above
            mm.Body = new TextPart("HTML") { Text = message };

            //We can set the priorty of the message as "Urgent" so it will be flagged in our email client
            mm.Priority = MessagePriority.Urgent;

            //We can also add the user's provided email address to the list of ReplyTo addresses
            //so our replies can be sent directly to them instead of to our email user
            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

            //The using directive will create the SmtpClient used to send the email
            //Once all the code inside the using directive's scope has been executed, it
            ////will close any open connections and dispose of the object for us.
            using (var client = new SmtpClient())
            {
                //Connect to the mail server using the credentials in our
                //appsettings.json
                client.Connect(_config.GetValue<string>("Credentials:Email:Client"));

                //Log into the mail server using the credentials from our email user
                client.Authenticate(
                //Username
                    _config.GetValue<string>("Credentials:Email:User"),
                    _config.GetValue<string>("Credentials:Email:Password")
                    //Password
                    );

                //It's possible the mail server may be down when  the user attempts to contact us,
                //or we may have issues in our code. So lets wrap our code to send the message in a try 
                //catch block.

                try
                {
                    //Try to send the email
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    //If there's an issue, we can store an error message in a ViewBag variable
                    //to be displayed in the View.
                    ViewBag.ErrorMessage = $"Whoops something went wrong." +
                        $"Please try again later.<br/>Error Message: {ex.StackTrace}";

                    //Return the error to the View with their form information intact
                    return View(cvm);
                }
            }

            //If all goes well, return a View that displays a confirmation to the user
            //that their email was sent

            return View("EmailConfirmation", cvm);
        }
        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}