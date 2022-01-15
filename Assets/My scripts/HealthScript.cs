using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Text HealthText;
    [SerializeField] Text ArmourText;

    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = SaveScript.PlayerHealth + "%";
        ArmourText.text = SaveScript.ArmourHealth + "%";

    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.HealthChanged == true)
        {
            SaveScript.HealthChanged = false;
            HealthText.text = SaveScript.PlayerHealth + "%";
            ArmourText.text = SaveScript.ArmourHealth + "%";
        }
        
    }
}
