using System;
using System.Collections.Generic;

namespace ProjexAuth_2022.Models
{
    public partial class AspNetRole
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string NormalizedName { get; set; } = null!;
        public string ConcurrencyStamp { get; set; } = null!;
    }
}