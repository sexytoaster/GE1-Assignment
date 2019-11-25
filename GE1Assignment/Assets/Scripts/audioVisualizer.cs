using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioVisualizer : MonoBehaviour
{
    public float radius = 30;
    public float scale = 50;

    // Start is called before the first frame update
    void Start()
    {
        float theta = (Mathf.PI * 2.0f) / audioAnalyzer.spectrum.Length;
        //create a cube for each frame in the sample
        for(int i = 0; i < audioAnalyzer.spectrum.Length; i++)
        {
            //instanciate cube
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            float angle = theta * i;
            Vector3 p = new Vector3(Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle) * radius);
            cube.transform.position = transform.TransformPoint(p);
            cube.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.up);
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)audioAnalyzer.spectrum.Length, 1, 1);
            cube.transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < audioAnalyzer.spectrum.Length; i++)
        {
            transform.GetChild(i).localScale = new Vector3(1, (1 + audioAnalyzer.spectrum[i] * scale), 1);
        }
        
    }
}
