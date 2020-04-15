using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetGroupe1.Data;
using ProjetGroupe1.Model;

namespace ProjetGroupe1.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
    //    public IEnumerable<Publication> publications {get; set;}
        private readonly ApplicationDbContext _db;

        public IEnumerable<ClasPubViewModel> clasPubVM {get; set;}
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(ILogger<IndexModel> logger,
        ApplicationDbContext db,
        UserManager<IdentityUser> userManager
        )
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public async Task OnGet()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
    
            var ClasPub = await (
                from clas in _db.classe
                where clas.IdProf == user.Id

                join pub in _db.publication
                on clas.IdClasse equals pub.IdClasse
                select new {pub, clas}).ToListAsync();

            
    clasPubVM =  ClasPub.Select (

                x => new ClasPubViewModel{

                    classe = x.clas,
                    publication = x.pub
                }
            );

        }

    }

    
       public  class ClasPubViewModel {

            public Classe classe {get; set;}

            public Publication publication {get; set;}

    }

   
}


// dotnet aspnet-codegenerator identity -dc ProjetGroupe1.Data.ApplicationDbContext
