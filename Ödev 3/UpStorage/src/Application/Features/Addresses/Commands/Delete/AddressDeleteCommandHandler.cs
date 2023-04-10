﻿using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Command.Delete
{
    public class AddressDeleteCommandHandler : IRequestHandler<AddressDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressDeleteCommand request, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.Where(a => a.Id == request.AddressId).FirstOrDefaultAsync();
            if (address == null)
            {
                return new Response<int>("The address was not found.");
            }
            else
            {
                address.IsDeleted = true;
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new Response<int>($"The address name \"{address.Name}\" was successfully deleted.");
            }

        }
    }
}