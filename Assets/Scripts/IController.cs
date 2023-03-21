namespace Assets.Scripts
{
    internal interface IController
    {
        void OnStart();
        void OnStop();
        void Tick();
    }
}