namespace Rodlix.Asteroid
{
    internal interface IStartService : IService
    {
        void OnStart();
        void OnStop();
    }
}