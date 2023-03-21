using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class StartUp : MonoBehaviour
    {
        private List<IController> _controllers = new List<IController>();
        private bool _isRunning = false;
       
        private void Update()
        {
            if (!_isRunning)
                return;
            TickControllers();
        }

        public void StartRunning()
        {
            CreateAllControllers();
            OnStartControllers();
            _isRunning = true;
        }

        public void StopRunning()
        {
            OnStopControllers();
            _isRunning = false;
        }

        private void CreateAllControllers()
        {
            _controllers = new List<IController>
            {
                //new MovementController(),
                //new EnemyDeadController(),
                //new LoseController(),
                //new WinController()
            };
        }
        private void OnStartControllers()
        {
            foreach (IController controller in _controllers)
            {
                try
                {
                    controller.OnStart();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        private void TickControllers()
        {
            foreach (IController controller in _controllers)
            {
                if (!_isRunning)
                {
                    return;
                }
                try
                {
                    controller.Tick();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        private void OnStopControllers()
        {
            foreach (IController controller in _controllers)
            {
                try
                {
                    controller.OnStop();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }
}