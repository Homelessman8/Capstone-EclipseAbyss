using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGun : MonoBehaviour
{
    public GameObject snowBullet;
    public float bulletForce = 20f;
    public Transform bulletPoint;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(snowBullet, bulletPoint.position, bulletPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletPoint.right * bulletForce, ForceMode.Impulse);
    }
}
