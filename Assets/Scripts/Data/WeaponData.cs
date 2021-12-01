using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class WeaponData : ScriptableObject
    {
        public GameObject ProjectilePrefab;
        public bool ProjectileTrail;
        public float ProjectileSpeed;
        public int ProjectileCount;
        public float ProjectileMaxAngle;
    }
}
