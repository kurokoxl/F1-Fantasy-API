using AutoMapper;
using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Models.Entites;

namespace F1_Fantasy_API
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //Race
            CreateMap<Race, RaceDto>();
            CreateMap<CreateRaceDto, Race>();
            CreateMap<UpdateRaceDto, Race>();
        }
    }
}
