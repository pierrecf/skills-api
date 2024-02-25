using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Skill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(200)]
    public string Name { get; set; }
    

    public ICollection<UserSkill> UserSkills { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
}
