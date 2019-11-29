using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]



public class AudioPeer : MonoBehaviour
{
    AudioSource audio;
    public int frameSize = 512;
    public static float[] samples;
    public static float[] spectrum;
    public static float[] bands = new float[8];
    public static float[] bandBuffer = new float[8];
    readonly float[] bufferDecrease = new float[8];
    readonly float[] bandHighest = new float[8];
    public static float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        spectrum = new float[frameSize];
        samples = new float[frameSize];
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeBands();
        BandBuffer();
        CreateAudioBands();
    }
    void CreateAudioBands()
    {
        //we use this to create values between 0 and 1 for use later
        //useful for when we are changing colours with our sound output or transforming by a multiplier
        for(int i = 0; i < 8; i++)
        {
            if(bands[i] > bandHighest[i])
            {
                bandHighest[i] = bands[i];
            }
            audioBand[i] = (bands[i] / bandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / bandHighest[i]);
        }

    }

    void GetSpectrumAudioSource()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        //this creates a buffer for our visualization that makes it so when sounds stop the shapes dont immediately return to their original size. 
        for(int i = 0; i < 8; ++i)
        {
            if(bands[i] > bandBuffer[i])
            {
                bandBuffer[i] = bands[i];
                bufferDecrease[i] = 0.005f;
            }
            if (bands[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }

    }
    void MakeBands()
    {
        //this splits our spectrum into 8 bands that we can work with
        int count = 0;

        for (int i = 0; i < bands.Length; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if(i == 7)
            {
                sampleCount += 2;
            }
            for(int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            bands[i] = average * 10;
        }

    }
}
