using AutoMapper;
using DAL.Entities;
using Services.DTOs;


namespace Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Vehicle
        CreateMap<Vehicle, VehicleDTO>();
        CreateMap<VehicleDTO, Vehicle>();

        // Customer
        CreateMap<Customer, CustomerDTO>();
        

        // Rental
        CreateMap<Rental, RentalDTO>();
    

        // Payment
        CreateMap<Payment, PaymentDTO>();
    }
}