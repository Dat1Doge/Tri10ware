using UnityEngine;
using System.Collections;

public class Metrodome : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TempoHandler tempoHandler;

    [Header("Swap Settings")]
    [SerializeField] private int swapTempo;
    [SerializeField] private float swapCooldown;
    private bool canSwap = true;
    private string mode; //blaster, sniper

    [Header("Blaster Settings")]
    [SerializeField] private Sprite blasterSprite;

    [Header("Sniper Settings")]
    [SerializeField] private Sprite sniperSprite;

    private void Start()
    {
        UpdateMode();
        tempoHandler.OnTempoChange += UpdateMode;
        inputManager.OnFireButtonPressed += Attack;
    }

    private IEnumerator handleSwapCooldown(){
        canSwap = false;
        yield return new WaitForSeconds(swapCooldown);
        canSwap = true;
    }

    public void UpdateMode() {
        if(canSwap){
            int currBPM = tempoHandler.GetCurrentBPM();
            if(currBPM <= swapTempo && mode != "blaster"){
                mode = "blaster";
            }
            else if(currBPM > swapTempo && mode != "sniper"){
                mode = "sniper";
            }
            StartCoroutine("handleSwapCooldown");
        }
    }

    public void Attack()
    {
        if(tempoHandler.GetCurrentBPM() <= swapTempo)
        {
            Debug.Log("Fired Energy Ball");
        }
        else if (tempoHandler.GetCurrentBPM() > swapTempo)
        {
            Debug.Log("Fired Sniper Shot");
        }
    }
}
