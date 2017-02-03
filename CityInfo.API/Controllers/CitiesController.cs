using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[Route("api/[controller]")]
	public class CitiesController : Controller
    {
		private readonly ICityRepository _cityRepository;

		public CitiesController(ICityRepository cityRepository)
		{
			_cityRepository = cityRepository;
		}

		[HttpGet]
		public IActionResult GetCities()
		{
			var cityEntities = _cityRepository.GetCities();
			var cities = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

			return Ok(cities);
		}

		[HttpGet("{id}")]
		public IActionResult GetCity(int id, bool includePointsOfInterest = false)
		{
			var city = _cityRepository.GetCity(id, includePointsOfInterest);
			if (city == null)
				return NotFound();

			if (includePointsOfInterest)
			{
				var cityResult = Mapper.Map<CityDto>(city);
				return Ok(cityResult);
			}

			var cityWithoutPointsOfInterestResult = Mapper.Map<CityWithoutPointsOfInterestDto>(city);
			return Ok(cityWithoutPointsOfInterestResult);
		}
    }
}
