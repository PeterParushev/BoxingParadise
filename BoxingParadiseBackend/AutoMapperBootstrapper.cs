using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;

namespace BoxingParadiseBackend
{
    public static class AutoMapperBootstrapper
    {
        public static void Initialise()
        {
            ConfigureBoxerMapping();
            ConfigureVenueMapping();
            ConfigureUserMapping();
            ConfigureMatchMapping();
            ConfigureBetMapping();
        }

        private static void ConfigureBetMapping()
        {
            Mapper.CreateMap<Bet, BetDto>();
            Mapper.CreateMap<BetDto, Bet>();
        }

        private static void ConfigureBoxerMapping()
        {
            Mapper.CreateMap<BoxerDto, Boxer>();
            Mapper.CreateMap<Boxer, BoxerDto>();
        }

        private static void ConfigureMatchMapping()
        {
            Mapper.CreateMap<Match, MatchDto>();
            Mapper.CreateMap<MatchDto, Match>();
        }

        private static void ConfigureUserMapping()
        {
            Mapper.CreateMap<User, UserDto>()
                .ForMember(x => x.Password, x => x.Ignore());
            Mapper.CreateMap<UserDto, User>()
                .ForMember(x => x.Rating, x => x.Ignore());
        }

        private static void ConfigureVenueMapping()
        {
            Mapper.CreateMap<Venue, VenueDto>();
            Mapper.CreateMap<VenueDto, Venue>();
        }
    }
}