using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DaggerPlay : MonoBehaviour
{
    //[SerializeField]
    //private Animator animator;

    [Header("References")]
    public GameObject daggerPrefab;
    public Transform daggerPos;
    public Transform cam;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float daggerForce;
    public float throwUpwardForce;

    bool readyToThrow;

    void Start()
    {
      readyToThrow = true; 
    }

    void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
          ShootDagger();
        } 
       
    }

    void ShootDagger()
    {
        readyToThrow = false;
        GameObject dagger = Instantiate(daggerPrefab, daggerPos.position, transform.rotation);
        //animator.SetBool("isThrow", true);
        Rigidbody rb = dagger.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - daggerPos.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * daggerForce + transform.up * throwUpwardForce;
        rb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
        
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Hit Enemy {1}");
            Actions.OnEnemyAttacked?.Invoke();
            collision.gameObject.GetComponent<Enemy>().currentHealth -= 1;
            Debug.Log("Hit Object");
        }

    }
}
