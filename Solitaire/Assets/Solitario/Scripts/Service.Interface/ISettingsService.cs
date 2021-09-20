namespace Solitario.Service.Interface
{
    public interface ISettingsService : IService
    {
        int DrawAmount { get; }
    }
}