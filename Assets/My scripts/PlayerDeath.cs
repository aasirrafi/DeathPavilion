using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{


    [SerializeField] GameObject PlayerDead;
    [SerializeField] GameObject PlayerArms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DEAD SCREEN
        if (SaveScript.PlayerHealth <= 0)
        {
            SaveScript.PlayerHealth = 0;
            PlayerDead.gameObject.SetActive(true);
            PlayerArms.gameObject.SetActive(false);
        }
        //DEAD SCREEN
    }
}
