using Blazored.Toast.Services;
using UpSchool.Domain.Services;

namespace UpSchool.Wasm.Services
{
    public class BlazorToastService
    {
        private readonly IToastService _toastService;

        public BlazorToastService(IToastService toastService)
        {
            _toastService = toastService;
        }

        public void ShowSuccess(string message)
        {
            _toastService.ShowSuccess(message);
        }
    }
}
