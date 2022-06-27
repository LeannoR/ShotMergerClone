using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiveFire : MonoBehaviour
{
    private float lastShootTime;
    public Transform noozle;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public static float fireRate = 1f;
    public static float nextFire = 1f;
    public static int collectiveValue = 1;
    public static int currentShootPerSec = 1;

    public void Update()
    {
        if(gameObject.tag == "Collected")
        {
            ShootCollective();
        }
    }
    public void ShootCollective()
    {
        if (Time.time > lastShootTime + fireRate)
        {
            lastShootTime = Time.time;
            var bullet = Instantiate(bulletPrefab, noozle.position, noozle.rotation);
            bullet.GetComponent<Rigidbody>().velocity = noozle.forward * bulletSpeed;
        }
    }
    public int ShootPerSec()
    {
        currentShootPerSec = ParentGun.instance.GetShootPerSec();
        currentShootPerSec += 1;
        fireRate = 1 / currentShootPerSec;
        return currentShootPerSec;
    }
}
