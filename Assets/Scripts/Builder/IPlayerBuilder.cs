using UnityEngine;

namespace Rodlix.Asteroid
{
    internal interface IPlayerBuilder : IBuilder
    {
        IPlayerBuilder BuildBody(Vector3 position, Quaternion rotation);
        IPlayerBuilder BuildWeapon(WeaponConfig data);
        Ship GetShip();
    }
}