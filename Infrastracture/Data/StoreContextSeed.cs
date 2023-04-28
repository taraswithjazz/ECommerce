﻿using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Data
{
	public class StoreContextSeed
	{
		public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				if(!context.ProductBrands.Any())
				{
					var brandsData = File.ReadAllText("../Infrastracture/Data/SeedData/brands.json");

					var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

					foreach(var brand in brands)
					{
						context.ProductBrands.Add(brand);
					}

					await context.SaveChangesAsync();
				}

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastracture/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastracture/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

					foreach (var product in products)
					{
						context.Products.Add(product);
					}

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText("../Infrastracture/Data/SeedData/delivery.json");

                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var method in methods)
                    {
                        context.DeliveryMethods.Add(method);
                    }

                    await context.SaveChangesAsync();
                }
            }
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<StoreContextSeed>();
				logger.LogError(ex.Message);
			}
		}
	}
}

