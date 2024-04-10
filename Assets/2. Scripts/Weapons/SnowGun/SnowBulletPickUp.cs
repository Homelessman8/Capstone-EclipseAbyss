using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBulletPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("More Bullets");
            SnowGun snowGun = other.GetComponentInChildren<SnowGun>();
            if (snowGun)
            {
                snowGun.AddBullets(snowGun.maxAmmoSize);
                Destroy(gameObject);
            }
        }
    }

}
