using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DaggerPlayVersion2 : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody rb;

    public TextMeshProUGUI outOfDaggerText;

    public Renderer render;

    public int currentClip, maxClipSize, currentAmmo, maxAmmoSize;

    void Start()
    {
        render = GetComponent<Renderer>();
        render.enabled = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentClip > 0)
            {
                animator.SetBool("isThrow", true);
                //.addiing a force to the rigid body instead throught the animation
                //rb.AddForce(FirstPersonLook.Instance.transform.forward * 20, ForceMode.Impulse);
                currentClip--;
            }

            else if (currentClip <= 0)
            {
                Debug.Log("Out of Daggers, Find More");
                outOfDaggerText.gameObject.SetActive(true);
                Invoke("DisableText", 1.5f);  
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

        if (currentClip <= 0)
        {
            Invoke("DisableDagger", 0.3f);
        }

        if(currentClip > 0)
        {
            EnableDagger();
        }

    }

    void DisableText()
    {
        outOfDaggerText.gameObject.SetActive(false);
    }

    void EnableDagger()
    {
        render.enabled = true;
    }
    void DisableDagger()
    {
        render.enabled = false;
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
