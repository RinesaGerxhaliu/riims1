using AutoMapper;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.DepartamentiDTOs;
using RIIMS.Application.DTOs.EdukimiDTOs;
using RIIMS.Application.DTOs.EksperiencaDTOs;
using RIIMS.Application.DTOs.GjuhaDTOs;
using RIIMS.Application.DTOs.HonorsAndAwardsDTOs;
using RIIMS.Application.DTOs.ImageDTOs;
using RIIMS.Application.DTOs.InstitucioniDTOs;
using RIIMS.Application.DTOs.LicensatDTOs;
using RIIMS.Application.DTOs.MbikqyresITemaveDTOs;
using RIIMS.Application.DTOs.NiveliAkademikDTOs;
using RIIMS.Application.DTOs.NiveliGjuhesorDTOs;
using RIIMS.Application.DTOs.ProjektiDTOs;
using RIIMS.Application.DTOs.PublikimiDTOs;
using RIIMS.Application.DTOs.PunaVullnetareDTOs;
using RIIMS.Application.DTOs.SpecializimiDTOs;
using RIIMS.Application.DTOs.UserDTOs;
using RIIMS.Application.DTOs.UserGjuhetDTOs;
using RIIMS.Domain.Entities;

namespace RIIMS.Application.Mappings
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Eksperienca
            CreateMap<Eksperienca, EksperiencaDTO>();
            CreateMap<AddEksperiencaRequestDTO, Eksperienca>();
            CreateMap<UpdateEksperiencaRequestDTO, Eksperienca>();
            CreateMap<Eksperienca, EksperiencaDTO>()
           .ForMember(dest => dest.EmriInstitucionit, opt => opt.MapFrom(src => src.Institucioni.Emri));

            //HonorsAndAwards
            CreateMap<HonorsAndAwards, HonorsAndAwardsDTO>();
            CreateMap<HonorsAndAwardsDTO, HonorsAndAwards>();
            CreateMap<AddHonorsAndAwardsRequestDTO, HonorsAndAwards>();
            CreateMap<UpdateHonorsAndAwardsRequestDTO, HonorsAndAwards>();
            CreateMap<HonorsAndAwards, HonorsAndAwardsDTO>()
         .ForMember(dest => dest.EmriInstitucionit, opt => opt.MapFrom(src => src.Institucioni.Emri));

            //licensat
            CreateMap<Licensat, LicensatDto>();
            CreateMap<LicensatDto, Licensat>();
            CreateMap<AddLicensatRequestDto, Licensat>();
            CreateMap<UpdateLicensatRequestDto, Licensat>();
            CreateMap<Licensat, LicensatDto>()
           .ForMember(dest => dest.EmriInstitucionit, opt => opt.MapFrom(src => src.Institucioni.Emri));

            //Projekti
            CreateMap<Projekti, ProjektiDto>();
            CreateMap<ProjektiDto, Projekti>();
            CreateMap<AddProjektiRequestDto, Projekti>();
            CreateMap<UpdateProjektiRequestDto, Projekti>();
            CreateMap<Projekti, ProjektiDto>()
          .ForMember(dest => dest.EmriInstitucionit, opt => opt.MapFrom(src => src.Institucioni.Emri));

            //Edukimi
            CreateMap<Edukimi, EdukimiDTO>()
                .ForMember(dest => dest.Institucioni, opt => opt.MapFrom(src => src.Institucioni.Emri))
                .ForMember(dest => dest.NiveliAkademik, opt => opt.MapFrom(src => src.NiveliAkademik.lvl));

            CreateMap<AddEdukimiRequestDTO, Edukimi>()
                .ForMember(dest => dest.Institucioni, opt => opt.Ignore())
                .ForMember(dest => dest.NiveliAkademik, opt => opt.Ignore());

            CreateMap<UpdateEdukimiRequestDTO, Edukimi>()
                .ForMember(dest => dest.Institucioni, opt => opt.Ignore())
                .ForMember(dest => dest.NiveliAkademik, opt => opt.Ignore());

            //Institucioni
            CreateMap<Institucioni, InstitucioniDTO>().ReverseMap();
            CreateMap<AddInstitucioniRequestDTO, Institucioni>().ReverseMap();
            CreateMap<UpdateInstitucioniRequestDTO, Institucioni>().ReverseMap();

            //Publikimi
            CreateMap<Publikimi, PublikimiDTO>();
            CreateMap<PublikimiDTO, Publikimi>();
            CreateMap<AddPublikimiRequestDTO, Publikimi>();
            CreateMap<UpdatePublikimiRequestDTO, Publikimi>();
            CreateMap<Publikimi, PublikimiDTO>()
            .ForMember(dest => dest.EmriDepartamentit, opt => opt.MapFrom(src => src.Departamenti.Emri));

            //PunaVullnetare
            CreateMap<PunaVullnetare, PunaVullnetareDTO>().ReverseMap();
            CreateMap<AddPunaVullnetareRequestDTO, PunaVullnetare>().ReverseMap();
            CreateMap<UpdatePunaVullnetareRequestDTO, PunaVullnetare>().ReverseMap();
            CreateMap<PunaVullnetare, PunaVullnetareDTO>()
            .ForMember(dest => dest.EmriInstitucionit, opt => opt.MapFrom(src => src.Institucioni.Emri));

            //Aftesite
            CreateMap<Aftesite, AftesiaDTO>().ReverseMap();
            CreateMap<AddAftesiaRequestDTO, Aftesite>().ReverseMap();
            CreateMap<UpdateAftesiaRequestDTO, Aftesite>().ReverseMap();
            CreateMap<Aftesite, AftesiaDTO>()
            .ForMember(dest => dest.EmriInstitucionit, opt => opt.MapFrom(src => src.Institucioni.Emri));

            //Gjuhet
            CreateMap<Gjuhet, GjuhetDto>().ReverseMap();
            CreateMap<AddGjuhetDto, Gjuhet>().ReverseMap();
            CreateMap<UpdateGjuhetDto, Gjuhet>().ReverseMap();

            //Specializimet
            CreateMap<Specializimet, SpecializimetDTO>().ReverseMap();
            CreateMap<AddSpecializimetRequestDTO, Specializimet>().ReverseMap();
            CreateMap<UpdateSpecializimetRequestDTO, Specializimet>().ReverseMap();
            CreateMap<Specializimet, SpecializimetDTO>()
            .ForMember(dest => dest.EmriInstitucionit, opt => opt.MapFrom(src => src.Institucioni.Emri));

            //Departamenti
            CreateMap<Departamenti, DepartamentiDto>().ReverseMap();
            CreateMap<AddDepartamentiRequestDto, Departamenti>().ReverseMap();
            CreateMap<UpdateDepartamentiRequestDto, Departamenti>().ReverseMap();
            CreateMap<Departamenti, DepartamentiDto>()
           .ForMember(dest => dest.EmriInstitucionit, opt => opt.MapFrom(src => src.Institucioni.Emri));

            //User
            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.NiveliAkademik, opt => opt.MapFrom(src => src.NiveliAkademik.lvl))
            .ForMember(dest => dest.NiveliAkademikId, opt => opt.MapFrom(src => src.NiveliAkademik.Id))
            .ReverseMap();
            CreateMap<AddUserRequestDTO, User>()
                .ForMember(dest => dest.NiveliAkademik, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<UpdateUserRequestDTO, User>()
                .ForMember(dest => dest.NiveliAkademik, opt => opt.Ignore()) // Handle separately
                .ReverseMap();
            CreateMap<NiveliAkademik, UserDTO>()
                .ForMember(dest => dest.NiveliAkademik, opt => opt.MapFrom(src => src.lvl))
                .ReverseMap();

            //NiveliGjuhesor
            CreateMap<NiveliGjuhesor, NiveliGjuhesorDTO>().ReverseMap();
            CreateMap<AddNiveliGjuhesorRequestDTO, NiveliGjuhesor>().ReverseMap();
            CreateMap<UpdateNiveliGjuhesorRequestDto, NiveliGjuhesor>().ReverseMap();

            //UserGjuhet
            CreateMap<UserGjuhet, UserGjuhetDTO>().ReverseMap();
            CreateMap<AddUserGjuhetRequestDTO, UserGjuhet>().ReverseMap();
            CreateMap<UpdateUserGjuhetRequestDTO, UserGjuhet>().ReverseMap();
            CreateMap<UserGjuhet, UserGjuhetDTO>()
            .ForMember(dest => dest.EmriGjuhes, opt => opt.MapFrom(src => src.Gjuha.EmriGjuhes))
            .ForMember(dest => dest.NiveliGjuhesor, opt => opt.MapFrom(src => src.NiveliGjuhesor.Niveli));
            CreateMap<UserGjuhet, UserGjuhetDTO>()
               .ForMember(dest => dest.EmriGjuhes, opt => opt.MapFrom(src => src.Gjuha.EmriGjuhes))
               .ForMember(dest => dest.NiveliGjuhesor, opt => opt.MapFrom(src => src.NiveliGjuhesor.Niveli));

            CreateMap<AddUserGjuhetRequestDTO, UserGjuhet>()
                .ForMember(dest => dest.Gjuha, opt => opt.Ignore())
                .ForMember(dest => dest.NiveliGjuhesor, opt => opt.Ignore());

            CreateMap<UpdateUserGjuhetRequestDTO, UserGjuhet>()
                .ForMember(dest => dest.Gjuha, opt => opt.Ignore())
                .ForMember(dest => dest.NiveliGjuhesor, opt => opt.Ignore());

            //NiveliAkademik
            CreateMap<NiveliAkademik, NiveliAkademikDto>().ReverseMap();
            CreateMap<AddNiveliAkademikRequestDto, NiveliAkademik>().ReverseMap();
            CreateMap<UpdateNiveliAkademikRequestDto, NiveliAkademik>().ReverseMap();

            CreateMap<MbikqyresITemave, MbikqyresITemaveDTO>()
           .ForMember(dest => dest.EmriDepartamentit, opt => opt.MapFrom(src => src.Departamenti.Emri))
           .ReverseMap();

            CreateMap<AddMbikqyresRequestDTO, MbikqyresITemave>()
                .ReverseMap();

            CreateMap<UpdateMbikqyresRequestDTO, MbikqyresITemave>()
                .ReverseMap();

            CreateMap<ImageUploadRequestDTO, Image>()
                .ReverseMap();

            CreateMap<ImageDTO, Image>()
                .ReverseMap();
        }
    }
}
