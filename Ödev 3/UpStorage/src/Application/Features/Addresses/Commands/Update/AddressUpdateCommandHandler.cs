using Application.Common.Interfaces;
using Domain.Common;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Command.Update
{
    public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressUpdateCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.FirstOrDefaultAsync(x => x.Id == request.AddressId);

            address.AddressLine1 = request.AddressLine1;
            address.AddressLine2 = request.AddressLine2;
            address.CityId = request.CityId;
            address.CountryId = request.CountryId;
            address.ModifiedOn = DateTimeOffset.Now;
            address.ModifiedByUserId = null;
            address.District = request.District;
            address.Name = request.Name;
            address.PostCode = request.PostCode;
            address.AddressType = (AddressType)request.AddressType;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"The address named \"{address.Name}\" was successfully updated.");
        }
    }
}