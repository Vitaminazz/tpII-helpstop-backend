using AutoMapper;
using HelpApp.Application.DTOs;
using HelpApp.Application.Interfaces;
using HelpApp.Domain.Interfaces;
using HelpApp.Domain.Entities;

namespace HelpApp.Application.Services
{
    internal class ProductServices : IProductInterface
    {
        private IProductInterface _productRepository;
        private readonly IMapper _mapper;
        public ProductServices(IProductInterface productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var categoriesEntity = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(categoriesEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productsEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productsEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Create(productsEntity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productsEntity = _mapper.Map<Category>(productDto);
            await _productRepository.Update(productsEntity);
        }

        public async Task Remove(int? id)
        {
            var productsEntity = _productRepository.GetById(id).Result;
            await _productRepository.Remove(productsEntity);
        }
    }
}
