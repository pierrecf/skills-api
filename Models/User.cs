using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace skills_api.Models;

public class User :IdentityUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public ICollection<UserSkill>? UserSkills { get; set; }
    public string PasswordHash { get; set; }
    public ICollection<Goal>? Goals { get; set; }

}