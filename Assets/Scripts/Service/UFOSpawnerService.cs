using System.Threading.Tasks;
using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class UFOSpawnerService : IService
    {
        private ShipConfig _ufoData;
        private readonly IServiceLocator<IService> _services;

        public UFOSpawnerService(ShipConfig ufoData, IServiceLocator<IService> _services)
        {
            _ufoData = ufoData;
            this._services = _services;
        }

        public async void Tick()
        {
            await SpawnUFO();
        }

        private async Task SpawnUFO()
        {
            await Task.Delay(3000);

            if(_services.Get<UFOService>() != null)
            {
                return;
            }

            var builder = new ShipBuilder(_ufoData);
            var ufo = builder
                .BuildBody(GetPosition(), GetDirection())
                .BuildWeapon(_ufoData.WeaponConfig)
                .GetShip();

            _services.Register(new UFOService(ufo));
            _services.Register(new WeaponUFOService(ufo));
        }

        private Quaternion GetDirection()
        {
            return new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f, 0f);
        }

        private Vector3 GetPosition()
        {
            var cameraView = Camera.main.GetComponent<Camera>();

            Vector3 spawnViewportPosition = cameraView.WorldToViewportPoint(Vector3.zero);
            spawnViewportPosition.x = Random.value;
            spawnViewportPosition.y = Random.value;
            Vector3 spawnPosition = cameraView.ViewportToWorldPoint(spawnViewportPosition);

            return spawnPosition;
        }
    }
}