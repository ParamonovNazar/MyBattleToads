using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private Animator anim;
    private Rigidbody rb;
    [SerializeField]
    private GameObject AttackTrigger;
    [SerializeField]
    private int[] hitSeq;
    [SerializeField]
    private int countHit = 0;

    private int curHit = 0;
   

    // Use this for initialization
    void Start () {
        AttackTrigger.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    public void DoAttack() {
      /*  anim.SetInteger("State", 4);
        anim.SetInteger("Attack", hitSeq[curHit]);
        anim.Play(GetAttackName(), -1, 0f);
        Vector3 AttackForce = transform.right;
        if (!fasingRight) {
            AttackForce = right * -1f;
        }
        AttackForce += new Vector3(0, ForceUpAttack, 0);

        rb.AddForce(AttackForce, ForceMode.Impulse);
        timeToUnlock = lockTime;
        timeToUnlockAttack = lockBetweenAttacks;
        AttackTrigger.SetActive(true);
        StartCoroutine(ChangeActive(false, AttackTrigger,0.1f));
        curHit++;
        if (curHit >= countHit) {
            curHit = 0;
        }*/
    }
    string GetAttackName()
    {
        int hit = hitSeq[curHit];
        if (FinalAttack())
        {
            return "StrongAttack2";
        }
        if (hit == 0)
        {
            return "LeftSimpleAttack";
        }
        if (hit == 1)
        {
            return "RightSimpleAttack";
        }
        /* if (hit == 2)
         {
             return "StrongAttack1";
         }
         if (hit == 3)
         {
             return "StrongAttack2";
         }*/
        return "LeftSimpleAttack";
    }

    bool FinalAttack()
    {
        return false;
    }
    IEnumerator ChangeActive(bool active, GameObject g, float t = 0.1f)
    {
        yield return new WaitForSeconds(t);
        g.SetActive(active);
    }
    public void DropCountAttack() {
        curHit = 0;
    }
    public void SetAnimator(Animator a)
    {
        anim = a;
    }
}
