using System;
using UnityEngine;

public class TempoHandler : MonoBehaviour
{
    [Header("BPM Settings")]
    [SerializeField]
    private int baseBPM = 60;
    [SerializeField]
    private int maxBPM;
    [SerializeField]
    private int minBPM;

    private int currBPM = 0;

    public Action OnTempoChange;

    public float getBPMmulti()
    {
        return (float)currBPM/baseBPM;
    }
    public void setBPM(int bpm)
    {
        if(bpm > maxBPM)
        {
            currBPM = maxBPM;
            OnTempoChange?.Invoke();

            return;
        }
        if(bpm < minBPM)
        {
            currBPM = minBPM;
            OnTempoChange?.Invoke();

            return;
        }       
        currBPM = bpm;
        OnTempoChange?.Invoke();
    }

    void Start()
    {
        currBPM = baseBPM;
    }
    public int GetCurrentBPM()
    {
        return currBPM;
    }
}