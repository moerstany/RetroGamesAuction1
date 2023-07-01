// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.AspNetCore.Identity;

namespace RetroGamesAuction1.Areas.Identity.Pages.Account
{
    internal class ApplicationUser:IdentityUser
    {
        public string Name1 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public string PostAdress { get; set; }
    }
}