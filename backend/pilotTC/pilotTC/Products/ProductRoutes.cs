using Microsoft.EntityFrameworkCore;
using pilotTC.Data;

namespace pilotTC.Products
{
    public static class ProductRoutes
    {
        public static void AddProductRoutes(this IEndpointRouteBuilder app)
        {
            var routeGroup = app.MapGroup("/api/products").WithTags("Products");

            routeGroup.MapGet("/", async (AppDBContext context) =>
            {
                var products = new[]
                {
                    new
                    {
                        Id = 1,
                        Name = "Product 1",
                        Price = 10.0,
                        Description = "Description for Product 1",
                        Category = "Category A",
                        ImageUrl = "https://example.com/product1.jpg"
                    },
                    new
                    {
                        Id = 2,
                        Name = "Product 2",
                        Price = 20.0,
                        Description = "Description for Product 2",
                        Category = "Category B",
                        ImageUrl = "https://example.com/product2.jpg"
                    },
                    new
                    {
                        Id = 3,
                        Name = "Product 3",
                        Price = 30.0,
                        Description = "Description for Product 3",
                        Category = "Category A",
                        ImageUrl = "https://example.com/product3.jpg"
                    }
                };

                var productList = await context.Product.ToListAsync();

                return Results.Ok(productList);
            });


            routeGroup.MapPost("/", async (AddProductRequest request, AppDBContext context) => 
            {
                var validateData = await context.Product
                    .AnyAsync(product => product.Name == request.name);

                if (validateData)
                    return Results.BadRequest($"Already exists {request.name}");

                var newProduct = new Product(request.name);

                await context.Product.AddAsync(newProduct);
                await context.SaveChangesAsync();
                return Results.Ok($"Create a new product {newProduct}");
            });


            routeGroup.MapGet("/{id}", (int id) => Results.Ok($"Get product with ID {id}"));


            routeGroup.MapPut("/{id}", async (int id, AppDBContext context) =>
            {
                await context.Product
                    .Where(product => product.Id == id)
                    .ExecuteUpdateAsync(product => 
                        product.SetProperty(p => p.Name, p => "Updated Name")
                               .SetProperty(p => p.Description, p => "Updated Description")
                    );

                return Results.Ok($"Update product with ID {id}");
            });


            routeGroup.MapDelete("/{id}", (int id) => Results.Ok($"Delete product with ID {id}"));

        }
    }
}
