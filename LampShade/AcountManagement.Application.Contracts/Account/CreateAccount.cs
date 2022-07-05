﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contracts.Account
{
    public class CreateAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get;set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string UserName { get;set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get;set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get;set; }

        [Range(1,int.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleId { get;set; }
        [MaxFileSize(3 * 1024 * 1024 ,ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile ProfilePhoto { get;set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}
