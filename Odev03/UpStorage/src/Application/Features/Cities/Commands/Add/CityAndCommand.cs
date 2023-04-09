using Application.Common;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Cities.Commands.Add
{
    public class CityAndCommand:IRequest<Response<int>>
    {

        [Required]
        [MinLength(6)]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
//Cqrs de commandler requestin son halini dönmz