using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;

namespace CityInfo.API
{
	public class CitiesDataStore
	{
		public static CitiesDataStore Current { get; } = new CitiesDataStore();

		public List<CityDto> Cities { get; set; }

		public CitiesDataStore()
		{
			Cities = new List<CityDto>()
			{
				new CityDto {Id = 1, Name = "Houston", Description = "The most populated city in Texas",
					PointsOfInterest = new List<PointOfInterestDto>(){
						new PointOfInterestDto() {Id = 1, Name = "Water Wall", Description = "Semi circular architectural fountain"},
						new PointOfInterestDto() {Id = 2, Name = "The Galleria", Description = "The biggest shopping mall in Houston"}
					}
				},
				new CityDto {Id = 2, Name = "Chicago", Description = "The most beatiful city in US",
					PointsOfInterest = new List<PointOfInterestDto>(){
						new PointOfInterestDto() {Id = 1, Name = "Millenium Park", Description = "The site consists of a civic center and huge park covering 99,000m² with many points of interest and open green lawns. "},
						new PointOfInterestDto() {Id = 2, Name = "Field Museum of Natural History", Description = "The Field Museum was founded in 1893 and has continuously grown"},
						new PointOfInterestDto() {Id = 3, Name = "Skydeck", Description = "If you want a place to see the city from above then this is it"}
					}
				},
				new CityDto {Id = 3, Name = "Mexico City", Description = "Largest urban center in Mexico",
					PointsOfInterest = new List<PointOfInterestDto>(){
						new PointOfInterestDto() {Id = 1, Name = "Chapultepec Castle", Description = "It is the only royal castle in North America that was actually used as the residence of a sovereign: the Mexican Emperor Maximilian I, and his consort Empress Carlota, lived there during the Second Mexican Empire."},
						new PointOfInterestDto() {Id = 2, Name = "Palacio de Bellas Artes", Description = "It is a prominent cultural center in Mexico City, Mexico. It is located on the west side of the historic center of Mexico."},
						new PointOfInterestDto() {Id = 3, Name = "Coyoacan", Description = "Gastronomical stop to try the famous quesadillas, you can also visit the Frida's House."},
					}
				}
			};
		}
	}
}
