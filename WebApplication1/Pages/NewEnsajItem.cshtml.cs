using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class NewEnsajItemModel : PageModel
    {

        String operation;
        public int number1;
        public int number2;
        public int result = 0;
        //public String resultString = "";
        //public String resultString2 = "";

        public void OnGet()
        {
        }

        
        public void OnPost()
        {

            operation = Request.Form["operation"];
            number1 = int.Parse(Request.Form["number1"]);
            number2 = int.Parse(Request.Form["number2"]);
            int max, min;

            int number;

            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddMilliseconds(60 * 60 * 24);

            if (String.Equals(operation, "max"))
            {
                number = number1 > number2 ? number1 : number2;
                int number_2 = number1 < number2 ? number1 : number2;
                //resultString = $"The max number is {number}";
                //resultString2 = $"The min number is {number_2}";

                max = number;
                min = number_2;

                this.result = number;

              
            }
            else
            {
                number = number2 < number1 ? number2 : number1;
                int number_2 = number2 > number1 ? number2 : number1;
                //resultString = $"The min number is {number}";
                //resultString2 = $"The max number is {number_2}";

                min = number;
                max = number_2;

                this.result = number;

            }




            Response.Cookies.Append("max", max + "", option);
            Response.Cookies.Append("min", min + "", option);
            Response.Cookies.Append("result", number + "", option);
            Response.Redirect(string.Format("/privacy?max={0}&min={1}", max, min));






        }
    }
}
