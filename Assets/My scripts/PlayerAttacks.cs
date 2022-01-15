using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.HaveKnife == true)
        {
            
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Anim.SetTrigger("KnifeLMB");
                SaveScript.EnemyDamageDead = 25;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Anim.SetTrigger("KnifeRMB");
                SaveScript.EnemyDamageDead = 200;
                



            }
        }

        if (SaveScript.HaveBat == true)
        {


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Anim.SetTrigger("BatRMB");
                SaveScript.EnemyDamageDead = 25;

            }

           
        }

        if (SaveScript.HaveAxe == true)
        {


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Anim.SetTrigger("AxeLMB");
                SaveScript.EnemyDamageDead = 50;

            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Anim.SetTrigger("AxeRMB");
                SaveScript.EnemyDamageDead = 50;

            }
        }
        

        

    }
}
