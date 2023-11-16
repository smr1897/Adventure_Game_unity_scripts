using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    public float health;
   // RagdollManager ragdollManager;
    [HideInInspector] public bool isDead;
    public Animator DragonAnim;
    public SkyChanger changer;

    private void Start()
    {
       // ragdollManager = GetComponent<RagdollManager>();
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                //changer.DragonKilled();
                EnemyDeath();
            }
            else
            {
                Debug.Log("Hit");
            }
        }
    }

    void EnemyDeath()
    {
        DragonAnim.SetBool("Run", false);
        DragonAnim.SetBool("Idle", false);
        DragonAnim.SetBool("StayIdle", false);
        DragonAnim.SetBool("Attack", false);
        DragonAnim.SetBool("MouthAttack", false);
        DragonAnim.SetBool("Die", true);
        //DragonAnim.SetBool("Attack", false);
        //ragdollManager.TriggerRagdoll();
        //Debug.Log("Death");
        changer.DragonKilled();
        Object.Destroy(gameObject, 5f);
        //changer.DragonKilled();
    }
}
