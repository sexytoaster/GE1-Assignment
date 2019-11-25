using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject sampleCube;
    GameObject[] sampleCubes = new GameObject[512];
    public float scale = 100;
    // Start is called before the first frame update
    void Start()
    {
        float theta = 360 / sampleCubes.Length;
        for (int i = 0; i <  sampleCubes.Length; i++)
        {
            GameObject cubeInstance = (GameObject)Instantiate(sampleCube);
            cubeInstance.transform.position = this.transform.position;
            cubeInstance.transform.parent = this.transform;
            cubeInstance.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -.703125f * i, 0);
            cubeInstance.transform.position = Vector3.forward * 100;
            sampleCubes[i] = cubeInstance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < sampleCubes.Length; i++)
        {
            if(sampleCubes!=null)
            {
                sampleCubes[i].transform.localScale = new Vector3(1, (AudioPeer.samples[i] * scale) + 2, 1);
            }
        }
    }
}
