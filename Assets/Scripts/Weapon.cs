using Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData;

    [SerializeField] Transform muzzle;
    [SerializeField] UnityEvent<int> OnFired;

    [SerializeField] Material regularBulletMaterial;
    [SerializeField] Material redBulletMaterial;

    [SerializeField] GameObject smallBulletPrefab;
    [SerializeField] GameObject largeBulletPrefab;

    private Material selectedMaterial;
    private GameObject selectedBulletPrefab;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && context.ReadValueAsButton())
            Shoot();
    }

    private void Shoot()
    {
        if (!enabled) return;

        for (int i = 0; i < WeaponData.ProjectileCount; i++)
        {
            float randomX = Random.Range(-WeaponData.ProjectileMaxAngle, WeaponData.ProjectileMaxAngle);
            float randomY = Random.Range(-WeaponData.ProjectileMaxAngle, WeaponData.ProjectileMaxAngle);
            Quaternion rotation = transform.rotation * Quaternion.Euler(randomX, randomY, 0f);

            // Use ObjectPool<> instead for better performance
            GameObject projectile = Instantiate(selectedBulletPrefab ?? WeaponData.ProjectilePrefab, muzzle.position, rotation);
            if (selectedMaterial) projectile.GetComponent<Renderer>().material = selectedMaterial;

            projectile.GetComponent<TrailRenderer>().enabled = WeaponData.ProjectileTrail;
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * WeaponData.ProjectileSpeed;

            Destroy(projectile.gameObject, 5f);
        }

        // play sound & muzzle flash
        OnFired?.Invoke(WeaponData.ProjectileCount);
    }

    public void SetBulletColor(bool alternative) => selectedMaterial = alternative ? redBulletMaterial : regularBulletMaterial;
    public void SetBulletSize(bool large) => selectedBulletPrefab = large ? largeBulletPrefab : smallBulletPrefab;

    private void OnDrawGizmosSelected() => Gizmos.DrawSphere(muzzle.position, .02f);
}
