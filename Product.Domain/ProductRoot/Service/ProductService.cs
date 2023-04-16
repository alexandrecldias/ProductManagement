using AutoMapper;
using Product.Domain.ProductRoot.Dto;
using Product.Domain.ProductRoot.Entity;
using Product.Domain.ProductRoot.Repository;
using Product.Domain.ProductRoot.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Product.Domain.ProductRoot.Service
{
	public class ProductService : IProductService
	{
		private readonly IProdutoRepository _produtoRepository;
		private readonly IUnitOfWork _unitOfWork;
		public readonly IMapper _mapper;

		public ProductService(
			IProdutoRepository produtoRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public IEnumerable<Entity.Product> ObterTodos()
		{
			var todosProdutos = _produtoRepository.BuscarTodos();

			return todosProdutos;
		}

		public Entity.Product ObterPorId(int idProduto)
		{
			var todosProdutos = _produtoRepository.BuscarPorId(idProduto);

			return todosProdutos;
		}

		public RetornoDto Persist(List<ProductDto> produtosDto)
		{
			var retorno = new RetornoDto();

			try
			{
				foreach (var produtoDto in produtosDto)
				{
					var product = _mapper.Map<Entity.Product>(produtoDto);

					if (product.manufacturingDate >= product.validadeDate)
					{
						throw new Exception($"Data de Fabricação {product.validadeDate.ToString("ddMMyyyy")} do produto {product.descriptionProduct} não pode ser maior que a data de Validade {product.validadeDate.ToString("ddMMyyyy")}");
					}

					if (product.Id != 0)
					{
						var produtoJaExiste = _produtoRepository.BuscarPorId(product.Id);

						if (produtoJaExiste != null)
						{
							produtoJaExiste.descriptionSupplier = produtoDto.DescriptionSupplier;
							produtoJaExiste.cnpj = produtoDto.Cnpj;
							produtoJaExiste.manufacturingDate = produtoDto.ManufacturingDate;
							produtoJaExiste.validadeDate = produtoDto.ValidadeDate;
							produtoJaExiste.descriptionProduct = produtoDto.DescriptionProduct;
							_produtoRepository.Update(produtoJaExiste);
							_unitOfWork.Commit();
							retorno.StatusCode = 200;
							retorno.Mensagem = "Sucesso";
						}

					}
					else
					{
						retorno.StatusCode = 201;
						retorno.Mensagem = "Sucesso";
						_produtoRepository.Adicionar(product);
						_unitOfWork.Commit();
					}

				}


				retorno.StatusCode = 200;
				retorno.Mensagem = "Sucesso";

				return retorno;

			}
			catch (Exception ex)
			{
				retorno.StatusCode = 400;
				retorno.Mensagem = $"Apresentou erro {ex.Message}";
				return retorno;
			}
		}

		public RetornoDto CancelProduct(int idProduto)
		{
			var retorno = new RetornoDto();

			try
			{
				var produto = _produtoRepository.BuscarPorId(idProduto);

				if (produto != null)
				{
					produto.active = false;
					_produtoRepository.Update(produto);
					_unitOfWork.Commit();
				}
				else
				{
					throw new Exception("Produto informado não existe");
				}
				retorno.StatusCode = 200;
				retorno.Mensagem = "Sucesso";

				return retorno;
			}
			catch (Exception ex)
			{
				retorno.StatusCode = 400;
				retorno.Mensagem = $"Apresentou erro {ex.Message}";
				return retorno;
			}
		}
	
	}
}
