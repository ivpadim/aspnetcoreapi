﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
	public interface ICityRepository
	{
		bool CityExists(int cityId);
		IEnumerable<City> GetCities();
		City GetCity(int cityId, bool includePointsOfInterest);
		IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);
		PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);

		void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
		void DeletePointOfInterest(PointOfInterest pointOfInterest);
		bool Save();
	}
}
