using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bassRingScript : MonoBehaviour
{
    public int band;
    public float startingScale, scaleMult;
    public bool useBuffer;
    Material material;
    //these are for getting the different between the colour original and 1 so we can keep our emission colours from just being white
    float r, g, b;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        Color colourOriginal = material.GetColor("_EmissionColor");
        r = (1 - colourOriginal.r);
        g = (1 - colourOriginal.g);
        b = (1 - colourOriginal.b);

    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBandBuffer[band] * scaleMult) + startingScale, (AudioPeer.audioBandBuffer[band] * scaleMult) + startingScale);
            
            Color color = new Color(AudioPeer.audioBandBuffer[band] - r, AudioPeer.audioBandBuffer[band] - g, AudioPeer.audioBandBuffer[band] - b);
            material.SetColor("_EmissionColor", color);
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.bands[band] * scaleMult) + startingScale , (AudioPeer.bands[band] * scaleMult) + startingScale);
            Color color = new Color(AudioPeer.audioBand[band] - r, AudioPeer.audioBand[band] - g, AudioPeer.audioBand[band] - b);
            material.SetColor("_EmissionColor", color);
        }


    }
}
