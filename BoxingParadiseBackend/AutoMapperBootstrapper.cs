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
            DatabaseContext context = new DatabaseContext();
            Mapper.CreateMap<Bet, BetDto>().
                ForMember(x => x.BoxerDto, x => x.MapFrom(y => y.Boxer)).
                ForMember(x => x.MatchDto, x => x.MapFrom(y => y.Match))
                .ForMember(x => x.UserDto, x => x.MapFrom(y => y.User));
            Mapper.CreateMap<BetDto, Bet>().
                ForMember(x => x.Boxer, x => x.MapFrom(y => context.Boxers.FirstOrDefault(z => z.Id == y.Id))).
                ForMember(x => x.Match, x => x.MapFrom(y => context.Matches.FirstOrDefault(z => z.Id == y.Id))).
                ForMember(x => x.User, x => x.MapFrom(y => context.Users.FirstOrDefault(z => z.Id == y.Id)));
            //context.Dispose();
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
                .ForMember(x => x.BoxerOneDto, x => x.MapFrom(y => y.BoxerOne))
                .ForMember(x => x.BoxerTwoDto, x => x.MapFrom(y => y.BoxerTwo))
                .ForMember(x => x.VenueDto, x => x.MapFrom(y => y.Venue));
            Mapper.CreateMap<MatchDto, Match>()
                .ForMember(x => x.BoxerOne, x => x.MapFrom(y => y.BoxerOneDto))
                .ForMember(x => x.BoxerTwo, x => x.MapFrom(y => y.BoxerTwoDto))
                .ForMember(x => x.Venue, x => x.MapFrom(y => y.VenueDto));
            //context.Dispose();
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