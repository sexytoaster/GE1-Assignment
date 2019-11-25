using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioVisualizer1 : MonoBehaviour
{
    public float scale = 10;
    List<GameObject> elements = new List<GameObject>();
    public Transform startMarker;
    // Use this for initialization
    void Start()
    {
        CreateVisualisers();

    }

    public float radius = 10;

    void CreateVisualisers()
    {
        float theta = (Mathf.PI * 2.0f) / (float)audioAnalyzer1.bands.Length;
        for (int i = 0; i < audioAnalyzer1.bands.Length; i++)
        {
            //for (int j = 0; j < audioAnalyzer1.bands.Length; j++)
           // {
                Vector3 p = new Vector3(Mathf.Cos(theta * i) * radius, Mathf.Sin(theta * i) * radius, i);
                p = transform.TransformPoint(p);
                Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.forward);
                //q = transform.rotation * q;

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                cube.transform.SetPositionAndRotation(p, q);
                cube.transform.parent = this.transform;
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                    i / (float)audioAnalyzer1.bands.Length, 1, 1);
                elements.Add(cube);
            startMarker = cube.transform;
           // }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            // Vector3 ls = elements[i].transform.localScale;
            //ls.x = Mathf.Lerp(ls.x, 1 + (audioAnalyzer1.bands[i] * scale), Time.deltaTime * 30.0f);
            //elements[i].transform.localScale = ls;
            Vector3 x = new Vector3(transform.position.x +( audioAnalyzer1.bands[i] * scale),0,0);
            elements[i].transform.position = Vector3.Lerp(startMarker.position, x, Time.deltaTime * 30f);
        }
    }
}