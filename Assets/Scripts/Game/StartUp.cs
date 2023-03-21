using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rodlix.Asteroid
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private DataContainer _dataContainer;

        private List<IService> _services;
        private bool _isRunning = false;

        public Spawner Spawner => _spawner;

        private void Start()
        {
            DIContainer.Bind(_dataContainer);
            DIContainer.Bind(_spawner);

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
            StopServices();
            _isRunning = false;
        }

        private void RegisterAllServices()
        {
            _services = new List<IService>
            {
                new SpawnAsteroids(),
                //new MovementController(),
                //new EnemyDeadController(),
                //new LoseController(),
                //new WinController()
            };
            // DIContainer.Bind(new SpawnAsteroids());
        }

        private void StartServices()
        {
            foreach (IStartService service in _services)
            {
                try
                {
                    if(service is IStartService)
                    service.OnStart();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        private void ToRun()
        {
            foreach (IService service in _services)
            {
                if (!_isRunning)
                {
                    return;
                }
                try
                {
                    service.Tick();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        private void StopServices()
        {
        }
    }
}