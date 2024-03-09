using System.ComponentModel.DataAnnotations;

namespace OBS_App.Areas.Admin.ViewsModel
{
    public class SifreDegistirViewsModel
    {
        [EmailAddress]
        [Required]
        public string EPosta { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Sifre), ErrorMessage = "Parolanız Eşleşmiyor")]
        public string SifreTekrari { get; set; }
    }
}
