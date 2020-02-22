using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour
{
    public float testSound, Volume;
    public static float MicLoudness;
    [SerializeField]
    private string _device;
    private AudioClip _clipRecord ;
    private int _sampleWindow = 128;
    private bool _isInitialized;
    public AudioSource AS;
    private void Start()
    {
        InitMic();
    }

    void InitMic()
    {
        if (_device == "")
        {
            Debug.Log(Microphone.devices.Length);
            _device = Microphone.devices[0].ToString();
            _clipRecord = Microphone.Start(_device, true, 1,AudioSettings.outputSampleRate);
            AS.clip = _clipRecord;
            Debug.Log(_clipRecord);
        }
        AS.Play();
    }


    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1);
        if (micPosition < 0)
        {
            return 0;
        }
        _clipRecord.GetData(waveData, micPosition);
        for (int i = 0; i < _sampleWindow; ++i)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float[] data = new float[735];
        AS.GetOutputData(data, 0);
        //take the median of the recorded samples
        ArrayList s = new ArrayList();
        foreach (float f in data)
        {
            s.Add(Mathf.Abs(f));
        }
        s.Sort();
        Volume = (float)s[735 / 2];

        return levelMax;
    }

    void Update()
    {
        MicLoudness = LevelMax();
        testSound = MicLoudness;

    }

  
}
