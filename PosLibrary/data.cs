using System;
using System.Collections.Generic;

namespace PosLibrary
{
    public class data
    {
        public static readonly string[] Categories = new[]
        {
            "Snacks", "Dairy Products", "Coffee & Tea Powder", "Health Products",
            "Bakery Items", "Beauty Products", "Stationery", "Gift Cards",
            "Favorites", "Fruits", "Spices", "Noodles", "Jam", "Meat",
            "Beverages", "Sauce", "Frozen Foods", "Top-up phone credit"
        };

        public static readonly Dictionary<string, (string name, decimal price)[]> Products = new()
        {
        ["Snacks"] = new[]
        {
            ("Potato Chips", 1.99m),
            ("Popcorn", 2.50m),
            ("Peanuts", 1.75m),
            ("Pretzels", 2.25m),
            ("Doritos", 2.99m),
            ("Mixed Nuts", 4.50m)
        },

        ["Dairy Products"] = new[]
        {
            ("Milk", 3.99m),
            ("Cheese", 4.50m),
            ("Yogurt", 2.99m),
            ("Butter", 3.50m),
            ("Ice Cream", 5.99m),
            ("Sour Cream", 2.75m)
        },

        ["Coffee & Tea Powder"] = new[]
        {
            ("Instant Coffee", 5.99m),
            ("Green Tea Powder", 6.50m),
            ("Black Tea", 4.75m),
            ("Espresso Powder", 7.25m),
            ("Chai Mix", 5.50m),
            ("Matcha", 8.99m)
        },

        ["Health Products"] = new[]
        {
            ("Multivitamins", 12.99m),
            ("Protein Powder", 29.99m),
            ("Omega-3 Capsules", 15.50m),
            ("Vitamin C", 8.99m),
            ("Herbal Tea", 6.99m),
            ("Probiotics", 18.75m)
        },

        ["Bakery Items"] = new[]
        {
            ("Croissant", 2.99m),
            ("Choco Chip Cookie", 1.50m),
            ("French Bread", 2.50m),
            ("Wheat Bread", 2.00m),
            ("White Bread", 2.00m),
            ("Éclair", 2.00m)
        },

        ["Beauty Products"] = new[]
        {
            ("Face Cream", 14.99m),
            ("Lip Balm", 3.99m),
            ("Shampoo", 6.50m),
            ("Conditioner", 6.50m),
            ("Sunscreen", 9.99m),
            ("Hand Lotion", 5.25m)
        },

        ["Stationery"] = new[]
        {
            ("Notebook", 1.99m),
            ("Ball Pen", 0.75m),
            ("Marker Set", 3.99m),
            ("Highlighter", 1.25m),
            ("Sticky Notes", 2.50m),
            ("Scissors", 2.99m)
        },

        ["Gift Cards"] = new[]
        {
            ("Amazon Gift Card", 25.00m),
            ("iTunes Gift Card", 15.00m),
            ("Google Play Gift Card", 20.00m),
            ("Steam Gift Card", 50.00m),
            ("Netflix Gift Card", 30.00m),
            ("Uber Gift Card", 10.00m)
        },

        ["Favorites"] = new[]
        {
            ("Nutella", 4.99m),
            ("Cheddar Cheese", 5.50m),
            ("Oreos", 2.99m),
            ("Ice Cream", 5.99m),
            ("Soda", 1.99m),
            ("Chocolates", 3.50m)
        },

        ["Fruits"] = new[]
        {
            ("Apple", 0.50m),
            ("Banana", 0.30m),
            ("Orange", 0.60m),
            ("Grapes", 3.99m),
            ("Strawberries", 4.50m),
            ("Mango", 2.99m)
        },

        ["Spices"] = new[]
        {
            ("Black Pepper", 1.99m),
            ("Turmeric", 2.50m),
            ("Cumin", 2.25m),
            ("Coriander", 1.75m),
            ("Paprika", 2.10m),
            ("Chili Powder", 2.30m)
        },

        ["Noodles"] = new[]
        {
            ("Instant Noodles", 0.99m),
            ("Ramen", 1.50m),
            ("Udon", 2.75m),
            ("Rice Noodles", 2.50m),
            ("Soba", 3.00m),
            ("Glass Noodles", 2.20m)
        },

        ["Jam"] = new[]
        {
            ("Strawberry Jam", 3.50m),
            ("Apricot Jam", 3.25m),
            ("Blueberry Jam", 4.00m),
            ("Mango Jam", 3.75m),
            ("Raspberry Jam", 4.25m),
            ("Mixed Fruit Jam", 3.99m)
        },

        ["Meat"] = new[]
        {
            ("Chicken Breast", 7.99m),
            ("Ground Beef", 6.99m),
            ("Pork Chops", 8.99m),
            ("Salmon Fillet", 12.99m),
            ("Turkey", 9.99m),
            ("Lamb Chops", 14.99m)
        },

        ["Beverages"] = new[]
        {
            ("Cola", 1.50m),
            ("Orange Juice", 2.99m),
            ("Water", 1.00m),
            ("Energy Drink", 3.50m),
            ("Green Tea", 2.50m),
            ("Coffee", 3.99m)
        },

        ["Sauce"] = new[]
        {
            ("Ketchup", 1.99m),
            ("Mayonnaise", 2.50m),
            ("Soy Sauce", 2.00m),
            ("Hot Sauce", 2.75m),
            ("Barbecue Sauce", 3.25m),
            ("Chili Garlic Sauce", 2.85m)
        },

        ["Frozen Foods"] = new[]
        {
            ("Frozen Pizza", 5.99m),
            ("Frozen Vegetables", 3.99m),
            ("Ice Cream Tub", 6.50m),
            ("Frozen Chicken Wings", 7.99m),
            ("Frozen Dumplings", 4.50m),
            ("Frozen Berries", 5.25m)
        },

        ["Top-up phone credit"] = new[]
        {
            ("5$ Recharge", 5.00m),
            ("10$ Recharge", 10.00m),
            ("15$ Recharge", 15.00m),
            ("20$ Recharge", 20.00m),
            ("25$ Recharge", 25.00m),
            ("50$ Recharge", 50.00m)
        }
        };


        public void InitializeDatabase(IDatabaseHelper databaseHelper)
        {
            DatabaseHelper datahelper = new DatabaseHelper();
            var existingCategories = datahelper.GetCategories();
            if (!existingCategories.Any())
            {
                // Add categories
                foreach (var category in Categories)
                {
                    datahelper.InsertCategory(category);
                }

                // Get updated categories with IDs
                var categoriesWithIds = datahelper.GetCategories()
                    .ToDictionary(c => c.name, c => c.id);

                // Add products for each category
                foreach (var category in Products.Keys)
                {
                    if (categoriesWithIds.TryGetValue(category, out int categoryId))
                    {
                        foreach (var (name, price) in Products[category])
                        {
                            datahelper.InsertProduct(categoryId, name, price);
                        }
                    }
                }
            }
        }
    }
}