using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSound : MonoBehaviour
{
    private GameObject[] BGSounds;

    private void Awake()
    { 
        BGSounds = GameObject.FindGameObjectsWithTag("BGSound");

        
        if (BGSounds.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }
}
