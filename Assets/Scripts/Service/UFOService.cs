using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class UFOService : IService
    {
        private readonly Ship _ufo;

        public UFOService(Ship ufo)
        {
            _ufo = ufo;
        }

        public void Tick()
        {
            if(_ufo.IsDead)
                return;
            
            _ufo.transform.Rotate(Vector3.forward, 25 * Time.deltaTime);
        }
    }
}