using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace WebApplication1.Pages
{   
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public int principal, terms;
        public float interest;
        public double simulation;
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

            

            
            string principaltext = Request.Query["principal"];
            string termstext = Request.Query["terms"];
            string interesttext = Request.Query["interest"];
            string simulationtext = Request.Query["simulation"];

            if(principaltext != null && termstext != null && interesttext != null && simulationtext != null)
            {
                principal = int.Parse(principaltext);
                terms = int.Parse(termstext);
                interest = float.Parse(interesttext);
                simulation = double.Parse(simulationtext);
            }else
            {
                principal = 0;
                terms = 0;
                interest = 0;
                simulation = 0;
            }
        }
    }
}