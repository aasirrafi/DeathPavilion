using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LungsPower : MonoBehaviour
{
    [SerializeField] Image LungUI;
    [SerializeField] float DrainTimeLung = 20.0f;
    [SerializeField] float LungPower;
    [SerializeField] float RefillRate = 0.25f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift ) && (Input.GetKey(KeyCode.W)))
        {
            LungUI.fillAmount -= 1.0f / DrainTimeLung * Time.deltaTime;
            SaveScript.PowerOfLung = LungPower;
            LungPower = LungUI.fillAmount;

        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
                LungUI.fillAmount = LungUI.fillAmount + RefillRate * Time.deltaTime;
            
        }


    }
}
