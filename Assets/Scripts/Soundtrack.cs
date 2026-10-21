using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    [SerializeField] private TempoHandler tempoHandler;
    [SerializeField] private AudioSource audSource;

    private void changeSpeed() {
        audSource.pitch = tempoHandler.GetBPMmulti();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoHandler.OnTempoChange += changeSpeed;
    }
}
