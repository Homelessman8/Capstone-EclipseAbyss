using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGun : MonoBehaviour
{
    public GameObject snowBullet;
    public float bulletForce = 20f;
    public Transform bulletPoint;

    public int currentClip, maxClipSize, currentAmmo, maxAmmoSize;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            BulletReload();
        }
    }

    void Shoot()
    {
        if (currentClip > 0)
        {
            GameObject bullet = Instantiate(snowBullet, bulletPoint.position, bulletPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bulletPoint.right * bulletForce, ForceMode.Impulse);
            currentClip--;
        }
        
    }

    public void BulletReload()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddBullets(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }
}
