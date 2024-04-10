using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("More Daggers");
            DaggerPlayVersion2 daggerPlayVersion2 = other.GetComponentInChildren<DaggerPlayVersion2>();
            if (daggerPlayVersion2)
            {
                daggerPlayVersion2.AddDaggers(daggerPlayVersion2.maxAmmoSize);
                Destroy(gameObject);
            }
        }
       
    }
}
