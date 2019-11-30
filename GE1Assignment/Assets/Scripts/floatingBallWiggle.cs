using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingBallWiggle : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
    public int band;
    public float scaleMulti;
    float z;
    int beatCounter;
    bool stopped = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Wiggle();
    }

    void Wiggle()
    {
        
        float z = (AudioPeer.audioBandBuffer[band] * scaleMulti);
        float zNeg = z * -1;
        if(AudioPeer.audioBandBuffer[band] > .5 && stopped == true)
        {
            beatCounter++;
            stopped = false;
        }
        if(AudioPeer.audioBandBuffer[band] < .5)
        {
            stopped = true;
        }
        if(beatCounter%2 == 1)
        {
            Vector3 pos = new Vector3(xOffset, yOffset, zNeg);
            transform.position = pos + Camera.main.transform.position;
        }
        else
        {
            Vector3 pos = new Vector3(xOffset, yOffset, z);
            transform.position = pos + Camera.main.transform.position;
        }
        

    }
}