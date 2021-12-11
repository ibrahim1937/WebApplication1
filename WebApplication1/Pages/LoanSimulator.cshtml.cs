using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class LoanSimulatorModel : PageModel
    {
        public int pricipal { get; set; }
        public int terms { get; set; }
        public float interest { get; set; }
        public double simulation { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMilliseconds(60 * 60 * 24);


            pricipal = int.Parse(Request.Form["principal"]);
            terms = int.Parse(Request.Form["terms"]);
            interest = float.Parse(Request.Form["interest"]);
            double t = interest / 100;
            double t1 = pricipal * t / 12;
            double t2 = 1 - Math.Pow((1 + t / 12), -1 * terms);
            simulation = t1 / t2;

            Response.Cookies.Append("result", simulation + "", option);
            Response.Redirect(string.Format("/privacy?principal={0}&interest={1}&terms={2}&simulation={3}", pricipal, interest, terms, simulation));
        }
    }
}


