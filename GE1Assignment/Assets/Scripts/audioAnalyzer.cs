using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioAnalyzer : MonoBehaviour
{
    public int frameSize = 512;
    public static float[] samples;
    public static float[] spectrum;
    AudioSource audio;
    // Awake is called before everything
    void Awake()
    {
        //raw data we're reading in
        samples = new float[frameSize];
        //wave height
        spectrum = new float[frameSize];
        //audio
        audio = GetComponent<AudioSource>();
        //start playback
        audio.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        //getting samples from the audio
        audio.GetOutputData(samples, 0);
        //get spectrum data
        audio.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
    }
}
