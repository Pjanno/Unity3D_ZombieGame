using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaZumbi : MonoBehaviour {

    public GameObject Jogador;
    public float Velocidade;

	// Use this for initialization
	void Start () {
        Jogador = GameObject.FindGameObjectWithTag("Player");
        int tipoZumbi = Random.Range(1, 28);
        transform.GetChild(tipoZumbi).gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void FixedUpdate()
    {
        // Calcula a Distância dos elementos (jogador x esse inimigo)
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        // Faz andar e rotacionar a direção do modelo 3D
        Vector3 direcao = Jogador.transform.position - transform.position;

        // O Quaternion tem métodos pra lidar com a rotação do objeto
        Quaternion olharPlayer = Quaternion.LookRotation(direcao);
        
        // Faz o zumbi andar só se a distância for alta
        if (distancia > 2.5f)
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * Velocidade * Time.fixedDeltaTime);
            GetComponent<Rigidbody>().MoveRotation(olharPlayer);
            GetComponent<Animator>().SetBool("atacando", false);
        } else
        {
            GetComponent<Animator>().SetBool("atacando", true);
        }
    }

    void AtacaJogador()
    {
        Jogador.GetComponent<ControlaJogador>().TextoGamOv.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().vivo = false;
        Time.timeScale = 0;
    }
}
