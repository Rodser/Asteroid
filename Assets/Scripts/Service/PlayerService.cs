using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class PlayerService : IService
    {
        private readonly InputService _inputService;
        private readonly Ship _player;
        private readonly Rigidbody _playerRigidbody;

        private Vector3 _impulseMovement;
        private Vector3 _lastPosition;
        private Vector3 _currentPosition;
        private float _rotation = 0f;
        private float _speed = 0f;

        public PlayerService(InputService inputService, Ship player)
        {
            _inputService = inputService;
            _player = player;
            _playerRigidbody = player.GetComponent<Rigidbody>();
            _lastPosition = player.transform.position;
        }

        public void Tick()
        {
            if(_player.IsDead)
                return;
            
            CheckSpeed();
            Move(_inputService.Move);
            Rotate(_inputService.Rotate);
        }

        private void Move(float move)
        {
            if (_speed <= _player.MaxSpeed)
            {
                _impulseMovement = move * _player.Acceleration * Time.deltaTime * _player.transform.up;
                _playerRigidbody.AddForce(_impulseMovement, ForceMode.Force);
            }
        }

        private void CheckSpeed()
        {
            _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, 0);
            _currentPosition = _player.transform.position;
            _speed = Vector3.Distance(_currentPosition, _lastPosition);
            _lastPosition = _currentPosition;
        }

        private void Rotate(float rotate)
        {
            _rotation = rotate * _player.SpeedRotation;
            _player.transform.Rotate(Vector3.forward, _rotation * Time.deltaTime);
        }
    }
}