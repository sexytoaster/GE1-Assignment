﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour
{
    public int band;
    public float startingScale, scaleMult;
    public bool useBuffer;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().materials[0];
         
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.bandBuffer[band] * scaleMult) + startingScale, transform.localScale.z);
            Color color = new Color(AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band]);
            material.SetColor("_EmissionColor", color);
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.bands[band] * scaleMult) + startingScale, transform.localScale.z);
            Color color = new Color(AudioPeer.audioBand[band], AudioPeer.audioBand[band], AudioPeer.audioBand[band]);
            material.SetColor("_EmissionColor", color);
        }


    }
}
