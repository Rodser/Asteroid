using UnityEngine;

namespace Rodlix.Asteroid
{
    internal interface IAircraft
    {
        Weapon Weapon { get; }
        Transform PointWeapon { get; }
    }
}