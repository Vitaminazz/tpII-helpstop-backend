using HelpApp.Domain.Entities;
using MediatR;

namespace HelpApp.Application.Products.Commands
{
    internal abstract class ProductCommands : IRequest<Product>
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }

        public string Image {  get; set; }

        public int CategoryId { get; set; }
    }
}
