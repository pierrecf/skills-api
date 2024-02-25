using Bogus;
using Microsoft.EntityFrameworkCore;
using skills_api.Models;


public static class Seeder
{
    public static void SeedDatabase(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<DatabaseContext>();

        if (context != null)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Categories.Any())
            {
                var categoryNames = new[]
                    { "Programming", "Design", "Language", "Math", "Science" }; // Example category names
                var categories = categoryNames.Select((name, index) => new Category
                {
                    Id = -(index + 1),
                    Name = name
                }).ToList();

                context.AddRange(categories);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var userFaker = new Faker<User>()
                    .RuleFor(u => u.Id, f => -(f.IndexFaker + 1))
                    .RuleFor(u => u.UserName, f => f.Internet.UserName())
                    .RuleFor(u=>u.Email,f=>f.Internet.Email())
                    .RuleFor(u=>u.PhoneNumber,f=>f.Person.Phone)
                    .RuleFor(u => u.PasswordHash, f => f.Internet.Password());
                var users = userFaker.Generate(10);
                context.AddRange(users);
                context.SaveChanges();
            }

            if (!context.Skills.Any())
            {
                //Skills
                var skillFaker = new Faker<Skill>()
                    .RuleFor(s => s.Id, f => -(f.IndexFaker + 1))
                    .RuleFor(s => s.Name, f => f.Commerce.ProductName())
                    .RuleFor(s => s.CategoryId, f => -f.Random.Number(1, 5));

                var skills = skillFaker.Generate(20);

                context.AddRange(skills);
                context.SaveChanges();
            }
            
            if (!context.Goals.Any())
            {
                var goalFaker = new Faker<Goal>()
                        .RuleFor(s => s.Id, f => -(f.IndexFaker + 1))
                        .RuleFor(g => g.UserId, f => -f.Random.Number(2, 8))
                        .RuleFor(g => g.SkillId, f => -f.Random.Number(1, 4))
                        .RuleFor(g => g.Title, f => f.Commerce.ProductName())
                        .RuleFor(g => g.Description, f => f.Lorem.Sentence())
                    ;
            
                var goals = goalFaker.Generate(20);
                context.AddRange(goals);
                context.SaveChanges();
            }
        }
    }
}