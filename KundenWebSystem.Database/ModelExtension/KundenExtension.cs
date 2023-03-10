using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenWebSystem.Database.Model
{
    partial class tbl_Kunden
    {
        [NotMapped]
        public string PasswortWiederholen { get; set; }
    }
}
