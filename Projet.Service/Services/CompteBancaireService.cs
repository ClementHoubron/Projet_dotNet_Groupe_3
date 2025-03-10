using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Projet.Data.Repositories;
using System;

/// <summary>
/// Summary description for CompteBancaireService
/// </summary>
public class CompteBancaireService
{
	private readonly CompteBancaireRepository _repo;
	private readonly IMapper _mapper;
	public CompteBancaireService()
	{
		_repo = new CompteBancaireRepository();
		_mapper = MappingConfig.Mapper;
	}

    public async void AddCompte(CompteBancaireDto compteDto)
    {
        var compteEntity = _mapper.Map<CompteBancaire>(compteDto);
        _repo.Add(compteEntity);
    }

    public async Task<CompteBancaireDto> GetCompteByNum(string numCompte)
	{
		var compteEntity = await _repo.GetByNum(numCompte);
		var compteDto = _mapper.Map<CompteBancaireDto>(compteEntity);
		return compteDto;
	}
	public async Task<List<CompteBancaireDto>> GetComptes()
	{
		var comptesEntities = await _repo.GetAll();
		var comptesDto = comptesEntities.Select(compte => _mapper.Map<CompteBancaireDto>(compte)).ToList<CompteBancaireDto>();
		return comptesDto;
	}

}
