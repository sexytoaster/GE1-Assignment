using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bassRingScript : MonoBehaviour
{
    public int band;
    public float startingScale, scaleMult;
    public bool useBuffer;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBandBuffer[band] * scaleMult) + startingScale, (AudioPeer.audioBandBuffer[band] * scaleMult) + startingScale);
            Color color = new Color(AudioPeer.audioBandBuffer[band] , AudioPeer.audioBandBuffer[band] + .5f, AudioPeer.audioBandBuffer[band] + .5f);
            material.SetColor("_EmissionColor", color);
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.bands[band] * scaleMult) + startingScale , (AudioPeer.bands[band] * scaleMult) + startingScale);
            Color color = new Color(AudioPeer.audioBand[band], AudioPeer.audioBand[band], AudioPeer.audioBand[band]);
            material.SetColor("_EmissionColor", color);
        }


    }
}
