using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EventPopper.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // GATTUSMP: SAMPLE OF A SEED FILE THAT FIRST LOOKS FOR A DATABASE WITH DATA
                //           IF NO DATA FOUND THEN DATA IS ADDED TO THE DATABASE
                // // Look for any movies.
                if (context.Event.Any())
                {
                    return;   // DB has been seeded
                }
                context.Event.AddRange(
                    new Event { Name = "Orange festival", Type= "Fun", TotalSeats = 2, EventDate=new DateTime(2019,05,29), EventTime=new DateTime(2019,05,29,05,00,00), Location="xyz", NumberOfTickets=100},
                    new Event { Name=  "Tallest Man", Type= "Drama", TotalSeats = 2, EventDate=new DateTime(2019,05,29), EventTime=new DateTime(2019,05,29,05,00,00), Location="xyz", NumberOfTickets=100 },
                    new Event { Name = "Crystal Method", Type= "singing", TotalSeats = 10, EventDate=new DateTime(2019,05,29), EventTime=new DateTime(2019,05,29,05,00,00), Location="xyz", NumberOfTickets=100 },
                    new Event { Name = "Trans-Siberian Orchestra", Type= "karoke", TotalSeats = 2, EventDate=new DateTime(2019,05,29), EventTime=new DateTime(2019,05,29,05,00,00), Location="xyz", NumberOfTickets=100 },
                    new Event { Name = "Kelly Clarkson music", Type= "live music", TotalSeats = 2, EventDate=new DateTime(2019,05,29), EventTime=new DateTime(2019,05,29,05,00,00), Location="xyz", NumberOfTickets=100 }
                );
                context.SaveChanges();
            }
        }
    }
}