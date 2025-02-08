using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private PlayerInput inputActions;
    private int PunchComboCounter = 0;
    private float PunchComboResetTime = 1.0f; // Combo resets after 1 second of no input
    private float PunchLastAttackTime = 0;

    private int KickComboCounter = 0;
    private float KickComboResetTime = 1.0f; // Combo resets after 1 second of no input
    private float KickLastAttackTime = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        inputActions=GetComponent<PlayerInput>();
    }

    void Update()
    {
        bool playerPunch = inputActions.actions["PunchAttack"].WasPressedThisFrame();
        bool playerKick = inputActions.actions["KickAttack"].WasPressedThisFrame();
        // Reset combo if too much time has passed since the last attack
        if (Time.time - PunchLastAttackTime > PunchComboResetTime)
        {
            PunchComboCounter = 0;
        }
        if (Time.time - KickLastAttackTime > KickComboResetTime)
        {
            KickComboCounter = 0;
        }

        if (playerPunch) // Example: Left Click for Attack
        {
            PunchAttack();
        }
        if(playerKick)
        {
            KickAttack();
        }
    }

    void PunchAttack()
    {
        PunchLastAttackTime = Time.time; // Reset the timer

        if (PunchComboCounter == 0)
            animator.SetTrigger("Punch1");
        else if (PunchComboCounter == 1)
            animator.SetTrigger("Punch2");
        else if (PunchComboCounter == 2)
            animator.SetTrigger("PunchFinisher");

        PunchComboCounter++;

        // Reset to 0 after the final attack (so it loops)
        if (PunchComboCounter > 2)
            PunchComboCounter = 0;
    }

    void KickAttack()
    {
         KickLastAttackTime = Time.time; // Reset the timer

        if (KickComboCounter == 0)
            animator.SetTrigger("Kick1");
        else if (KickComboCounter == 1)
            animator.SetTrigger("Kick2");
        else if (KickComboCounter == 2)
            animator.SetTrigger("KickFinisher");

        KickComboCounter++;

        // Reset to 0 after the final attack (so it loops)
        if (KickComboCounter > 2)
            KickComboCounter = 0;
    }
}
