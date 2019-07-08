using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Entity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Partner : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SiteUrl { get; set; }
        public string BannerUrl { get; set; }
        public string Address { get; set; }
    }
}
