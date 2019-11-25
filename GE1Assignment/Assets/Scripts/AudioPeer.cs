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
    float[] bufferDecrease = new float[8];
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
    }

    void GetSpectrumAudioSource()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
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
        /*
         * 22050/512 = 43 hz per sample
         *  /*
         * 20-60 - Subbase
         * 60-250 - Bass
         * 250-500 - Low midrange
         * 500 - 2Khz - Midrange
         * 2Khz - 4Khz - Upper midrange
         * 4Khz - 6Khz - Presence
         * 6Khz - 20Khz - Brilliance
         *
         *0-2 = 86hz
         *1-4 = 172hz - 87 - 258
         *2-8 
         *3-16
         *4-32
         *5-64
         *6-128
         *7-256
         * = 510
         */
        /*for (int i = 0; i < bands.Length; i++)
        {
            int start = (int)Mathf.Pow(2, i) - 1;
            int width = (int)Mathf.Pow(2, i);
            int end = start + width;
            float average = 0;
            for (int j = start; j < end; j++)
            {
                average += spectrum[j] * (j + 1);
            }
            average /= (float)width;
            bands[i] = average;
            //Debug.Log(i + "\t" + start + "\t" + end + "\t" + start * binWidth + "\t" + (end * binWidth));
        }*/

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
