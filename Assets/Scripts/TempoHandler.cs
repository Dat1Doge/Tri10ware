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

    public Action OnTempoChange;
    
    private int currBPM = 0;

    public int GetCurrentBPM()
    {
        return currBPM;
    }

    public float GetBPMmulti()
    {
        return (float)currBPM/baseBPM;
    }

    public void SetBPM(int bpm)
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
}