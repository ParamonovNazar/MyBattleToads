using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Enemy") {
            Debug.Log("ENEMY!!!");
        }
    }
}
