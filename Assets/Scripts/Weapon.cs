using Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData;

    [SerializeField] Transform muzzle;
    [SerializeField] UnityEvent<int> OnFired;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && context.ReadValueAsButton())
            Shoot();
    }

    private void Shoot()
    {
        for (int i = 0; i < WeaponData.ProjectileCount; i++)
        {
            float randomX = Random.Range(-WeaponData.ProjectileMaxAngle, WeaponData.ProjectileMaxAngle);
            float randomY = Random.Range(-WeaponData.ProjectileMaxAngle, WeaponData.ProjectileMaxAngle);
            Quaternion rotation = transform.rotation * Quaternion.Euler(randomX, randomY, 0f);

            GameObject projectile = Instantiate(WeaponData.ProjectilePrefab, muzzle.position, rotation);
            projectile.GetComponent<TrailRenderer>().enabled = WeaponData.ProjectileTrail;
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * WeaponData.ProjectileSpeed;

            Destroy(projectile.gameObject, 5f);
        }

        // play sound
        // muzzle flash

        OnFired?.Invoke(WeaponData.ProjectileCount);
    }

    private void OnDrawGizmosSelected() => Gizmos.DrawSphere(muzzle.position, .02f);
}
