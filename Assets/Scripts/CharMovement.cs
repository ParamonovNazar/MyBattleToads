using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour {

    private bool fasingRight =true;
    [SerializeField]
    private Transform transformFlip;
    [SerializeField]
	private float moveSpeed=4f;
    [SerializeField]
    private Animator anim;

	Vector3 forward,right;
	// Use this for initialization
	void Start(){
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize (forward);
		right = Quaternion.Euler (new Vector3(0,90,0))*forward;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetInteger("State", 0);

        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)) {
			Move ();
		}

	}

	void Move(){
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis ("Horizontal");
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis ("Vertical");

		Vector3 heading = Vector3.Normalize (rightMovement+upMovement);
 
		transform.position += rightMovement;
		transform.position += upMovement;

        if (Input.GetAxis("Horizontal")==0)
        {
            anim.SetInteger("State", 2);
        }
        else {
            anim.SetInteger("State", 1);
            if (fasingRight ^ (Input.GetAxis("Horizontal") > 0))
            {
                Flip();
            }
        }
	}

    void Flip() {
        Vector3 flipScale = transformFlip.localScale;
        flipScale.x *= -1;
        transformFlip.localScale = flipScale;
        fasingRight = !fasingRight;
    }
}
