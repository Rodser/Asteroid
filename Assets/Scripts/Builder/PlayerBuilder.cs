namespace Rodlix.Asteroid
{
    internal class PlayerBuilder : IBuilder
    {
        private readonly PLayerData _playerData;

        public PlayerBuilder(PLayerData playerData)
        {
            _playerData = playerData;
        }

        public void Start()
        {
            _playerData.Build();
        }
    }
}