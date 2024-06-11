using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models;

public class Characters
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<Backpacks> BackpacksCollection { get; set; }
    public ICollection<Character_titles> CharacterTitlesCollection { get; set; }
}