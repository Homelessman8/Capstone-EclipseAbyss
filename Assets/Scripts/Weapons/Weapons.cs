using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public GameObject axe;
    public GameObject sword;
    public GameObject shield;
    public GameObject dagger;
    public GameObject snowGun;

    void Start()
    {
        axe.gameObject.SetActive(false);
        sword.gameObject.SetActive(true);
        shield.gameObject.SetActive(true);
        dagger.gameObject.SetActive(false);
        snowGun.gameObject.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            axe.gameObject.SetActive(true);
            sword.gameObject.SetActive(false);
            shield.gameObject.SetActive(false);
            dagger.gameObject.SetActive(false);
            snowGun.gameObject.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Alpha2) )
        {
            axe.gameObject.SetActive(false);
            sword.gameObject.SetActive(true);
            shield.gameObject.SetActive(true);
            dagger.gameObject.SetActive(false);
            snowGun.gameObject.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Alpha3))
        {
            axe.gameObject.SetActive(false);
            sword.gameObject.SetActive(false);
            shield.gameObject.SetActive(false);
            dagger.gameObject.SetActive(true);
            snowGun.gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            axe.gameObject.SetActive(false);
            sword.gameObject.SetActive(false);
            shield.gameObject.SetActive(false);
            dagger.gameObject.SetActive(false);
            snowGun.gameObject.SetActive(true);
        }
    }


}
