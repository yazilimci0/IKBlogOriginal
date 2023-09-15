using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLayer.Class
{
    public class Gonderiler
    {
        [Key]
        public int GonderiId { get; set; }
        public string? GonderiName { get; set; }
        public string? GonderiBaslik { get; set; }
        public string? GonderiIcerik { get; set; }
        public string? GonderiResim { get; set; }

        public int? kategoriId { get; set; }
        public Kategories? Kategories { get; set; }
    }
}
