using incercareProiect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "10"
                },
                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "3"
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "5"
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "8"
                }
            );
            context.SaveChanges();
        }

        using (var context = new MvcVeganContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcVeganContext>>()))
        {
            // Look for any vegan stuff.
            if (context.Vegan.Any())
            {
                return;   // DB has been seeded
            }
            context.Vegan.AddRange(
                new Vegan
                {
                    Name = "Fries",
                    Type = "Side dish",
                    Price = 2.99M,
                    Rating = "10"
                },
                new Vegan
                {
                    Name = "Mashed potatos",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "9"
                },
                new Vegan
                {
                    Name = "Mashed carrots",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "6"
                },
                new Vegan
                {
                    Name = "Mashed peas",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "8"
                }
        );
            context.SaveChanges();
        }

        using (var context = new MvcVegetarianContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcVegetarianContext>>()))
        {
            // Look for any Vegetarian stuff.
            if (context.Vegetarian.Any())
            {
                return;   // DB has been seeded
            }
            context.Vegetarian.AddRange(
                new Vegetarian
                {
                    Name = "Fries",
                    Type = "Side dish",
                    Price = 2.99M,
                    Rating = "10"
                },
                new Vegetarian
                {
                    Name = "Mashed potatos",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "9"
                },
                new Vegetarian
                {
                    Name = "Mashed carrots",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "6"
                },
                new Vegetarian
                {
                    Name = "Mashed peas",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "8"
                },
                new Vegetarian
                {
                    Name = "Veggie Burger",
                    Type = "Second course",
                    Price = 9.99M,
                    Rating = "8,5"
                },
                new Vegetarian
                {
                    Name = "Veggie Schnitzel",
                    Type = "Second course",
                    Price = 7.99M,
                    Rating = "7,5"
                },
                new Vegetarian
                {
                    Name = "Tomato soup",
                    Type = "Main course",
                    Price = 5.99M,
                    Rating = "9,5"
                },
                new Vegetarian
                {
                    Name = "Mushroom soup",
                    Type = "Main course",
                    Price = 5.99M,
                    Rating = "10"
                },
                new Vegetarian
                {
                    Name = "Potato soup",
                    Type = "Main course",
                    Price = 4.99M,
                    Rating = "8"
                }
        );
            context.SaveChanges();
        }

        using (var context = new MvcPescatarianContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPescatarianContext>>()))
        {
            // Look for any Pescatarian stuff.
            if (context.Pescatarian.Any())
            {
                return;   // DB has been seeded
            }
            context.Pescatarian.AddRange(
                new Pescatarian
                {
                    Name = "Fries",
                    Type = "Side dish",
                    Price = 2.99M,
                    Rating = "10"
                },
                new Pescatarian
                {
                    Name = "Mashed potatos",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "9"
                },
                new Pescatarian
                {
                    Name = "Mashed carrots",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "6"
                },
                new Pescatarian
                {
                    Name = "Mashed peas",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "8"
                },
                new Pescatarian
                {
                    Name = "Veggie Burger",
                    Type = "Second course",
                    Price = 9.99M,
                    Rating = "8,5"
                },
                new Pescatarian
                {
                    Name = "Veggie Schnitzel",
                    Type = "Second course",
                    Price = 7.99M,
                    Rating = "7,5"
                },
                new Pescatarian
                {
                    Name = "Tomato soup",
                    Type = "Main course",
                    Price = 5.99M,
                    Rating = "9,5"
                },
                new Pescatarian
                {
                    Name = "Mushroom soup",
                    Type = "Main course",
                    Price = 5.99M,
                    Rating = "10"
                },
                new Pescatarian
                {
                    Name = "Potato soup",
                    Type = "Main course",
                    Price = 4.99M,
                    Rating = "8"
                },
                new Pescatarian
                {
                    Name = "Grilled salmon",
                    Type = "Second course",
                    Price = 10.99M,
                    Rating = "9"
                },
                new Pescatarian
                {
                    Name = "Grilled tuna",
                    Type = "Second course",
                    Price = 10.99M,
                    Rating = "8"
                },
                new Pescatarian
                {
                    Name = "Tuna salad",
                    Type = "Second course",
                    Price = 8.99M,
                    Rating = "10"
                },
                new Pescatarian
                {
                    Name = "Salmon rolls",
                    Type = "Second course",
                    Price = 14.99M,
                    Rating = "9,5"
                },
                new Pescatarian
                {
                    Name = "Tuna rolls",
                    Type = "Second course",
                    Price = 12.99M,
                    Rating = "9"
                }
        );
            context.SaveChanges();
        }

        using (var context = new MvcOmnivoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcOmnivoreContext>>()))
        {
            // Look for any Omnivore stuff.
            if (context.Omnivore.Any())
            {
                return;   // DB has been seeded
            }
            context.Omnivore.AddRange(
                new Omnivore
                {
                    Name = "Fries",
                    Type = "Side dish",
                    Price = 2.99M,
                    Rating = "10"
                },
                new Omnivore
                {
                    Name = "Mashed potatos",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "9"
                },
                new Omnivore
                {
                    Name = "Mashed carrots",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "6"
                },
                new Omnivore
                {
                    Name = "Mashed peas",
                    Type = "Side dish",
                    Price = 3.99M,
                    Rating = "8"
                },
                new Omnivore
                {
                    Name = "Veggie Burger",
                    Type = "Second course",
                    Price = 9.99M,
                    Rating = "8,5"
                },
                new Omnivore
                {
                    Name = "Veggie Schnitzel",
                    Type = "Second course",
                    Price = 7.99M,
                    Rating = "7,5"
                },
                new Omnivore
                {
                    Name = "Tomato soup",
                    Type = "Main course",
                    Price = 5.99M,
                    Rating = "9,5"
                },
                new Omnivore
                {
                    Name = "Mushroom soup",
                    Type = "Main course",
                    Price = 5.99M,
                    Rating = "10"
                },
                new Omnivore
                {
                    Name = "Potato soup",
                    Type = "Main course",
                    Price = 4.99M,
                    Rating = "8"
                },
                new Omnivore
                {
                    Name = "Grilled salmon",
                    Type = "Second course",
                    Price = 10.99M,
                    Rating = "9"
                },
                new Omnivore
                {
                    Name = "Grilled tuna",
                    Type = "Second course",
                    Price = 10.99M,
                    Rating = "8"
                },
                new Omnivore
                {
                    Name = "Tuna salad",
                    Type = "Second course",
                    Price = 8.99M,
                    Rating = "10"
                },
                new Omnivore
                {
                    Name = "Salmon rolls",
                    Type = "Second course",
                    Price = 14.99M,
                    Rating = "9,5"
                },
                new Omnivore
                {
                    Name = "Tuna rolls",
                    Type = "Second course",
                    Price = 12.99M,
                    Rating = "9"
                },
                new Omnivore
                {
                    Name = "Beef Burger",
                    Type = "Second course",
                    Price = 9.99M,
                    Rating = "10"
                },
                new Omnivore
                {
                    Name = "Beef Cheeseburger",
                    Type = "Second course",
                    Price = 10.99M,
                    Rating = "10"
                },
                new Omnivore
                {
                    Name = "Chicken Burger",
                    Type = "Second course",
                    Price = 7.99M,
                    Rating = "9,5"
                },
                new Omnivore
                {
                    Name = "Chicken schnitzel",
                    Type = "Second course",
                    Price = 7.99M,
                    Rating = "10"
                },
                new Omnivore
                {
                    Name = "Beef Schnitzel",
                    Type = "Second course",
                    Price = 9.99M,
                    Rating = "10"
                },
                new Omnivore
                {
                    Name = "Chicken strips",
                    Type = "Second course",
                    Price = 7.99M,
                    Rating = "10"
                }
        );
            context.SaveChanges();
        }
    }
}
