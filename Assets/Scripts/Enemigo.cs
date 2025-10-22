using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
	
	public static int vidaEnemigo = 1;
	private float frecAtaque = 2.5f, tiempoSigAtaque = 0, iniciaConteo;


	public Transform personaje;
	private NavMeshAgent agente;
	public Transform[] puntosRuta;
	private int indiceRuta = 0;
	private bool playerEnRango = false;
	[SerializeField] private float distanciaDetenccionPlayer;
	private	SpriteRenderer spriteEnemigo;
	private Transform mirarHacia;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
		spriteEnemigo = GetComponent<SpriteRenderer>();
    }




    void Start()
    {
	    vidaEnemigo = 1;
		agente.updateRotation = false;
		agente.updateUpAxis = false;
    }

    void Update()
    { 
		this .transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
		float distancia = Vector3.Distance(personaje.position, transform.position);
		if (this.transform.position == puntosRuta[indiceRuta].position)
		{
			if (indiceRuta < puntosRuta.Length - 1)
			{
				indiceRuta++;
			}
			else
			{
				indiceRuta = 0;

			}
		}
		if (distancia < distanciaDetenccionPlayer)
		{
			playerEnRango = true;
		}
		else
		{
			playerEnRango = false;
        }


			if (tiempoSigAtaque > 0)
		{
			tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
		}
		else
		{
			tiempoSigAtaque = 0;
			VidasPlayer.puedePerderVida = 1;
			SigueAlPayer(playerEnRango);
			RotarEnemigo();
		}
    }



	private void SigueAlPayer(bool seguirPlayer){
		if(seguirPlayer){
			agente.SetDestination(personaje.position);
			mirarHacia = personaje;
        }
        else{
			agente.SetDestination(puntosRuta[indiceRuta].position);
			mirarHacia = puntosRuta[indiceRuta];
        }
    }

	private void RotarEnemigo(){ 
		if(this.transform.position.x > mirarHacia.position.x)
		{
			spriteEnemigo.flipX = true;
			Debug.Log("fipX");
		}
		else
		{
			spriteEnemigo.flipX = false;
			Debug.Log("Sin fipX");
        }
	}


    private void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag == "Player"){
			tiempoSigAtaque = frecAtaque;
			iniciaConteo = Time.time;
			obj.transform.GetComponentInChildren<VidasPlayer>().TomarDaño(1);
		}
	}
	
	public void TomarDaño(int daño){
		vidaEnemigo -= daño;
		if(vidaEnemigo <= 0){
			Destroy(gameObject);
		}
	}
    
}
