using Entity.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class PartnerUser : IdentityUser
    {
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
    }
}
