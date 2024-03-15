using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBS_App.Data;
namespace OBS_App.Areas.Admin.ViewsModel
{
    
    public class SifreDegistirViewsModel
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 

        //Confirm Parola için onay 

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parola eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        public List<SelectList> SelectLists { get; set; } = new List<SelectList>();
        

    }
}
