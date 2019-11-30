using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitOrbs : MonoBehaviour
{
    public float yOrbit;
    public float zOrbit;
    public float xOffset;
    public int band;
    public float rotationSpeed;
    public bool rotateClockwise;
    public float scaleMulti;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed += AudioPeer.audioBandBuffer[band] * rotationSpeed;
        Rotate();

    }

    void Rotate()
    {
        if(rotateClockwise)
        {
            float y = (-Mathf.Cos(speed) * yOrbit) + (AudioPeer.audioBandBuffer[band] * scaleMulti);
            float z = Mathf.Sin(speed) * zOrbit; // + (AudioPeer.audioBandBuffer[band] * scaleMulti);
            Vector3 pos = new Vector3(xOffset, y, z);
            transform.position = pos + Camera.main.transform.position;
        }
        else
        {
            float y = Mathf.Cos(speed) * yOrbit + (AudioPeer.audioBandBuffer[band] * scaleMulti);
            float z = Mathf.Sin(speed) * zOrbit; // + (AudioPeer.audioBandBuffer[band] * scaleMulti);
            Vector3 pos = new Vector3(xOffset, y, z);
            transform.position = pos + Camera.main.transform.position;
        }
    }
}
