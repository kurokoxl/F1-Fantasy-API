using AutoMapper;
using F1_Fantasy_API.Models.Dtos.ConstructorDtos;
using F1_Fantasy_API.Models.Dtos.DriverDtos;
using F1_Fantasy_API.Models.Dtos.DriverSelectionDto;
using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Models.Dtos.RaceResultsDto;
using F1_Fantasy_API.Models.Dtos.TeamDtos;
using F1_Fantasy_API.Models.Dtos.UserDtos;
using F1_Fantasy_API.Models.Entites;

namespace F1_Fantasy_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Race
            CreateMap<Race, RaceDto>();
            CreateMap<CreateRaceDto, Race>();
            CreateMap<UpdateRaceDto, Race>();

            //Driver
            CreateMap<Driver, DriverDto>();
            CreateMap<CreateDriverDto, Driver>();
            CreateMap<UpdateDriverDto, Driver>();

            //DriverRaceResult
            CreateMap<DriverRaceResult, DriverRaceResultDto>();
            CreateMap<CreateDriverRaceResultDto, DriverRaceResult>();

            //Constructor
            CreateMap<Constructor, ConstructorDto>();
            CreateMap<CreateConstructorDto, Constructor>();
            CreateMap<UpdateConstructorDto, Constructor>();

            //user
            CreateMap<User, UserDto>();

            //DriverSelection
            CreateMap<DriverSelection, DriverSelectionDto>()
                           .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver != null ? src.Driver.Name : string.Empty))
                           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Driver != null ? src.Driver.Price : 0));
            CreateMap<CreateDriverSelectionDto, DriverSelection>();
            CreateMap<UpdateDriverSelectionDto, DriverSelection>();

            //Team
            CreateMap<Team, TeamDto>();
            CreateMap<UpdateTeamDto, Team>();
        }
    }
}
