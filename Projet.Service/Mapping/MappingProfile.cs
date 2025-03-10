using AutoMapper;
using Projet.Data.Entities;
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

    }
}