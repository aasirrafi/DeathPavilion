using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReader : MonoBehaviour
{
    [SerializeField] GameObject Note1;
    [SerializeField] GameObject Note2;
    [SerializeField] GameObject Note3;
    [SerializeField] GameObject Note4;
    [SerializeField] GameObject Note5;
    [SerializeField] GameObject PlayerArms;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NoteReadOne();
        NoteReadTwo();
        NoteReadThree();
        NoteReadFour();
        NoteReadFive();
    }
  




    public void NoteReadOne()
    {
        if (SaveScript.NoteOne == true)
        {
            Note1.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            PlayerArms.gameObject.SetActive(false);

            //disable mouse function
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SaveScript.NoteOne = false;
                Note1.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;
                PlayerArms.gameObject.SetActive(true);

            }
        }
    }
    public void NoteReadTwo()
    {
        if (SaveScript.NoteTwo == true)
        {
            Note2.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            PlayerArms.gameObject.SetActive(false);

            //disable mouse function
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SaveScript.NoteTwo = false;
                Note2.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;
                PlayerArms.gameObject.SetActive(true);

            }
        }
    }
    public void NoteReadThree()
    {
        if (SaveScript.NoteThree == true)
        {
            Note3.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            PlayerArms.gameObject.SetActive(false);

            //disable mouse function
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SaveScript.NoteThree = false;
                Note3.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;
                PlayerArms.gameObject.SetActive(true);

            }
        }
    }
    public void NoteReadFour()
    {
        if (SaveScript.NoteFour == true)
        {
            Note4.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            PlayerArms.gameObject.SetActive(false);

            //disable mouse function
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SaveScript.NoteFour = false;
                Note4.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;
                PlayerArms.gameObject.SetActive(true);

            }
        }
    }
    public void NoteReadFive()
    {
        if (SaveScript.NoteFive == true)
        {
            Note5.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            PlayerArms.gameObject.SetActive(false);

            //disable mouse function
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SaveScript.NoteFive = false;
                Note5.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;
                PlayerArms.gameObject.SetActive(true);

            }
        }
    }

}
