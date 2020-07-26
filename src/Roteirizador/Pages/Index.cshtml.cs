using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Roteirizador.Domain.Models;
using Roteirizador.Domain.Repositories;
using Roteirizador.Domain.Services;

namespace Roteirizador.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUFService _ufService;
        private readonly IUFRepository _ufRepository;

        public IndexModel(ILogger<IndexModel> logger,
            IUFService ufService,
            IUFRepository ufRepository)
        {
            _logger = logger;
            _ufService = ufService;
            _ufRepository = ufRepository;
        }

        public async Task OnGet()
        {
            //UF uf = new UF(1, "SA", "São Paulo");
            await _ufService.Excluir(1);

            
        }
    }
}
