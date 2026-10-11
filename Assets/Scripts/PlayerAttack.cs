using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [Header("References")]
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TempoHandler tempoHandler;
    [Header("Gun Settings")]
    [SerializeField] private int energyBallCutoff;
    [SerializeField] private int sniperShotCutoff;

    private void Start()
    {
        inputManager.OnFireButtonPressed += Attack;
    }

    public void Attack()
    {
        if(tempoHandler.GetCurrentBPM() <= energyBallCutoff)
        {
            Debug.Log("Fired Energy Ball");
        }
        else if (tempoHandler.GetCurrentBPM() > sniperShotCutoff)
        {
            Debug.Log("Fired Sniper Shot");
        }
    }
}
