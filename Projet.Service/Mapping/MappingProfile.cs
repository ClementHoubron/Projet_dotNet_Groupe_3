using AutoMapper;
using Projet.Data.Entities;
using Projet.Service;
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
        CreateMap<AnomalieTransaction, AnomalieTransactionDto>().ReverseMap();
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<ClientParticulier, ClientParticulierDto>().ReverseMap();
        CreateMap<ClientProfessionnel, ClientProfessionnelDto>().ReverseMap();
        CreateMap<Adresse, AdresseDto>().ReverseMap();
        CreateMap<AdresseParticulier, AdresseParticulierDto>().ReverseMap();
        CreateMap<AdresseProfessionnel, AdresseProfessionnelDto>().ReverseMap();
    }
}