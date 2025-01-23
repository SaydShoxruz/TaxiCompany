using AutoMapper;
using TaxiCompany.Application.Models.CarsOwner;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class DriverProfile : Profile
{
    public DriverProfile()
    {

        CreateMap<CreateDriverModel, Driver>();

        CreateMap<UpdateDriverModel, Driver>();

        CreateMap<Driver, DriverResponseModel>();

    }
}
