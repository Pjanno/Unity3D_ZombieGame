using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour {

    public LayerMask chao;
    public GameObject CanoArma;
    public GameObject Projetil;
    public GameObject TextoGamOv;
    public bool vivo;
    public float Velocidade = 10;
    Vector3 direcao;


    // Use this for initialization
    void Start () {
        GetComponent<ControlaJogador>().TextoGamOv.SetActive(false);
        Time.timeScale = 1;
        vivo = true;
	}
	
	// Update is called once per frame
	void Update () {

        //Movimenta o personagem usando Translate x Axis padrões do Unity
        direcao = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Condição pra saber se ele está correndo ou não
        if (direcao == Vector3.zero) {
            GetComponent<Animator>().SetBool("Movendo", false);
        } else {
            GetComponent<Animator>().SetBool("Movendo", true);
        }

        // Verifica se está atirando ou não.
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Projetil, CanoArma.transform.position, CanoArma.transform.rotation);
        }

        // Se estiver morto ele reinicia ao tentar atirar
        if (GetComponent<ControlaJogador>().vivo == false)
        {
            if (Input.GetButton("Fire1"))
            {
                SceneManager.LoadScene("Principal");
            }
        }

    }

    //Calculos de fisica
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao * Velocidade * Time.fixedDeltaTime);

        // Raio para a mira, desenhado da câmera principal até o ponteiro do mouse na tela
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.cyan);

        // rayHit pra receber o valor de onde está sendo tocado o raio
        RaycastHit rayHit;
        if (Physics.Raycast(raio, out rayHit, 100, chao))
        {
            Vector3 miraJogador = rayHit.point - transform.position; // Pra ser baseado na posição do jogador usamos o transform.position
            miraJogador.y = transform.position.y; // Congelamos o eixo y igualando a posição do jogador com a da mira, pra ele não olhar pra cima nem pra baixo

            Quaternion rotacaoJogador = Quaternion.LookRotation(miraJogador);
            GetComponent<Rigidbody>().MoveRotation(rotacaoJogador);
        }
    }
}
