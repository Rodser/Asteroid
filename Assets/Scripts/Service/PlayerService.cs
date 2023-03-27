namespace Rodlix.Asteroid
{
    internal class PlayerService : IService
    {
        private InputService _inputService;
        private Ship _player;

        public PlayerService(InputService inputService, Ship player)
        {
            _inputService = inputService;
            _player = player;
        }

        public void Tick()
        {
            _player.CheckSpeed();
            _player.Move(_inputService.Move);
            _player.Rotate(_inputService.Rotate);
        }
    }
}