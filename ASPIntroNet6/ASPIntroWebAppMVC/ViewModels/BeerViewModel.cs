using System.ComponentModel.DataAnnotations;

namespace ASPIntroWebAppMVC.ViewModels
{
    public class BeerViewModel
    {
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Marca")]
        public int BrandId { get; set; }
    }
}
