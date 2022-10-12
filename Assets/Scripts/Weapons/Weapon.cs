using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    public Vector3 WeaponPosition;
    public Vector3 WeaponRotation;
    public float Cooldown;

    [SerializeField] internal Bullet bulletPrefab;
    [SerializeField] internal Transform bulletSpawnPoint;
    internal float lastShotTime;

    public override void Grab(Transform container)
    {
        ItemGrabber.OnWeaponGrab?.Invoke(this);
    }

    public void Shoot()
    {
        if (Time.time - lastShotTime >= Cooldown)
        {
            GameObject bullet = Instantiate(bulletPrefab.gameObject, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Destroy(bullet, bulletPrefab.FlightTime);
            lastShotTime = Time.time;
        }
    }
}
