using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories;
using System.Linq;

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
            DatabaseContext context = new DatabaseContext();
            Mapper.CreateMap<Match, MatchDto>()
                .ForMember(x => x.FirstBoxerDto, x => x.MapFrom(y => y.BoxerOne))
                .ForMember(x => x.SecondBoxerDto, x => x.MapFrom(y => y.BoxerTwo))
                .ForMember(x => x.VenueDto, x => x.MapFrom(y => y.Venue));
            Mapper.CreateMap<MatchDto, Match>()
                .ForMember(x => x.BoxerOne, x => x.MapFrom(y => context.Boxers.FirstOrDefault(z => z.Id == y.FirstBoxerDto.Id)))
                .ForMember(x => x.BoxerTwo, x => x.MapFrom(y => context.Boxers.FirstOrDefault(z => z.Id == y.SecondBoxerDto.Id)))
                .ForMember(x => x.Venue, x => x.MapFrom(y => context.Venues.FirstOrDefault(z => z.Id == y.VenueDto.Id)));
        }

        private static void ConfigureUserMapping()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();
        }

        private static void ConfigureVenueMapping()
        {
            Mapper.CreateMap<Venue, VenueDto>();
            Mapper.CreateMap<VenueDto, Venue>();
        }
    }
}