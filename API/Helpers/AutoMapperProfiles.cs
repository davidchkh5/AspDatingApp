using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
                CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
                // .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => new PhotoDto { Url = p.Url, IsMain = p.IsMain, Id = p.Id })))

            CreateMap<Photo, PhotoDto>();    
            CreateMap<MemberUpdateDto,AppUser>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}