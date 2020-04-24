using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGroupe1.Data;
using ProjetGroupe1.Model;

namespace ProjetGroupe1.Pages.Classes
{
     [Authorize]
    public class IndexModel : PageModel
    {
       
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public IEnumerable<Classe> classes {get; set;} 

        public IndexModel (
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager
        )
        {
            _db = db;
            _userManager = userManager;
        }
        
        public async Task OnGet()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);

            classes = _db.classe.Where(m => m.IdProf == user.Id);

            
        }
    }
}
