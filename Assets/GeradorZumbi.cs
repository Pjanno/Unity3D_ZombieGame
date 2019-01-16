using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbi : MonoBehaviour {

    float contaTempo = 0;
    public GameObject zumbi;
    public float TempoPraGerar = 2;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
	void Update () {
        contaTempo += Time.deltaTime;
        if (contaTempo >= TempoPraGerar)
        {
            Instantiate(zumbi, transform.position, transform.rotation);
            contaTempo = 0;
        }        
	}
}
