using AutoMapper;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class MappingConfig
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        //Classe de configuration 
        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<MappingProfile>()
            );
        var mapper = config.CreateMapper();
        return mapper;

    });

    //Permet de faire appel au mappage
    public static IMapper Mapper => Lazy.Value;


}