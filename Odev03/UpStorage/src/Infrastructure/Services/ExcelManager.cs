using Application.Common.Interfaces;
using Application.Common.Models.Excel;
using ExcelMapper;
using Infrastructure.Comman.Excel.ExcelManager;

namespace Infrastructure.Services
{
    public class ExcelManager : IExcelService
    {
        public List<ExcelCityDto> ReadCities(ExcelBase64Dto excelDto)
        {
            // We convert base64string to byte[]
            var fileBytes = Convert.FromBase64String(excelDto.Filr);

            using var stream = new MemoryStream(fileBytes);
            using var importer = new ExcelImporter(stream);

            importer.Configuration.RegisterClassMap<ExcelCityDtoConfiguration>();

            ExcelSheet sheet = importer.ReadSheet();

            var cityDtos = sheet.ReadRows<ExcelCityDto>().ToList();


            return cityDtos;
        }

        public List<ExcelCountryDto> ReadCountries(ExcelBase64Dto excelDto)
        {
            // We convert base64string to byte[]
            var fileBytes = Convert.FromBase64String(excelDto.Filr);

            using var stream = new MemoryStream(fileBytes);
            using var importer = new ExcelImporter(stream);

            importer.Configuration.RegisterClassMap<ExcelCountryDtoConfiguration>();

            ExcelSheet sheet = importer.ReadSheet();

            var countryDtos = sheet.ReadRows<ExcelCountryDto>().ToList();


            return countryDtos;
        }
    }
}
//manager = class