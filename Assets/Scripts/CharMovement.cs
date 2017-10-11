using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour {
    [SerializeField]
    private PlayerState state;
    [SerializeField]
    private Animator anim;
  
    [SerializeField]
    private Moving move;

    [SerializeField]
    private Attack attack;

    private float unlockTimeAttack = -1;
    private float unlockTimeMove = -1;
    private float unlockTimeReciveDamage = -1;
    
    void Start(){
        move.SetAnimator(anim);
        attack.SetAnimator(anim);
    }

    void Update()
    {
        TimerStep();
        if (unlockTimeMove<0) { 
            anim.SetInteger("State", 0);

            if (Input.GetButton("Horizontal")|| Input.GetButton("Vertical"))
            {
                attack.DropCountAttack();
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");
                move.Move(x,z);
            }
        }
        if (unlockTimeAttack<0) {
           if (Input.GetKeyDown(KeyCode.Z))
           {
                attack.DoAttack();
           }
        }
	}
   
    void TimerStep()
    {
        if (unlockTimeAttack >= 0) {
            unlockTimeAttack -= Time.deltaTime;
        }
        if (unlockTimeMove >= 0)
        {
            unlockTimeMove -= Time.deltaTime;
        }
        if (unlockTimeReciveDamage >= 0)
        {
            unlockTimeReciveDamage -= Time.deltaTime;
        }
    }

    public void SetLockTime(float lockAttack = 0, float lockMove = 0, float lockReciveDamage = 0) {
        if (lockAttack > 0 && unlockTimeAttack<lockAttack) {
            unlockTimeAttack = lockAttack;
        }
        if (lockMove > 0 && unlockTimeMove < lockMove)
        {
            unlockTimeMove = lockMove;
        }
        if (lockReciveDamage > 0 && unlockTimeReciveDamage < lockReciveDamage)
        {
            unlockTimeReciveDamage = lockReciveDamage;
        }
    } 

}
