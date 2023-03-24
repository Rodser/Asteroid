using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class InputService : IService
    {
        public int Move { get; private set; }
        public int Rotate { get; private set; }
        public bool Fire { get; private set; }
        public bool Pause { get; private set; }

        public void Tick()
        {
            Move = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ? -1 : 0;
            Move = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) ? 1 : Move;

            Rotate = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ? -1 : 0;
            Rotate = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) ? 1 : Rotate;

            Fire = Input.GetKey(KeyCode.Space);
            Pause = Input.GetKey(KeyCode.Pause);
            Debug.Log($"{Fire}, {Move}, {Rotate}");
        }
    }
}