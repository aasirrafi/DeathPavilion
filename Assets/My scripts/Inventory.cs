using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    private bool InventoryActive = false;
    private AudioSource MyPlayer;
    [SerializeField] AudioClip AppleBite;
    [SerializeField] AudioClip BatteryChange;
    [SerializeField] AudioClip WeaponChange;
    [SerializeField] GameObject PlayerArms;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject Bat;
    [SerializeField] GameObject Axe;
    public Text bagCapacity;
    public Text waterMelonCount;
    public Text bottleCount;
    public Text medikitCount;




    //Apples
    public Text appleCount;
    [SerializeField] GameObject AppleImage1;
    [SerializeField] GameObject AppleButton1;


    //Batteries
    public Text batteryCount;
    [SerializeField] GameObject BatteryImage1;
    [SerializeField] GameObject BatteryButton1;


    //Weapons
    [SerializeField] GameObject KnifeImage;
    [SerializeField] GameObject KnifeButton;
    [SerializeField] GameObject BatImage;
    [SerializeField] GameObject BatButton;
    [SerializeField] GameObject AxeImage;
    [SerializeField] GameObject AxeButton;
    [SerializeField] GameObject GunImage;
    [SerializeField] GameObject GunButton;
    [SerializeField] GameObject CrossbowImage;
    [SerializeField] GameObject CrossbowButton;

    //key
    [SerializeField] GameObject RoomKeyImage;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
        InventoryActive = false;
        Cursor.visible = false;
        MyPlayer = GetComponent<AudioSource>();
        //Apples



        AppleImage1.gameObject.SetActive(true);
        AppleButton1.gameObject.SetActive(true);


        //Batteries 
        BatteryImage1.gameObject.SetActive(true);
        BatteryButton1.gameObject.SetActive(true);


        //Weapons
        KnifeImage.gameObject.SetActive(false);
        KnifeButton.gameObject.SetActive(false);
        BatImage.gameObject.SetActive(false);
        BatButton.gameObject.SetActive(false);
        AxeImage.gameObject.SetActive(false);
        AxeButton.gameObject.SetActive(false);
        GunImage.gameObject.SetActive(false);
        GunButton.gameObject.SetActive(false);
        CrossbowImage.gameObject.SetActive(false);
        CrossbowButton.gameObject.SetActive(false);

        //key 
        RoomKeyImage.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryActive == false)
            {
                InventoryMenu.gameObject.SetActive(true);
                InventoryActive = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
                //SaveScript.HaveKnife = false;
                //SaveScript.HaveBat = false;
                //SaveScript.HaveAxe = false;
             
                Player.GetComponent<PlayerAttacks>().enabled = false;
            }
            else if(InventoryActive == true)
            {
                InventoryMenu.gameObject.SetActive(false);
                InventoryActive = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
                Player.GetComponent<PlayerAttacks>().enabled = true;
            }
        }
        CheckInventory();
        CheckWeapons();
        CheckKey();



    }
    void CheckInventory()
    { 
        appleCount.text = SaveScript.Apples.ToString();
        batteryCount.text = SaveScript.Batteries.ToString();
        bagCapacity.text = SaveScript.BagCapacity.ToString();
        waterMelonCount.text = SaveScript.Watermelon.ToString();
        bottleCount.text = SaveScript.Bottle.ToString();
        medikitCount.text = SaveScript.Medikit.ToString();
    }
    void CheckWeapons()
    {
        
        if(SaveScript.Knife == true)
        {
            KnifeImage.gameObject.SetActive(true);
            KnifeButton.gameObject.SetActive(true);
        }
        if (SaveScript.Axe == true)
        {
            AxeImage.gameObject.SetActive(true);
            AxeButton.gameObject.SetActive(true);
        }
        if (SaveScript.Bat == true)
        {
            BatImage.gameObject.SetActive(true);
            BatButton.gameObject.SetActive(true);
        }
        if (SaveScript.Gun == true)
        {
            GunImage.gameObject.SetActive(true);
            GunButton.gameObject.SetActive(true);
        }
        if (SaveScript.Crossbow == true)
        {
            CrossbowImage.gameObject.SetActive(true);
            CrossbowButton.gameObject.SetActive(true);
        }

    }
    void CheckKey()
    {
        if (SaveScript.RoomKey == true)
        {
            RoomKeyImage.gameObject.SetActive(true);
        }

    }
    public void AppleHealthUpdate()
    {
        if(SaveScript.PlayerHealth < 100 && SaveScript.Apples > 0)
        {
                SaveScript.PlayerHealth += 5;
                SaveScript.HealthChanged = true;
                SaveScript.Apples -= 1;
                SaveScript.BagCapacity += 1;
                MyPlayer.clip = AppleBite;
                MyPlayer.Play();
        }
        HealthEqualsToHundred();
    }
    public void BottleHealthUpdate()
    {
        if (SaveScript.PlayerHealth < 100 && SaveScript.Bottle > 0)
        {
            SaveScript.PlayerHealth += 15;
            SaveScript.HealthChanged = true;
            SaveScript.Bottle -= 1;
            SaveScript.BagCapacity += 1;
            MyPlayer.clip = AppleBite;
            MyPlayer.Play();
        }
        HealthEqualsToHundred();
    }
    public void WaterMelonHealthUpdate()
    {
        if (SaveScript.PlayerHealth < 100 && SaveScript.Watermelon > 0)
        {
            SaveScript.PlayerHealth += 20;
            SaveScript.HealthChanged = true;
            SaveScript.Watermelon -= 1;
            SaveScript.BagCapacity += 1;
            MyPlayer.clip = AppleBite;
            MyPlayer.Play();
        }
        HealthEqualsToHundred();

    }
    public void MedikitHealthUpdate()
    {
        if (SaveScript.PlayerHealth < 100 && SaveScript.Medikit > 0)
        {
            SaveScript.PlayerHealth += 100;
            SaveScript.HealthChanged = true;
            SaveScript.Medikit -= 1;
            SaveScript.BagCapacity += 1;
            MyPlayer.clip = AppleBite;
            MyPlayer.Play();
        }
        HealthEqualsToHundred();
    }
    public void BatteryUpdate()
    {
        if(SaveScript.Batteries > 0 && SaveScript.BatteryPower == 0f)
        {
            SaveScript.BatteryRefill = true;
            SaveScript.Batteries -= 1;
            MyPlayer.clip = BatteryChange;
            MyPlayer.Play();
        }
        
    }
    public void AssignKnife()
    {
        Knife.gameObject.SetActive(true);
        Bat.gameObject.SetActive(false);
        Axe.gameObject.SetActive(false);
        MyPlayer.clip = WeaponChange;
        MyPlayer.Play();
        SaveScript.HaveKnife = true;
        SaveScript.HaveBat = false;
        SaveScript.HaveAxe = false;


    }
    public void AssignBat()
    {
        Bat.gameObject.SetActive(true);
        Axe.gameObject.SetActive(false);
        Knife.gameObject.SetActive(false);
        MyPlayer.clip = WeaponChange;
        MyPlayer.Play();
        SaveScript.HaveKnife = false;
        SaveScript.HaveBat = true;
        SaveScript.HaveAxe = false;


    }
    public void AssignAxe()
    {
        Axe.gameObject.SetActive(true);
        Bat.gameObject.SetActive(false);
        Knife.gameObject.SetActive(false);
        MyPlayer.clip = WeaponChange;
        MyPlayer.Play();
        SaveScript.HaveKnife = false;
        SaveScript.HaveBat = false;
        SaveScript.HaveAxe = true;


    }



    public static void HealthEqualsToHundred()
    {
        if (SaveScript.PlayerHealth > 100)
        {
            SaveScript.PlayerHealth = 100;
        }

        if (SaveScript.ArmourHealth > 100)
        {
            SaveScript.ArmourHealth = 100;
        }

        if (SaveScript.PlayerHealth <= 0)
        {
            SaveScript.PlayerHealth = 0;
        }

        if (SaveScript.ArmourHealth <= 0)
        {
            SaveScript.ArmourHealth = 0;
        }
    }


    
}
