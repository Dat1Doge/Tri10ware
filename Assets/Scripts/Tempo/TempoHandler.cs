using System;
using UnityEngine;

public class TempoHandler : MonoBehaviour
{
    [Header("BPM Settings")]
    [SerializeField] private int baseBPM = 60;
    [SerializeField] private int maxBPM;
    [SerializeField] private int minBPM;

    public Action OnTempoChange;
    
    private int currBPM = 0;

    public int GetMaxBPM()
    {
        return maxBPM;
    }

    public int GetMinBPM()
    {
        return minBPM;
    }

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
        if(Time.timeScale!=0){
            currBPM = Mathf.Clamp(bpm,minBPM,maxBPM);
            Time.timeScale = GetBPMmulti();
            OnTempoChange?.Invoke();
        }
    }

    void Awake()
    {
        currBPM = baseBPM;
    }
}