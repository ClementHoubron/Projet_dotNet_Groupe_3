using AutoMapper;
using System;

/// <summary>
/// Summary description for MappingProfile
/// </summary>
class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CompteBancaire, CompteBancaireDto>().ReverseMap();

    }
}