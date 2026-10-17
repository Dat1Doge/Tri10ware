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
    [SerializeField] private WeaponMode blasterMode;
    [SerializeField] private WeaponMode sniperMode;
    private WeaponMode currMode; //blaster, sniper

    private bool canShoot = true;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        tempoHandler.OnTempoChange += UpdateMode;
        inputManager.OnFireButtonPressed += Attack;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateMode();
    }

    private IEnumerator HandleSwapCooldown(){
        canSwap = false;
        yield return new WaitForSeconds(swapCooldown);
        canSwap = true;
    }

    public void UpdateMode() {
        if(canSwap){
            int currBPM = tempoHandler.GetCurrentBPM();

            if(currBPM <= swapTempo && currMode != blasterMode){
                currMode = blasterMode;   
            }
            else if(currBPM > swapTempo && currMode != sniperMode){
                currMode = sniperMode;
            }
            else{
                return;
            }

            spriteRenderer.sprite = currMode.sprite;
            StartCoroutine(HandleSwapCooldown());
        }
    }

    private IEnumerator HandleAttackCooldown(){
        canShoot = false;
        yield return new WaitForSeconds(currMode.coolDown);
        canShoot = true;
    }

    public void Attack()
    {
        if(canShoot){
            GameObject newProjectile = Instantiate(currMode.projectile,transform.position,transform.rotation);
            newProjectile.GetComponent<Projectile>().Fire(newProjectile.transform.right,"Player");
            StartCoroutine(HandleAttackCooldown());
        }
    }
}
