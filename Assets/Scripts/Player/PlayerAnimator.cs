using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private InputManager inputManager;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        inputManager = GameObject.FindWithTag("InputManager").GetComponent<InputManager>();
    }
    private void Update()
    {
        if (inputManager.GetMovementVector() != Vector2.zero)
        {
            playerAnimator.SetBool("isRunning", true);

            playerAnimator.SetFloat("moveVectorX",inputManager.GetMovementVector().x);
            playerAnimator.SetFloat("moveVectorY", inputManager.GetMovementVector().y);
            
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
        
    }
}
