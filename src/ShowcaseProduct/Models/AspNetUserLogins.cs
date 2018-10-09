using System;
using System.Collections.Generic;

namespace ShowcaseProduct.Models
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public string ProviderDisplayName { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
