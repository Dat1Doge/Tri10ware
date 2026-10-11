using System.Runtime.CompilerServices;
using UnityEngine;

public class TempoInput : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TempoHandler tempoHandler;

    private readonly float tempoIncreasePoint = 1.0f;
    private readonly float tempoDecreasePoint = -1.0f;
    private int tempoChangeIncrement = 10;

    [SerializeField] private float tempoChangeCooldown;

    private void Update()
    {
        Vector2 tempoVector = inputManager.GetTempoVector();
        if(tempoVector.y >= tempoIncreasePoint)
        {
            int newTempo = tempoHandler.GetCurrentBPM() + tempoChangeIncrement;
            tempoHandler.setBPM(newTempo);
            //Debug.Log(tempoHandler.GetCurrentBPM());
        }
        if (tempoVector.y <= tempoDecreasePoint)
        {
            int newTempo = tempoHandler.GetCurrentBPM() - tempoChangeIncrement;
            tempoHandler.setBPM(newTempo);
            //Debug.Log(tempoHandler.GetCurrentBPM());
        }
    }
    
}
