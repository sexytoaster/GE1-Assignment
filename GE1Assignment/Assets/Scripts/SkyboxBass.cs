using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxBass : MonoBehaviour
{
    public int band;
    public float duration;
    //gonna take rgb values from a sample materiaal and use them to effect the time of the skybox. I want top keep the skybox white because it'll be easier to test stuff
    public Material sampleMaterial;
    float r, g, b;
    //offset is to help reduce the brightness of the tint so its not so hard to look at
    public float offset = .5f;
    // Start is called before the first frame update
    void Start()
    {
        Color colourOriginal = sampleMaterial.GetColor("_EmissionColor");
        r = (1 - colourOriginal.r);
        g = (1 - colourOriginal.g);
        b = (1 - colourOriginal.b);
    }

    // Update is called once per frame
    void Update()
    {
        Color color = new Color(AudioPeer.audioBandBuffer[band] - (r + offset), AudioPeer.audioBandBuffer[band] - (g + offset), AudioPeer.audioBandBuffer[band] - (b + offset));
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(Color.black, color, lerp));

    }
}