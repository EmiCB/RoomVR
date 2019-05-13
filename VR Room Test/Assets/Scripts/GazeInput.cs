using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInput : MonoBehaviour {
    private GameObject sun;
    private GameObject lamp;
    private GameObject sky;
    private GameObject shade;

    public Material bright;
    public Material dark;
    public Material shadeUnlit;
    public Material shadeLit;

    private float timer;
    private float gazeTime = 2.0f;

    private bool isGazedAt;

    // --- Initialization ---
    void Start() {
        sun = GameObject.Find("Sun");
        lamp = GameObject.Find("LampLight");
        sky = GameObject.Find("Sky");
        shade = GameObject.Find("Shade");

        timer = 0.0f;       //resets the timer
    }

    //--- Main Loop ---
    void Update() {
        if (isGazedAt) {
            //activates while the player is selecting an object with the reticle pointer
            timer += Time.deltaTime;   //starts timer
            if (timer >= gazeTime) {
                //activates after the object is gazed at for 2 seconds
                PointerGaze();
                timer = 0.0f;  //resets the timer
            }
        }
    }

    //--- Functions ---
    //- For Event Trigger -
    public void PointerEnter() {
        //activates when the reticle pointer is over an object
        isGazedAt = true;  //player is gazing at an object
    }
    public void PointerExit() {
        //activates when the reticle pointer is not over an object
        isGazedAt = false;  //player is not gazing at anything
        timer = 0.0f;       //resets timer
    }
    public void PointerGaze() {
        //lamp
        if(gameObject.name == "Shade") {
            if (lamp.activeSelf) {
                lamp.SetActive(false);
                shade.GetComponent<MeshRenderer>().material = shadeUnlit;
            }
            else {
                lamp.SetActive(true);
                shade.GetComponent<MeshRenderer>().material = shadeLit;
            }
        }
        else if(gameObject.name == "Sky") {
            if (sun.activeSelf) {
                sun.SetActive(false);
                sky.GetComponent<MeshRenderer>().material = dark;
            }
            else {
                sun.SetActive(true);
                sky.GetComponent<MeshRenderer>().material = bright;
            }
        }
    }
}
