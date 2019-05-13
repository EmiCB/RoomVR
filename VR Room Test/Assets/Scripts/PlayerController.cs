using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public bool isJack;

    private float heightJack = 0.94f; //average height of  a 3 year old girl (Bronwyn is the same size as Jack)
    private float heightMa = 1.61798f; //average height for an adult woman

    // --- Initialization ---
    void Start() {
        //set inital player position
        setPlayerPosition();
    }

    // --- Main Loop ---
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            changePlayer();
            changePlayerHeight();
        }
    }

    //set player settings 
    public void setPlayerPosition() {
        transform.eulerAngles = new Vector3(0, 90, 0);
        if(isJack) transform.position = new Vector3(-1.0f, heightJack, -0.5f);
        else transform.position = new Vector3(-1.0f, heightMa, -0.5f);
    }
    //change player
    public void changePlayer() {
        if(isJack) isJack = false;
        else isJack = true;
    }
    //change player height
    public void changePlayerHeight() {
        if(isJack) transform.position = new Vector3(transform.position.x, heightJack, transform.position.z);
        else transform.position = new Vector3(transform.position.x, heightMa, transform.position.z);
    }
}
