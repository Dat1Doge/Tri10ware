using System.Runtime.CompilerServices;
using UnityEngine;

public class TempoInput : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TempoHandler tempoHandler;

    private readonly float tempoIncreasePoint = 1.0f;
    private readonly float tempoDecreasePoint = -1.0f;
    private int tempoChangeIncrement = 20;

    [SerializeField] private float tempoChangeCooldown;

    private void Update()
    {
        Vector2 tempoVector = inputManager.GetTempoVector();
       /* if(tempoVector.y >= tempoIncreasePoint)
        {
            //print("increase");
            int newTempo = tempoHandler.GetCurrentBPM() + tempoChangeIncrement;
            tempoHandler.SetBPM(newTempo);
        }
        if (tempoVector.y <= tempoDecreasePoint)
        {
            //print("decrease");
            int newTempo = tempoHandler.GetCurrentBPM() - tempoChangeIncrement;
            tempoHandler.SetBPM(newTempo);
        }
       */

        float newTempo = tempoHandler.GetCurrentBPM() + (tempoChangeIncrement * tempoVector.y);
        tempoHandler.SetBPM((int)newTempo);
    }
    
}
