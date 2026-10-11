using UnityEngine;
using UnityEngine.UI;

public class TempoSliderUI : MonoBehaviour
{
    [SerializeField] private TempoHandler tempoHandler;
    [SerializeField] private Slider slider;

    private void Start()
    {
        tempoHandler.OnTempoChange += ChangeTempoSliderUI;
    }

    public void ChangeTempoSliderUI()
    {
        if (slider != null)
        {
            slider.value = tempoHandler.GetCurrentBPM();
        }
    }
}
