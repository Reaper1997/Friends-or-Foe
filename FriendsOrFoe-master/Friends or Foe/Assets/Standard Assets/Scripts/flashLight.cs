using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class flashLight : MonoBehaviour
    {
        public Light flashLightSource;
        public bool lightOn = false;
        public AudioClip soundTurnOn;
        public AudioClip soundTuronOff;

         

        // Use this for initialization
        void Start()
        {
            flashLightSource = GetComponent<Light>();
            flashLightSource.enabled = false;
    }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                toggleFlashLight();
                toggleFlashLightSFX();

                if (lightOn)
                {
                    lightOn = false;
                }
                else if (!lightOn)
                {
                    lightOn = true;
                }
            }
        }

        void toggleFlashLight()
        {
            if (lightOn)
            {
                flashLightSource.enabled = false;
            }
            else
            {
                flashLightSource.enabled = true;
            }
        }

        void toggleFlashLightSFX()
        {
            AudioSource audio = GetComponent<AudioSource>();
            if (flashLightSource.enabled)
            {

                audio.clip = soundTurnOn;
            }
            else
            {
                audio.clip = soundTuronOff;
            }
            audio.Play();
        }
    }