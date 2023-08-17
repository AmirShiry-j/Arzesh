using Application.Common.CreateDtoes;
using Application.ProfileService.Command;
using Application.ProfileService.Query;
using AutoMapper;
using Domain.Users;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;
using WebApi.ModelsAndDtoes.Profile;

namespace WebApi.Tools.AutoMapper
{
    public class User_Mapping_EndPointProfile : Profile
    {
        public User_Mapping_EndPointProfile()
        {
            CreateMap<EditProfileDto, EditProfileApiDto>()
                .ForMember(apiDto => apiDto.UserType, dto => dto.MapFrom(p => (UserType) p.UserType)).ReverseMap();


            //CreateMap<,>().ReverseMap();

        }
    }
}
