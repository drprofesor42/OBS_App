﻿using System.ComponentModel.DataAnnotations;

namespace OBS_App.Data
{
    public class Duyuru
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string DuyuruBaslik { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string DuyuruMesaj { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public DateOnly? OlusturmaTarihi { get; set; }
        public int? OgretmensId { get; set; }
        public Ogretmens? Ogretmens { get; set; }
    }
}
