namespace Application.Common.Models.Excel
{
    public class ExcelBase64Dto
    {
        public string Filr { get; set; }
        public ExcelBase64Dto()
        {
                
        }
        public ExcelBase64Dto(string file)
        {
            Filr = file; 
        }
    }
}
//base64 çoğu platfromda kullanılır.