using CDNFM.Models;

namespace CDNFM.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User{
                    Username="Carson",
                    Email="Carson@example.com",
                    PhoneNumber="60123456789",
                    Skillsets= "PHP, MySQL, CSS",
                    Hobby="Running"
                },
                new User
                {
                    Username = "John",
                    Email = "John@example.com",
                    PhoneNumber = "60123456780",
                    Skillsets= "Ruby, Python, Perl",
                    Hobby = "Swimming"
                },
                new User
                {
                    Username = "Emma",
                    Email = "Emma@example.com",
                    PhoneNumber = "60123456781",
                    Skillsets= "PowerShell, Docker",
                    Hobby = "Reading"
                },
                new User
                {
                    Username = "Sophia",
                    Email = "Sophia@example.com",
                    PhoneNumber = "60123456782",
                    Skillsets= "Go, TypeScript, Node.js",
                    Hobby = "Painting"
                },
                new User
                {
                    Username = "Liam",
                    Email = "Liam@example.com",
                    PhoneNumber = "60123456783",
                    Skillsets= "Ruby, JavaScript, Go",
                    Hobby = "Gaming"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}