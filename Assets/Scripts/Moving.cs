using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {
    private bool fasingRight = true;
    [SerializeField]
    private Transform transformFlip;
    [SerializeField]
    private float moveSpeed = 4f;
    private Animator anim;
    private Rigidbody rb;
    [SerializeField]
    private float ForceUpAttack;
    [SerializeField]
    private float lockTime;
    [SerializeField]
    private float lockBetweenAttacks;
    Vector3 forward, right;

    void Start ()
    {
        rb=GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }
	
    public void Move(float x, float z)
    {
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * x;
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * z;

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.position += rightMovement;
        transform.position += upMovement;

        if (x == 0)
        {
            anim.SetInteger("State", 2);
        }
        else
        {
            anim.SetInteger("State", 1);
            if (fasingRight ^ (z > 0))
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 flipScale = transformFlip.localScale;
        flipScale.x *= -1;
        transformFlip.localScale = flipScale;
        fasingRight = !fasingRight;
    }

    public void SetAnimator(Animator a) {
        anim = a;
    }
}
