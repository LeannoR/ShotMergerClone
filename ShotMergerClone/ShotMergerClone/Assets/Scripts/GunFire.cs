using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Transform noozle;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;
    public float nextFire = 0f;

    public void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var bullet = Instantiate(bulletPrefab, noozle.position, noozle.rotation);
            bullet.GetComponent<Rigidbody>().velocity = noozle.forward * bulletSpeed;
        }
    }
}
