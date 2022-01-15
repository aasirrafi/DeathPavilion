using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    [SerializeField] GameObject PickupMessage;
    private float RayDistance;
    private bool CanSeePickup = false;
    private AudioSource MyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PickupMessage.gameObject.SetActive(false);
        RayDistance = Distance;
        MyPlayer = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit,RayDistance))
        {
            if (hit.transform.tag == "Apple")
            {
                CanSeePickup = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(SaveScript.Apples < 6 && SaveScript.BagCapacity > 0)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Apples += 1;
                        SaveScript.BagCapacity -= 1;
                        MyPlayer.Play();
                    }
                    
                }
            }
            else if (hit.transform.tag == "Bottle")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Bottle < 5 && SaveScript.BagCapacity > 0)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Bottle += 1;
                        SaveScript.BagCapacity -= 1;
                        MyPlayer.Play();
                    }

                }
            }

            else if (hit.transform.tag == "Watermelon")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Watermelon < 6 && SaveScript.BagCapacity > 0)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Watermelon += 1;
                        SaveScript.BagCapacity -= 1;
                        MyPlayer.Play();
                    }

                }
            }
            else if (hit.transform.tag == "Medikit")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Medikit < 2 && SaveScript.BagCapacity > 0)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Medikit += 1;
                        SaveScript.BagCapacity -= 1;
                        MyPlayer.Play();
                    }

                }
            }
            else if (hit.transform.tag == "Armour")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.BagCapacity > 0)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Armour += 1;
                        SaveScript.ArmourHealth += 100;
                        MyPlayer.Play();


                        SaveScript.HealthChanged = true;
                        MyPlayer.Play();

                        Inventory.HealthEqualsToHundred();
                    }

                }
            }

            else if (hit.transform.tag == "Battery")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(SaveScript.Batteries < 4 && SaveScript.BagCapacity>0)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Batteries += 1;
                        SaveScript.BagCapacity -= 1;
                        MyPlayer.Play();
                    }
                    
                }
            }
            else if (hit.transform.tag == "Knife")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Knife == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Knife = true ;
                        MyPlayer.Play();
                    }

                }


            }
            else if (hit.transform.tag == "Axe")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Axe == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Axe = true;
                        MyPlayer.Play();
                    }

                }

            }
            else if (hit.transform.tag == "Bat")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Bat == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Bat = true;
                        MyPlayer.Play();
                    }

                }

            }
            else if (hit.transform.tag == "Gun")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Gun == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Gun = true;
                        MyPlayer.Play();
                    }

                }

            }
            else if (hit.transform.tag == "Crossbow")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Crossbow == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Crossbow = true;
                        MyPlayer.Play();
                    }

                }

            }
            else if (hit.transform.tag == "RoomKey")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.RoomKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.RoomKey = true;
                        MyPlayer.Play();
                    }

                }

            }
            else if (hit.transform.tag == "HintOne")
            {
                CanSeePickup = true;
                HintOne();
            }
            else if (hit.transform.tag == "HintTwo")
            {
                CanSeePickup = true;
                HintTwo();
            }
            else if (hit.transform.tag == "HintThree")
            {
                CanSeePickup = true;
                HintThree();
            }
            else if (hit.transform.tag == "HintFour")
            {
                CanSeePickup = true;
                HintFour();
            }
            else if (hit.transform.tag == "HintFive")
            {
                CanSeePickup = true;
                HintFive();
            }
            else
            {
                CanSeePickup = false;
            }
        }
        if (CanSeePickup == true)
        {
            PickupMessage.gameObject.SetActive(true);
            RayDistance = 1000f;
        }
        if (CanSeePickup == false)
        {
            PickupMessage.gameObject.SetActive(false);
            RayDistance = Distance;
        }
    }

    void HintOne()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (SaveScript.NoteOne == false)
            {
                Destroy(hit.transform.gameObject);
                SaveScript.NoteOne = true;
                MyPlayer.Play();
            }

        }
    }

    void HintTwo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (SaveScript.NoteTwo == false)
            {
                Destroy(hit.transform.gameObject);
                SaveScript.NoteTwo = true;
                MyPlayer.Play();
            }

        }
    }
    void HintThree()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (SaveScript.NoteThree == false)
            {
                Destroy(hit.transform.gameObject);
                SaveScript.NoteThree = true;
                MyPlayer.Play();
            }

        }
    }
    void HintFour()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (SaveScript.NoteFour == false)
            {
                Destroy(hit.transform.gameObject);
                SaveScript.NoteFour = true;
                MyPlayer.Play();
            }

        }
    }
    void HintFive()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (SaveScript.NoteFive == false)
            {
                Destroy(hit.transform.gameObject);
                SaveScript.NoteFive = true;
                MyPlayer.Play();
            }

        }
    }
}
