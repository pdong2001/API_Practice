using AutoMapper;
using Library.DataAccessLayer.Models;
using Library.ServiceLayer.Tours;

namespace Run
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tour, TourDto>();
            CreateMap<InsertUpdateTourDto, Tour>();
        }
    }
}
