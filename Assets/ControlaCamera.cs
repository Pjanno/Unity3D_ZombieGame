using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour {

    //Variavel pra receber o Objeto jogador
    public GameObject Jogador;

    Vector3 distanciaCamera;

	// Use this for initialization
	void Start () {
        distanciaCamera = transform.position - Jogador.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Jogador.transform.position + distanciaCamera;
	}
}
