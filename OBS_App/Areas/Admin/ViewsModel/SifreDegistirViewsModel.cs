using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS_App.Data;
namespace OBS_App.Areas.Admin.ViewsModel
{
    
    public class SifreDegistirViewsModel
    {

        
        [DataType(DataType.EmailAddress)]
        public string? Eposta { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Parola { get; set; } 

        //Confirm Parola için onay 

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Parola), ErrorMessage = "Parola eşleşmiyor.")]
        public string ParolaOnayla { get; set; }
        

    }
}
