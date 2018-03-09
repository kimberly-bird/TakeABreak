using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeABreak.Models;

namespace TakeABreak.Data
{
    public static class DbInitializer
    {
        // Seed the database
        public static void Initialize(IServiceProvider services)
        {
            // The pattern of 'using' handles the opening and closing of the 
            // database connection
            using (var context = services.GetRequiredService<ApplicationDbContext>())
            {
                //clear the database by uncommenting the code

                /*
                context.Database.ExecuteSqlCommand("DELETE FROM [Day]");
                context.Database.ExecuteSqlCommand("DELETE FROM [Break]");
                context.Database.ExecuteSqlCommand("DELETE FROM [BreakType]");
                */

                // If there are any BreakTypes already don't overwrite them
                if (!context.BreakType.Any())
                {
                    var breakTypes = new BreakType[]
                    {
                        new BreakType {
                            Type = "I Took A Break",
                            PointValue = 1
                        },
                        new BreakType {
                            Type = "I Moved Around",
                            PointValue = 3
                        },
                        new BreakType {
                            Type = "I Talked To Someone",
                            PointValue = 3
                        },
                        new BreakType {
                            Type = "I Went Outside",
                            PointValue = 3
                        },
                        new BreakType {
                            Type = "I Took A Tech Free Break",
                            PointValue = 5
                        },
                        new BreakType {
                            Type = "I Took A Lunch Break",
                            PointValue = 1
                        },
                        new BreakType {
                            Type = "I Took A Lunch Break Away From My Desk",
                            PointValue = 3
                        }
                    };

                    foreach (BreakType i in breakTypes)
                    {
                        context.BreakType.Add(i);
                    }
                    context.SaveChanges();
                }

                if (!context.Break.Any())
                {
                    var breaks = new Break[]
                    {
                        new Break {
                            Time = DateTime.Now,
                            Length = 10,
                            DayId = 2,
                            BreakTypeId = 3
                        },
                        new Break {
                            Time = DateTime.Now,
                            Length = 10,
                            DayId = 2,
                            BreakTypeId = 3
                        }
                    };

                    foreach (Break i in breaks)
                    {
                        context.Break.Add(i);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
