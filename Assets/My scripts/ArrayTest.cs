using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour
{
    public GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<= weapons.Length;i++)
        {
            weapons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
