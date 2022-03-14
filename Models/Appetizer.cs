using System.ComponentModel.DataAnnotations;

namespace project_hcms.Models;

public class Appetizer {
    public int Id { get; set; }

    [Required(ErrorMessage = "Fyll i namn")]
    [StringLength(32, ErrorMessage = "Namnet måste vara mellan {2} och {1} tecken långt.", MinimumLength = 3)]
    [Display(Name = "Namn")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Fyll i innehåll")]
    [StringLength(64, ErrorMessage = "Innehållet måste vara mellan {2} och {1} tecken långt.", MinimumLength = 3)]
    [Display(Name = "Innehåll")]
    public string Ingredients { get; set; }    

    [Required(ErrorMessage = "Fyll i pris")]
    [Display(Name = "Pris (kr)")]
    [Range(1, 9999, ErrorMessage = "Fyll i ett pris mellan 1-9999.")]
    public int? Price { get; set; }

    [Display(Name = "Användare:")] 
    public string Username { get; set; } = "Ej angivet";

    public DateTime Registered { get; set; } = DateTime.Now;
}