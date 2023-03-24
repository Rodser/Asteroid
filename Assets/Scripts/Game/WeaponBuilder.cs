namespace Rodlix.Asteroid
{
    internal class WeaponBuilder : IBuilder
    {
        private readonly DataContainer _data;
        private Weapon _weapon;

        public WeaponBuilder(DataContainer data)
        {
            _data = data;
            _weapon = data.WeaponDatas[0].Build();
        }

        internal Weapon Weapon => _weapon;

        public void Start()
        {
        }
    }
}