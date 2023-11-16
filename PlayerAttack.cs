using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 10f; 
    public LayerMask dragonLayer; 
    public Camera playerCamera;

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)) 
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        RaycastHit hit;

        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity, dragonLayer))
        {
            
            if (hit.collider.CompareTag("Enemy")) 
            {
                DragonHealth dragonHealth = hit.collider.GetComponent<DragonHealth>();

                if (dragonHealth != null)
                {
                    dragonHealth.TakeDamage(attackDamage);
                }
            }
        }
    }
}


