using UnityEngine;

public class TempoHandler : MonoBehaviour
{
    [SerializeField]
    private int baseBPM = 60;
    private int currBPM = 0;

    public float getBPMmulti()
    {
        return (float)currBPM/baseBPM;
    }

    public void setBPM(int bpm)
    {
        currBPM = bpm;
    }

    void Start()
    {
        currBPM = baseBPM;
    }
}