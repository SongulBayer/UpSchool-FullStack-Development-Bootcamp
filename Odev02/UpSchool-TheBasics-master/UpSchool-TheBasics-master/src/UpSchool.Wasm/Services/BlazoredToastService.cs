using UpSchool.Domain.Services;
using Blazored.Toast.Services;
namespace UpSchool.Wasm.Services
{
    public class BlazoredToastService : IToasterService
    {
        private readonly IToasterService _toastService;

        //Servisin dışarıdan enjekte edileceğini yaptık. (Ctor injection)
        public BlazoredToastService(IToasterService toastService)
        {
            _toastService = toastService;
        }

        public void ShowSuccess(string message)
        {
            _toastService.ShowSuccess(message);

        }
    }
}
