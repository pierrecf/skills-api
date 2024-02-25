using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using skills_api.Models;


public enum GoalStatus
{
    Innactive,
    Active,
    Failed,
    Accomplished
}
public class Goal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(300)]
    public string? Title { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; }
    

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Skill")]
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}