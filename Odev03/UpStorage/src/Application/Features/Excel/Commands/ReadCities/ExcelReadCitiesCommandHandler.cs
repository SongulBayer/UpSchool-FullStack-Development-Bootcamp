using Application.Common;
using Application.Common.Interfaces;
using Application.Common.Models.Excel;
using Domain.Entities;
using MediatR;

namespace Application.Features.Excel.Commands.ReadCities
{
    public class ExcelReadCitiesCommandHandler : IRequestHandler<ExcelReadCitiesCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IExcelService _excelService;

        public ExcelReadCitiesCommandHandler(IApplicationDbContext applicationDbContext, IExcelService excelService)
        {
            this._applicationDbContext = applicationDbContext;
            this._excelService = excelService;
        }

        public async Task<Response<int>> Handle(ExcelReadCitiesCommand request, CancellationToken cancellationToken)
        {
            var cityDtos = _excelService.ReadCities(MapCommandToExcelBase64dTO(request));
            var cities = cityDtos.Select(x => x.MapToCity()).ToList();
;           await _applicationDbContext.Cities.AddRangeAsync(cities, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new Response<int>($"{cities.Count} succesfully", cities.Count);
        }

        private ExcelBase64Dto MapCommandToExcelBase64dTO(ExcelReadCitiesCommand command)
        {
            return new ExcelBase64Dto()
            {
                Filr=command.ExcelBase64File
            };
        }
    }
}
