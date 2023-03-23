namespace Rodlix.Asteroid
{
    internal class PlayerBuilder : IStart
    {
        private readonly PLayerData _playerData;

        public PlayerBuilder(PLayerData playerData)
        {
            _playerData = playerData;
        }

        public void OnStart()
        {
            _playerData.Init();
        }
    }
}