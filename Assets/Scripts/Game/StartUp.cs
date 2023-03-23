using System;
using UnityEngine;

namespace Rodlix.Asteroid
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private DataContainer _dataContainer;

        private IServiceLocator<IService> _services;
        private IServiceLocator<IStart> _startService;
        private bool _isRunning = false;
        private PlayerBuilder _playerBuilder;
        private AsteroidBuilder _asteroidBuilder;
        private InputService _inputService;

        private void Start()
        {
            Container.Bind(_dataContainer);

            _startService = new ServiceLocator<IStart>();
            _services = new ServiceLocator<IService>();

            RegisterAllServices();
            StartRunning();
        }

        private void Update()
        {
            ToRun();
        }

        private void RegisterAllServices()
        {
            _playerBuilder = _startService.Register(new PlayerBuilder(_dataContainer.PlayerData));
            _asteroidBuilder = _startService.Register(new AsteroidBuilder());

            _inputService = _services.Register(new InputService());
            _services.Register(new WeaponService(_inputService, _dataContainer.WeaponData));
        }

        private void StartRunning()
        {
            StartServices();
            _isRunning = true;
        }

        private void StopRunning()
        {
            _isRunning = false;
        }

        private void StartServices()
        {
            var services = _startService.GetAll();
            foreach (IStart service in services)
            {
                try
                {
                    service?.OnStart();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
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