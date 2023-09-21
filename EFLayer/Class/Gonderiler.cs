using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Gönderi Adı")]
        public string? GonderiName { get; set; }
        [DisplayName("Başlık")]
        public string? GonderiBaslik { get; set; }
        [DisplayName("İçerik")]
        public string? GonderiIcerik { get; set; }
        [DisplayName("Resimler")]

        public string? GonderiResim { get; set; }
        [DisplayName("Kategori Id")]

        public int? kategoriId { get; set; }
        [DisplayName("Kategori Adı")]

        public Kategories? Kategories { get; set; }
    }
}
