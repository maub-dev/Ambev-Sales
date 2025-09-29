using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, IQueryable<GetAllSalesResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Initializes a new instance of GetAllSalesHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for GetUserCommand</param>
        public GetAllSalesHandler(
            ISaleRepository saleRepository,
            IMapper mapper,
            IConfigurationProvider configurationProvider)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        public async Task<IQueryable<GetAllSalesResult>> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
        {
            var products = _saleRepository.GetAll();

            return await Task.FromResult(products.ProjectTo<GetAllSalesResult>(_configurationProvider));
        }
    }
}
