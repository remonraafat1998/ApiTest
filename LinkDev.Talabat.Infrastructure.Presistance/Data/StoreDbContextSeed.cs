using LinkDev.Talabat.Core.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Presistance.Data
{
    public static class StoreDbContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext)
        {

          


            #region Brand
            if (!storeContext.Brands.Any())
            {

                var brandsData = await File.ReadAllTextAsync("../LinkDev.Talbat.Infrastructure.Presistance/Data/Seeds/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands?.Count > 0)
                {
                    await storeContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await storeContext.SaveChangesAsync();
                }


            }
            #endregion
            #region Category
            if (!storeContext.Categories.Any())
            {

                var CategoryData = await File.ReadAllTextAsync("../LinkDev.Talbat.Infrastructure.Presistance/Data/Seeds/categories.json");
                var Category = JsonSerializer.Deserialize<List<ProductCategory>>(CategoryData);

                if (Category?.Count > 0)
                {
                    await storeContext.Set<ProductCategory>().AddRangeAsync(Category);
                    await storeContext.SaveChangesAsync();
                }


            }


            #endregion
            #region Products
            if (!storeContext.Products.Any())
            {

                var ProductsData = await File.ReadAllTextAsync("../LinkDev.Talbat.Infrastructure.Presistance/Data/Seeds/products.json");
      
            var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                if (Products?.Count > 0)
                {
                    await storeContext.Set<Product>().AddRangeAsync(Products);
                    await storeContext.SaveChangesAsync();
                }


            }


            #endregion
        }
    }
}