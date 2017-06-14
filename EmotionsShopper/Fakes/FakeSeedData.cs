using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using EmotionsShopper.Models; 
namespace EmotionsShopper.Fakes
{
    public static class FakeSeedData
    {
        public static void Populate(IApplicationBuilder appBuilder)
        {
            ApplicationDbContext context = 
                appBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Indifferent",
                        Description = "having no particular interest or sympathy; unconcerned.",
                        Category = "Neutral",
                        Price = 9.50m 
                    },
                    new Product
                    {
                        Name = "Joy",
                        Description = "the expression or display of glad feeling.",
                        Category = "Positive",
                        Price = 50 
                    },
                    new Product
                    {
                        Name = "Saddness",
                        Description = "the condition or quality of being sad.",
                        Category = "Negative", 
                        Price = 10
                    },
                    new Product
                    {
                        Name = "Angry",
                        Description ="Feeling or showing strong annoyance, displeasure, or hostility; full of anger.",
                        Category = "Negative"
                    },
					new Product
					{
						Name = "Depression",
						Description = "Feelings of severe despondency and dejection.",
    					Category = "Negative",
                        Price = 8.50m 
					},
                    new Product
                    {
                        Name = "Ecstatic",  
                        Description = "feeling or expressing overwhelming happiness or joyful excitement.",
                        Category = "Positive", 
                        Price = 75
                    },
                    new Product 
                    { 
                        Name = "Disengaged", 
                        Description = "Emotionally detached.", 
                        Category ="Neutral", 
                        Price = 12.99m 
                    },
                    new Product 
                    {
                        Name = "Disinterested", 
                        Description = "Not influenced by considerations of personal advantage.", 
                        Category = "Neutral", 
                        Price = 9.99m
                    }
                    
				);

                context.SaveChanges();
            }
            
        }
    }
}
