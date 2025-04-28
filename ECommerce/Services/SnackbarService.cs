// Services/SnackbarService.cs
using System;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class SnackbarService
    {
        public event Func<string, bool, int, Task> OnShow;

        public async Task ShowAsync(string message, bool isError = false, int duration = 3000)
        {
            if (OnShow != null)
            {
                await OnShow.Invoke(message, isError, duration);
            }
        }
    }
}
