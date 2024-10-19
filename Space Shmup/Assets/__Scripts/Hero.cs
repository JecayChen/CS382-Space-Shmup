using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour{
    static public Hero S{
        // singleton property
        get;
        private set;
    }

    [Header("Inscribed")]

    // fields for movement
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Header("Dynamic")] [Range(0,4)]
    public float shieldLevel = 1;

    void Awake(){
        if(S == null){
            S = this; // set singleton if its null
        }else{
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S");
        }
    }

    void Update(){
        // pull in information form input class
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        // change position based on axis
        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;

        // roatate ship to feel dynamic
        transform.rotation = Quaternion.Euler(vAxis * pitchMult, hAxis * rollMult, 0);
    }
}
