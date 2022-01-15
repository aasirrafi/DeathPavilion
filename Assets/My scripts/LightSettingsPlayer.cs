using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsPlayer : MonoBehaviour
{

    [SerializeField] PostProcessVolume MyVolume;
    [SerializeField] PostProcessProfile Map1;
    [SerializeField] PostProcessProfile NightVision;
    [SerializeField] GameObject NightVisionOverlay;
    [SerializeField] GameObject FlashLight;

    private bool NightVisionActive = false;
    private bool FlashLightActive = false;

    void Start()
    {
        NightVisionOverlay.gameObject.SetActive(false);
        FlashLight.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (SaveScript.BatteryPower > 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (NightVisionActive == false)
                {

                    MyVolume.profile = NightVision;
                    NightVisionActive = true;
                    NightVisionOverlay.gameObject.SetActive(true);
                    SaveScript.NVLightOn = true;
                }

                else
                {
                    MyVolume.profile = Map1;
                    NightVisionActive = false;
                    NightVisionOverlay.gameObject.SetActive(false);
                    SaveScript.NVLightOn = false;
                }

            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (FlashLightActive == false)
                {
                    FlashLightActive = true;
                    FlashLight.gameObject.SetActive(true);
                    SaveScript.FlashLightOn = true;
                }
                else
                {
                    FlashLightActive = false;
                    FlashLight.gameObject.SetActive(false);
                    SaveScript.FlashLightOn = false;
                }
            }

        }
        if(SaveScript.BatteryPower <= 0.0f)
        {
            MyVolume.profile = Map1;
            NightVisionActive = false;
            NightVisionOverlay.gameObject.SetActive(false);
            SaveScript.NVLightOn = false;
            FlashLightActive = false;
            FlashLight.gameObject.SetActive(false);
            SaveScript.FlashLightOn = false;
        }
        else
        {

        }
    }

}