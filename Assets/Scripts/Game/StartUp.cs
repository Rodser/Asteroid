using System;
using UnityEngine;

namespace Rodlix.Asteroid
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private DataContainer _dataContainer;

        private IServiceLocator<IService> _services;
        private IServiceLocator<IBuilder> _builders;
        private bool _isRunning = false;
        private PlayerBuilder _playerBuilder;
        private AsteroidBuilder _asteroidBuilder;
        private UFOBuilder _ofoBuilder;
        private WeaponBuilder _weaponBuilder;
        private InputService _inputService;

        private void Start()
        {
            Container.Bind(_dataContainer);

            _builders = new ServiceLocator<IBuilder>();
            _services = new ServiceLocator<IService>();

            RegisterAllBuilders();
            RegisterAllServices();
            StartRunning();
        }

        private void Update()
        {
            ToRun();
        }

        private void RegisterAllBuilders()
        {
            _playerBuilder = _builders.Register(new PlayerBuilder(_dataContainer.PlayerData));
            _asteroidBuilder = _builders.Register(new AsteroidBuilder());
            _ofoBuilder = _builders.Register(new UFOBuilder(_dataContainer.UfoData));
        }

        private void RegisterAllServices()
        {
            _inputService = _services.Register(new InputService());
            _services.Register(new WeaponPlayerService(_inputService, _playerBuilder.Player.Weapon));
            _services.Register(new PlayerService(_inputService, _playerBuilder.Player));
        }

        private void StartRunning()
        {
            StartBuild();
            _isRunning = true;
        }

        private void StopRunning()
        {
            _isRunning = false;
        }

        private void StartBuild()
        {
            var builders = _builders.GetAll();
            foreach (IBuilder builder in builders)
            {
                try
                {
                    builder?.Build();
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