using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class RoleViewModel 
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }
    }
}
