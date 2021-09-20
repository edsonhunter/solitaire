using Solitario.Service.Interface;

namespace Solitario.Service
{
    public class SettingsService : ISettingsService
    {
        public int DrawAmount { get; }

        public SettingsService(int drawAmount)
        {
            DrawAmount = drawAmount;
        }
    }
}