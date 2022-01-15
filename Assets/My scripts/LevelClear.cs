using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour
{

    bool Level1 = false;

    [SerializeField] GameObject Cleared;
    [SerializeField] GameObject Blockade;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TimedCheck());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cleared.gameObject.SetActive(true);
            Level1 = true;
            Blockade.gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //Time.timeScale = 0f;
        }
    }

    IEnumerator TimedCheck()
    {

        if (Level1 == true)
        {
            yield return new WaitForSeconds(5.0f);
            Cleared.gameObject.SetActive(false);

            //Time.timeScale = 1f;
        }


    }
}
