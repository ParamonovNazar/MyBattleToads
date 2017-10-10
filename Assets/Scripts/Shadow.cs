using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    [SerializeField]
    BoxCollider col;
    [SerializeField]
    private LayerMask WhatIsGround;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private SpriteRenderer sprite;
    float height;
    
    void Start()
    {
        height =col.size.y / 2 - col.center.y;
    }
    void Update () {
        CreateShadow();
    }

    void CreateShadow() {
         
        RaycastHit hit;
        if (Physics.Raycast(target.position,Vector3.down, out hit,WhatIsGround))
        {
            if (hit.distance - height > 0.01)
            {
                sprite.enabled = true;
                transform.position = hit.point+new Vector3(0,0.001f,0);
            }
            else {
                sprite.enabled = false;
            }
        }
    }
}
