using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISimple : MonoBehaviour {

    [SerializeField]
    private Transform right;
    [SerializeField]
    private Transform left;
    [SerializeField]
    private float speed=5f;
    [SerializeField]
    private float attackRad=1f;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float distanceToL = Vector3.Distance(transform.position,left.position);
        float distanceToR = Vector3.Distance(transform.position,right.position);

        Vector3 target = distanceToL > distanceToR ? right.position : left.position;
        if (Vector3.Distance(transform.position,target) > attackRad) {
            Move(target);
        }
        

    }

    void Move(Vector3 target) {
        Vector3 targetNoY = target;
        targetNoY.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, targetNoY, speed * Time.deltaTime);
    }
}
