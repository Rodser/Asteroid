namespace Rodlix.Asteroid
{
    internal class PlayerBuilder : IBuilder
    {
        private readonly PLayerData _playerData;
        private WeaponBuilder _weaponBuilder;

        public Ship Player { get; private set; }

        public PlayerBuilder(PLayerData playerData)
        {
            _playerData = playerData;
            Build();
        }

        public void Build()
        {
            if (Player == null)
            {
                Player = _playerData.Build();
                _weaponBuilder = new WeaponBuilder(_playerData.WeaponData, Player);
                Player.Equip(_weaponBuilder.Weapon);
            }
        }
    }
}