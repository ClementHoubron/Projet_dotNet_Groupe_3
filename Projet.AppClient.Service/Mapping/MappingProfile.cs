using AutoMapper;
using Projet.AppClient.Data.Entities;
using Projet.AppClient.Service;
using System;

/// <summary>
/// Summary description for MappingProfile
/// </summary>
class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CompteBancaire, CompteBancaireDto>().ReverseMap();
        CreateMap<TransactionBancaire, TransactionBancaireDto>().ReverseMap();
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<ClientParticulier, ClientParticulierDto>().ReverseMap();
        CreateMap<ClientProfessionnel, ClientProfessionnelDto>().ReverseMap();
        CreateMap<Adresse, AdresseDto>().ReverseMap();
        CreateMap<AdresseParticulier, AdresseParticulierDto>().ReverseMap();
        CreateMap<AdresseProfessionnel, AdresseProfessionnelDto>().ReverseMap();
        CreateMap<Admin, AdminDto>().ReverseMap();

        CreateMap<TransactionImportDto, TransactionBancaire>()
                .ForMember(dest => dest.Montant, o => o.MapFrom(src => src.Montant * src.TauxDeChange))
                .ForMember(dest => dest.Devise, o => o.MapFrom(src => "EUR"))
                .ForMember(dest => dest.Id, o => o.MapFrom(src => 0))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
    }
}