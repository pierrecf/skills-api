using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using skills_api.Models;

public enum SkillLevel
{
    Beginner,
    Intermediate,
    Advanced,
    Pro
}
public class UserSkill
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public SkillLevel Level { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }



    [ForeignKey("Skill")]
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}

