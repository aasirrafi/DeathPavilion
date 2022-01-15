using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    [SerializeField] int PlayerHealthDamage = 20;
    [SerializeField] Animator HurtAnim;
    private bool HitActive = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerDamageCube"))
        {
            if(HitActive == false)
            {
                HitActive = true;
                HurtAnim.SetTrigger("Hurt");
                SaveScript.HealthChanged = true;

                if (SaveScript.ArmourHealth <= 0)
                {
                    SaveScript.PlayerHealth -= PlayerHealthDamage;
                }
                else
                {
                    SaveScript.ArmourHealth -= PlayerHealthDamage;
                }
                Inventory.HealthEqualsToHundred();


            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerDamageCube"))
        {
            if (HitActive == true)
            {
                HitActive = false;
            }
        }

    }
}
