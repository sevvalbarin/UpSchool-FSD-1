﻿using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Command.HardDelete
{
    public class AddressHardDeleteCommandHandler : IRequestHandler<AddressHardDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressHardDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressHardDeleteCommand request, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.Where(a => a.Id == request.AddressId).FirstOrDefaultAsync();
            _applicationDbContext.Addresses.Remove(address);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"The address name \"{address.Name}\" was successfully deleted.");
        }
    }
}