using Application.Common.Models.Excel;

namespace Application.Common.Interfaces
{
    public interface IExcelService
    {
        List<ExcelCityDto> ReadCities(ExcelBase64Dto excelDto);
        List<ExcelCountryDto> ReadCountries(ExcelBase64Dto excelDto);
    }
}

//Metotların imzasını burada atıyoruz infrastrcucture içinde içini dolduruyoruz