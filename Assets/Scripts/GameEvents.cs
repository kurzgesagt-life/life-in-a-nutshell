using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    public static GameEvents current;
    // Start is called before the first frame update
    void Awake () {
        current = this;
    }

    public event Action onVillageCenter;
    public void VillageCenter () {
        Debug.Log ("Starting Event onVillageEnter");
        if (onVillageCenter != null) {
            onVillageCenter ();
        } else {
            Debug.Log ("onvillageCenter es null");
        }
    }

    public event Action onVillageCenterExit;
    public void VillageCenterExit () {
        if (onVillageCenterExit != null) {
            onVillageCenterExit ();
        }
    }

}