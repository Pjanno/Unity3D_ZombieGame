using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * 20 * Time.fixedDeltaTime);
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Inimigo")
        {
            Destroy(c.gameObject);
        }
        Destroy(gameObject);
    }
}
