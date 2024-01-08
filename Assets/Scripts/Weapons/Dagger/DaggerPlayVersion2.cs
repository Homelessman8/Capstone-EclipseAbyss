using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerPlayVersion2 : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public GameObject Dagger;
    public int currentClip, maxClipSize, currentAmmo, maxAmmoSize;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentClip > 0)
            {
                animator.SetBool("isThrow", true);
                currentClip--;
            }
        }
        else
        {
            animator.SetBool("isThrow", false);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            DaggerReload();
        }

    }

    public void DaggerReload()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount: currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddDaggers(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log($"Hit Enemy {1}");
                collision.gameObject.GetComponent<EnemyHealth>().DaggerDamage();
            }

        if (collision.gameObject.CompareTag("MinotaurEnemy"))
        {
            collision.gameObject.GetComponent<MinotaurHealth>().DaggerDamage();
        }
    }
}
