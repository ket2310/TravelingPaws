using AutoMapper;
using TravelingPawsAPI.Maps;
using TravelingPawsAPI.Models;

namespace TravelingPaws.Models
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, QuoteMap>();
            CreateMap<QuoteMap, Quote>();

            CreateMap<PetOwner, PetOwnerMap>()
                .ForMember(dest => dest.ConfirmEmail,
                opt => opt.MapFrom(src => src.Email));
            CreateMap<PetOwnerMap, PetOwner>();
        }
    }
}
