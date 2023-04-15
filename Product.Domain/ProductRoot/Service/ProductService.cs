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

		public IEnumerable<Produto> ObterTodos()
		{
			var todosProdutos = _produtoRepository.BuscarTodos();

			return todosProdutos;
		}

		public Produto ObterPorId(int idProduto)
		{
			var todosProdutos = _produtoRepository.BuscarPorId(idProduto);

			return todosProdutos;
		}

		public RetornoDto Persist(List<ProdutoDto> produtosDto)
		{
			var retorno = new RetornoDto();

			try
			{
				foreach (var produtoDto in produtosDto)
				{
					var produto = _mapper.Map<Produto>(produtoDto);

					if (produto.dataFabricao >= produto.dataValidade)
					{
						throw new Exception($"Data de Fabricação {produto.dataFabricao.ToString("ddMMyyyy")} do produto {produto.descricaoProduto} não pode ser maior que a data de Validade {produto.dataValidade.ToString("ddMMyyyy")}");
					}

					if (produto.Id != 0)
					{
						var produtoJaExiste = _produtoRepository.BuscarPorId(produto.Id);

						if (produtoJaExiste != null)
						{
							produtoJaExiste.descricaoFornecedor = produtoDto.DescricaoFornecedor;
							produtoJaExiste.cnpj = produtoDto.Cnpj;
							produtoJaExiste.dataFabricao = produtoDto.DataFabricao;
							produtoJaExiste.dataValidade = produtoDto.DataValidade;
							produtoJaExiste.descricaoProduto = produtoDto.DescricaoProduto;
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
						_produtoRepository.Adicionar(produto);
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
					produto.ativo = false;
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
