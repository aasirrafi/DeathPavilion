using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour

{

    private bool HasDied = false;
    //private Animator AnimatorForDeath;
    [SerializeField] Animator Anim;
    [SerializeField] GameObject EnemyObject;

    public static int EnemyGetsDamage = 50;
    public int EnemyHealth = 100;


    [SerializeField] GameObject EnemyWeapon;
    [SerializeField] GameObject EnemyWeaponPickup;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            if (HasDied == false)
            {
                Anim.SetTrigger("Death");
                HasDied = true;
                EnemyWeapon.gameObject.SetActive(false);
                EnemyWeaponPickup.gameObject.SetActive(true);
                Destroy(EnemyObject, 25f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerWeaponDamage"))
        {
            EnemyHealth -= SaveScript.EnemyDamageDead;
        }
        if (other.gameObject.CompareTag("PlayerWeaponDamage"))
        {
            Anim.SetTrigger("SmallReact");
        }
    }


}
