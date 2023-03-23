using System;
using UnityEngine;

namespace Rodlix.Asteroid
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private DataContainer _dataContainer;

        private IServiceLocator<IService> _services;
        private IServiceLocator<IStart> _startService;
        private bool _isRunning = false;

        public Spawner Spawner => _spawner;

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
            if (!_isRunning)
                return;
            ToRun();
        }

        public void StartRunning()
        {
            StartServices();
            _isRunning = true;
        }

        public void StopRunning()
        {
            _isRunning = false;
        }

        private void RegisterAllServices()
        {
            _ = _startService.Register(new SpawnAsteroids());
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
            var services = _services.GetAll();
            foreach (IService service in services)
            {
                if (!_isRunning)
                {
                    return;
                }
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