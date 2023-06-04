//using Application.Common.Interfaces;
//using Application.Features.Products.Queries.GetAll;
//using Domain.Entities;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace Application.Features.Queries.GetAll
//{
//    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, List<ProductGetAllDto>>
//    {
//        private readonly IApplicationDbContext _applicationDbContext;

//        public ProductGetAllQueryHandler(IApplicationDbContext applicationDbContext)
//        {
//            _applicationDbContext = applicationDbContext;
//        }
//        public async Task<List<ProductGetAllDto>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
//        {
//            var dbQuery = _applicationDbContext.Products.AsQueryable();

//            dbQuery = dbQuery.Where(x => Convert.ToInt32(x.OrderId) == request.OrderId);

//            if (request.IsDeleted.HasValue) dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);

//            dbQuery = dbQuery.Include(x => Convert.ToInt32(x.OrderId));

//            var products = await dbQuery
//                .Select(x => new ProductGetAllDto(x.OrderId, x.Name, x.Picture, x.Price, x.SalePrice, x.IsDeleted, x.IsOnSale))
//                .ToListAsync(cancellationToken);

//            return products.ToList();
//        }



//    }
//}
