using System;
using UnityEngine;

namespace Rodlix.Asteroid
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private ConfigContainer _configContainer;

        private IServiceLocator<IService> _services;
        private bool _isRunning = false;
        private Ship _player;
        private InputService _inputService;

        private void Start()
        {
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
            var playerBuilder = new ShipBuilder(_configContainer.ShipConfig);
            _player = playerBuilder
                        .BuildBody(Vector3.zero, Quaternion.identity)
                        .BuildWing(_configContainer.ShipConfig.WingConfig)
                        .BuildWeapon(_configContainer.ShipConfig.WeaponConfig)
                        .GetShip();

            var asteroidBuilder = new AsteroidBuilder(_configContainer.AsteroidConfig);
            asteroidBuilder.Build(Size.Large);
        }

        private void RegisterAllServices()
        {
            _inputService = _services.Register(new InputService());
            _services.Register(new WeaponPlayerService(_inputService, _player));
            _services.Register(new PlayerService(_inputService, _player));
            _services.Register(new UFOSpawnerService(_configContainer.UFOConfig, _services));
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