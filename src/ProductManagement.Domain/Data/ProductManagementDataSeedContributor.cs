using ProductManagement.Categories;
using ProductManagement.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Data
{
    public class ProductManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;
        public async Task SeedAsync(DataSeedContext context)
        {
            /***** TODO: Seed initial data here *****/
            if(await _categoryRepository.CountAsync() > 0)
            {
                return;
            }
            var monitors = new Category { Name = "Monitors" };
            var printers = new Category { Name = "Printers" };

            await _categoryRepository.InsertManyAsync(new[] { monitors, printers });

            #region DataToBeSeeded
            var monitor1 = new Product
            {
                Category = monitors,
                Name = "XP VH240a 23.8-Inch Full HD IPS LED Monitor",
                Price = 163,
                ReleaseDate = new DateTime(2019, 05, 24),
                StockState = ProductStockState.InStock
            };
            var monitor2 = new Product
            {
                Category = monitors,
                Name = "Clips 328E1CA 32-Inch Curved Monitor, 4k UHD",
                Price = 349,
                ReleaseDate = new DateTime(2022, 02, 01),
                StockState = ProductStockState.PreOrder
            };
            var printer1 = new Product
            {
                Category = printers,
                Name = "ACME Monochrome Laser Printer, Compact All-In-One",
                Price = 199,
                ReleaseDate = new DateTime(2020, 11, 16),
                StockState = ProductStockState.NotAvailable
            };
            #endregion

            await _productRepository.InsertManyAsync(new[] {monitor1, monitor2, printer1});
        }
    }
}
