﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application.Email;
using Newtonsoft.Json;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Pages
{
    
    public class IndexModel : PageModel
    {
        private readonly IEmailService _emailService;

        public IndexModel(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public void OnGet()
        {

            //_emailService.SendEmail("salam", "salam salam", "contact@atriya.com");

        }

    }
}
