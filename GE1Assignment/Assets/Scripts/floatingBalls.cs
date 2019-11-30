using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingBalls : MonoBehaviour
{
    public float xOffset;
    public float zOffset;
    public int band;
    public float scaleMulti;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        
            float y = (AudioPeer.audioBand[band] * scaleMulti);
            Vector3 pos = new Vector3(xOffset, y, zOffset);
            transform.position = pos + Camera.main.transform.position;
       
    }
}