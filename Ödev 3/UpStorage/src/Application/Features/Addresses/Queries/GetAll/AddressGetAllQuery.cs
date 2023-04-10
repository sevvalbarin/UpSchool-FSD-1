using MediatR;

namespace Application.Features.Addresses.Query.GetAll
{
    public class AddressGetAllQuery : IRequest<List<AddressGetAllDto>>
    {

        public string? UserId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? AddressType { get; set; }
        public bool? IsDeleted { get; set; } 

        public AddressGetAllQuery(string? userId, int? countryId, int? cityId, int? addressType, bool? isDeleted)
        {
            UserId = userId;
            CountryId = countryId;
            CityId = cityId;
            AddressType = addressType;
            IsDeleted = isDeleted;
        }
    }
}