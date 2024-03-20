﻿using System.ComponentModel.DataAnnotations;
namespace OBS_App.Areas.Admin.ViewsModel
{
    public class SifreDegistirViewsModel
    {
        [DataType(DataType.EmailAddress)]
        public string? Eposta { get; set; }

		[Required(ErrorMessage = "*Zorunlu Alan")]
		[DataType(DataType.Password)]
        public string? Parola { get; set; }

		//Confirm Parola için onay 

		[Required(ErrorMessage = "*Zorunlu Alan")]
		[DataType(DataType.Password)]
        [Compare(nameof(Parola), ErrorMessage = "Parola eşleşmiyor.")]
        public string? ParolaOnayla { get; set; }


    }
}
