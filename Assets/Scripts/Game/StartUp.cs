using System;
using UnityEngine;

namespace Rodlix.Asteroid
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private DataContainer _dataContainer;

        private IServiceLocator<IService> _services;
        private bool _isRunning = false;
        private Ship _player;
        private InputService _inputService;

        private void Start()
        {
            Container.Bind(_dataContainer);
            _services = new ServiceLocator<IService>();

            BuildObjects();
            RegisterAllServices();
            StartRunning();
        }

        private void Update()
        {
            ToRun();
        }

        private void BuildObjects()
        {
            var playerBuilder = new PlayerBuilder(_dataContainer.PlayerData);
            _player = (Ship)playerBuilder
                                    .BuildBody(Vector3.zero, Quaternion.identity)
                                    .BuildWeapon(_dataContainer.PlayerData.WeaponData)
                                    .GetObject();

            var asteroidBuilder = new AsteroidBuilder();
            var ofoBuilder = new UFOBuilder(_dataContainer.UfoData);
        }

        private void RegisterAllServices()
        {
            _inputService = _services.Register(new InputService());
            _services.Register(new WeaponPlayerService(_inputService, _player.Weapon));
            _services.Register(new PlayerService(_inputService, _player));
        }

        private void StartRunning()
        {
            _isRunning = true;
        }

        private void StopRunning()
        {
            _isRunning = false;
        }

        private void ToRun()
        {
            if (!_isRunning)
            {
                return;
            }
            var services = _services.GetAll();
            foreach (IService service in services)
            {
                try
                {
                    service?.Tick();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }
}