namespace RS1_2024_25.API.Endpoints.DataSeed;

using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper.Api;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Threading.Tasks;

[Route("data-seed")]
public class DataSeedGenerateEndpoint(ApplicationDbContext db)
    : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<string>
{
    [HttpPost]
    public override async Task<string> HandleAsync(CancellationToken cancellationToken = default)
    {
        
        if (!db.MyAppUsers.Any())
        {
            var users = new List<MyAppUser>
            {
                new MyAppUser
                {
                    FirstName = "Admin",
                    LastName = "One",
                    Email = "admin@gmail.com",
                    Password = "admin123",
                    PhoneNumber = "256-984-335",
                    Address = "Admin Address",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsAdmin = true,
                    IsManager = false
                },
                new MyAppUser
                {
                    FirstName = "Manager1",
                    LastName = "One",
                    Email = "manager@gmail.com",
                    Password = "manager123",
                    PhoneNumber = "256-987-555",
                    Address = "Manager Address",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsAdmin = false,
                    IsManager = true
                },
                new MyAppUser
                {
                    FirstName = "Manager2",
                    LastName = "Two",
                    Email = "manager2@gmail.com",
                    Password = "manager456",
                    PhoneNumber = "145-956-874",
                    Address = "Manager2 Address",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsAdmin = false,
                    IsManager = true
                },
                new MyAppUser
                {
                    FirstName = "User1",
                    LastName = "One",
                    Email = "user@gmail.com",
                    Password = "user123",
                    PhoneNumber = "478-958-667",
                    Address = "User Address",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsAdmin = false,
                    IsManager = false
                },
                new MyAppUser
                {
                    FirstName = "User2",
                    LastName = "Two",
                    Email = "user2@gmail.com",
                    Password = "user456",
                    PhoneNumber = "748-958-254",
                    Address = "User2 Address",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsAdmin = false,
                    IsManager = false
                }
            };

            await db.MyAppUsers.AddRangeAsync(users, cancellationToken);
        }

        
        if (!db.Categories.Any())
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Facial Care",
                    Description = "Products designed for facial skincare, including cleansers, moisturizers, serums, and more to maintain healthy and glowing skin.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Name = "Body Care",
                    Description = "Products for maintaining and enhancing the health of the body, including body lotions, scrubs, body oils, and more.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Name = "Hair Care",
                    Description = "Products specifically designed to nourish, strengthen, and style hair, such as shampoos, conditioners, oils, and treatments.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Name = "Lip Care",
                    Description = "Products dedicated to moisturizing, protecting, and enhancing the appearance of lips, including balms, glosses, and lip treatments.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            await db.Categories.AddRangeAsync(categories, cancellationToken);
        }

        
        if (!db.Subcategories.Any())
        {
            var subcategories = new List<Subcategory>
            {
                // Facial Care Subcategories (CategoryId = 5)
                new Subcategory
                {
                    Name = "Cleanser",
                    Description = "Cleansers designed to remove dirt, oil, and makeup, helping to maintain clean and fresh skin.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 5 // Facial Care
                },
                new Subcategory
                {
                    Name = "Toner",
                    Description = "Toners are used to balance the skin's pH and prepare it for better absorption of other skincare products.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 5 // Facial Care
                },
                new Subcategory
                {
                    Name = "Exfoliant / Scrub",
                    Description = "Exfoliants and scrubs help to remove dead skin cells, revealing smoother, brighter skin.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 5 // Facial Care
                },
                new Subcategory
                {
                    Name = "Serum / Essence",
                    Description = "Serums and essences are concentrated formulas designed to target specific skin concerns, such as wrinkles or pigmentation.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 5 // Facial Care
                },
                new Subcategory
                {
                    Name = "Cream",
                    Description = "Creams provide deep hydration and nourishment to the skin, often used for moisturizing or anti-aging purposes.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 5 // Facial Care
                },
                new Subcategory
                {
                    Name = "Eye Care",
                    Description = "Products designed specifically for the delicate skin around the eyes, such as eye creams or serums to reduce puffiness and dark circles.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 5 // Facial Care
                },
                new Subcategory
                {
                    Name = "Face Mask",
                    Description = "Face masks are used for targeted skincare treatments to hydrate, detoxify, or brighten the skin.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 5 // Facial Care
                },
                new Subcategory
                {
                    Name = "SPF / Sun Protection",
                    Description = "Sun protection products that help shield the skin from harmful UV rays, preventing sunburn and premature aging.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 5 // Facial Care
                },
            
                // Body Care Subcategories (CategoryId = 6)
                new Subcategory
                {
                    Name = "Body Care Set",
                    Description = "Complete sets for body care that include lotions, scrubs, oils, and more for an all-in-one skincare routine.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 6 // Body Care
                },
                new Subcategory
                {
                    Name = "Body Lotion",
                    Description = "Body lotions designed to hydrate and nourish the skin, leaving it soft and smooth.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 6 // Body Care
                },
                new Subcategory
                {
                    Name = "Body Scrub",
                    Description = "Scrubs that exfoliate the body, removing dead skin cells and improving circulation for smoother skin.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 6 // Body Care
                },
                new Subcategory
                {
                    Name = "Body Oil",
                    Description = "Body oils used to nourish and hydrate the skin, giving it a healthy glow.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 6 // Body Care
                },
            
                // Hair Care Subcategories (CategoryId = 7)
                new Subcategory
                {
                    Name = "Shampoo",
                    Description = "Shampoos designed to cleanse the scalp and hair, removing dirt, oil, and buildup while maintaining hair health.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 7 // Hair Care
                },
                new Subcategory
                {
                    Name = "Hair Mask / Conditioner",
                    Description = "Hair masks and conditioners that provide deep hydration and nourishment to the hair, making it soft and manageable.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 7 // Hair Care
                },
                new Subcategory
                {
                    Name = "Hair Ampoule",
                    Description = "Ampoules are concentrated treatments for hair, designed to address specific concerns like hair loss or damage.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 7 // Hair Care
                },
                new Subcategory
                {
                    Name = "Leave-in Treatment",
                    Description = "Leave-in products that provide continuous nourishment and protection to hair throughout the day.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 7 // Hair Care
                },
                new Subcategory
                {
                    Name = "Hair Accessories",
                    Description = "Accessories for hair styling and care, such as brushes, hair ties, and clips.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 7 // Hair Care
                },
            
                // Lip Care Subcategories (CategoryId = 8)
                new Subcategory
                {
                    Name = "Lip Balm",
                    Description = "Lip balms designed to hydrate and protect the lips, keeping them soft and smooth.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 8 // Lip Care
                },
                new Subcategory
                {
                    Name = "Lip Gloss",
                    Description = "Lip glosses that add shine and moisture to the lips, often with a slight tint.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 8 // Lip Care
                },
                new Subcategory
                {
                    Name = "Lip Treatment",
                    Description = "Lip treatments designed to repair, hydrate, and protect the lips from dryness or damage.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CategoryId = 8 // Lip Care
                }
            };

            await db.Subcategories.AddRangeAsync(subcategories, cancellationToken);
        }

        if (!db.Brands.Any())
        {
            var brands = new List<Brand>
    {
        new Brand
        {
            Name = "CeraVe",
            Description = "Dermatologist-developed skincare brand known for ceramide-rich formulas.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "The Ordinary",
            Description = "Clinical formulations with a focus on active ingredients at affordable prices.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "La Roche-Posay",
            Description = "French skincare brand specializing in sensitive skin and dermatologist-recommended products.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "Nivea",
            Description = "Global skincare brand known for moisturizers, body lotions, and classic skincare products.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "L'Oréal Paris",
            Description = "International beauty brand offering skincare, haircare, and cosmetic products.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "Garnier",
            Description = "Affordable skincare and haircare brand with natural ingredient-focused formulas.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "Bioderma",
            Description = "French brand known for micellar waters and gentle skincare for sensitive skin.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "Eucerin",
            Description = "Dermatological skincare brand focused on repairing and protecting the skin barrier.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "Vichy",
            Description = "Skincare brand using mineral-rich volcanic water to strengthen and hydrate skin.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Brand
        {
            Name = "Neutrogena",
            Description = "Dermatologist-recommended brand offering acne treatments, cleansers, and moisturizers.",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }
    };

            await db.Brands.AddRangeAsync(brands, cancellationToken);
        }

        if (!db.ProductTypes.Any())
        {
            var productTypes = new List<ProductType>
    {
        new ProductType
        {
            Name = "SPF",
            
        },
        new ProductType
        {
            Name = "Cream",
            
        },
        new ProductType
        {
            Name = "Shampoo",
           
        },
        new ProductType
        {
            Name = "Cleanser",
          
        },
        new ProductType
        {
            Name = "Micellar Water",
         
        }
    };

            await db.ProductTypes.AddRangeAsync(productTypes, cancellationToken);
         
        }


        if (!db.SkinTypes.Any())
        {
            var skinTypes = new List<SkinType>
            {
                new SkinType
{
    Name = "Normal"
},
new SkinType
{
    Name = "Dry"
},
new SkinType
{
    Name = "Oily"
},
new SkinType
{
    Name = "Combination"
},
new SkinType
{
    Name = "Sensitive"
}

              };

            await db.SkinTypes.AddRangeAsync(skinTypes, cancellationToken);

        }

        if (!db.Products.Any())
        {
            var products = new List<Product>
        {
            new Product
            {
                Name = "La Roche-Posay Anthelios SPF 50",
                Description = "Broad spectrum facial sunscreen for sensitive skin.",
                Price = 19.99m,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StockQuantity = 100,
                PackSize = "50ml",
                Ingredients = "Water, Glycerin, Octocrylene",
                HowToUse = "Apply generously 15 minutes before sun exposure.",
                SubcategoryId = 27,
                BrandId = 3,
                ProductTypeId = 1,
                SkinTypeId=1,
            },
            new Product
            {
                Name = "Nivea Soft Moisturizing Cream",
                Description = "Light moisturizing cream for face, body, and hands.",
                Price = 5.99m,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StockQuantity = 200,
                PackSize = "100ml",
                Ingredients = "Aqua, Paraffinum Liquidum, Glycerin",
                HowToUse = "Massage gently onto skin daily.",
                SubcategoryId = 28,
                BrandId = 4,
                ProductTypeId = 2,
                SkinTypeId=2,
            },
            new Product
            {
                Name = "L'Oréal Paris Elvive Total Repair 5 Shampoo",
                Description = "Restorative shampoo for damaged hair.",
                Price = 8.99m,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StockQuantity = 150,
                PackSize = "250ml",
                Ingredients = "Aqua, Sodium Laureth Sulfate",
                HowToUse = "Apply to wet hair, lather, and rinse.",
                SubcategoryId = 29,
                BrandId = 5,
                ProductTypeId = 3,
                SkinTypeId=3,
            },
            new Product
            {
                Name = "Garnier Micellar Cleansing Water",
                Description = "Removes makeup and cleanses skin in one step.",
                Price = 6.99m,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StockQuantity = 180,
                PackSize = "400ml",
                Ingredients = "Water, Hexylene Glycol, Glycerin",
                HowToUse = "Apply to a cotton pad and gently wipe face.",
                SubcategoryId = 30,
                BrandId = 6,
                ProductTypeId = 4,
                SkinTypeId=4,
            },
            new Product
            {
                Name = "Bioderma Sensibio H2O",
                Description = "Gentle micellar water for sensitive skin.",
                Price = 12.99m,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StockQuantity = 120,
                PackSize = "250ml",
                Ingredients = "Water, PEG-6 Caprylic/Capric Glycerides",
                HowToUse = "Soak a cotton pad and cleanse face and eyes.",
                SubcategoryId = 31,
                BrandId = 7,
                ProductTypeId = 5,
                SkinTypeId=5,
            }
        };

            await db.Products.AddRangeAsync(products, cancellationToken);
        }


        //        if (!db.Products.Any())
        //        {
        //            var products = new List<Product>
        //        {
        //        new Product
        //        {
        //            Name = "La Roche-Posay Anthelios SPF 50+",
        //            Description = "Broad spectrum facial sunscreen for sensitive skin.",
        //            CreatedAt = DateTime.Now,
        //            UpdatedAt = DateTime.Now
        //        },
        //     new Product
        //     {
        //         Name = "CeraVe Hydrating Cleanser",
        //         Description = "Gentle facial cleanser that hydrates and protects the skin barrier.",
        //         CreatedAt = DateTime.Now,
        //         UpdatedAt = DateTime.Now
        //     },
        //new Product
        //{
        //    Name = "The Ordinary Hyaluronic Acid 2% + B5",
        //    Description = "Hydrating serum that helps maintain skin moisture.",
        //    CreatedAt = DateTime.Now,
        //    UpdatedAt = DateTime.Now
        //},
        //new Product
        //{
        //    Name = "Eucerin UreaRepair PLUS 5%",
        //    Description = "Moisturizing cream for very dry and rough skin.",
        //    CreatedAt = DateTime.Now,
        //    UpdatedAt = DateTime.Now
        //},
        //new Product
        //{
        //    Name = "Avène Soothing Eye Contour Cream",
        //    Description = "Calming eye cream for sensitive and irritated skin.",
        //    CreatedAt = DateTime.Now,
        //    UpdatedAt = DateTime.Now
        //} 
        //        };

        //           await db.Products.AddRangeAsync(products, cancellationToken);
        //        }


        // Spasi promene u bazi
        await db.SaveChangesAsync(cancellationToken);

        return "Data generation completed successfully.";
    }
}

