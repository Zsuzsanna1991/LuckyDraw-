using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LuckyDraw.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string nyeremeny { get; set; } = "";

        public string message { get; set; } = "";

        public string kepUrl { get; set; } = "/images/question_mark.webp";


        Random random = new Random();

        public int generaltSzam { get; set; }

        public void OnPost()
        {
            message = "";
            nyeremeny = "";

            bool foNyeremenyElkelt = HttpContext.Session.GetString("FoNyeremeny") == "igen";

            bool marSorsolt = HttpContext.Session.GetString("MarSorsolt") == "igen";

            if (marSorsolt)
            {
                message = "Ezen a nyereményjátékon már sorsoltál.";
                kepUrl = "/images/smiley2.webp";
                return;
            }

            generaltSzam = random.Next(1, 101);

             HttpContext.Session.SetString("MarSorsolt", "igen");
           

            if (generaltSzam == 56 && foNyeremenyElkelt == false)
            {
                nyeremeny = "egy kétszemélyes utazás";

                kepUrl = "/images/utazas2.webp";

                HttpContext.Session.SetString("FoNyeremeny", "igen");

            }
            else if (generaltSzam == 56 && foNyeremenyElkelt == true)
            {
                message = "A főnyereményt már elvitték";
            }
            else if (generaltSzam <= 20)
            {
                nyeremeny = "egy kulacs";
                kepUrl = "/images/kulacs.webp";

                
            }
            else if (generaltSzam <= 40)
            {
                nyeremeny = "egy túrabot";
                kepUrl = "/images/turabot.webp";
            }
            else if (generaltSzam <= 55)
            {
                nyeremeny = "egy bögre";
                kepUrl = "/images/bogre.webp";
            }
            else if (generaltSzam >= 57 && generaltSzam <= 65)
            {
                nyeremeny = "egy túratáska";
                kepUrl = "/images/bag.webp";
            }
            else if (generaltSzam <= 85)
            {
                nyeremeny = "egy hálózsák";
                kepUrl = "/images/halozsak.webp";
            }
            else if (generaltSzam <= 100)
            {
                nyeremeny = "egy sátor";
                kepUrl = "/images/sator.webp";
            }
        }
        

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}
