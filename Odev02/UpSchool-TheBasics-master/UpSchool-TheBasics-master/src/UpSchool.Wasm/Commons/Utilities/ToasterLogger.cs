using UpSchool.Domain.Common;
using UpSchool.Domain.Services;

namespace UpSchool.Wasm.Commons.Utilities
{
    public class ToasterLogger:LoggerBase
    {
        private readonly IToasterService toasterService;

        public ToasterLogger(IToasterService toasterService)
        {
            this.toasterService = toasterService;
        }

        public override void Log(string message)
        {
            toasterService.ShowSuccess(message);

          //  base.Log(message);
        }
    }
}
