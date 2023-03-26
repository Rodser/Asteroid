using UnityEngine;

namespace Rodlix.Asteroid
{
    internal interface IBuilder
    {
        IBuilder BuildBody(Vector3 position, Quaternion rotation);
        IBuilder BuildWeapon(WeaponData data);
        Object GetObject();
    }
}