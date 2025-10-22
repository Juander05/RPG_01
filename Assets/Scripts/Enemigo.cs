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
	[SerializeField] private float distanciaDeteccionPlayer;
	private SpriteRenderer spriteEnemigo;
	private Transform mirarHacia;
	
	private Animator animator;
	private Vector2 ultimaDireccion;
	
	private void Awake(){
		agente = GetComponent<NavMeshAgent>();
		spriteEnemigo = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}
	
    void Start(){
	    vidaEnemigo = 1;
	    agente.updateRotation = false;
	    agente.updateUpAxis = false;
    }

	void Update(){
    	
		this.transform.position = new Vector3(transform.position.x, transform.position.y,0);
		float distancia = Vector3.Distance(personaje.position, this.transform.position);
		
		//Animacion programada con los puntoRuta
		//this.transform.position == puntosRuta[indiceRuta].position
		if(Vector3.Distance(transform.position, puntosRuta[indiceRuta].position) < 0.2f){
			if(indiceRuta < puntosRuta.Length -1){
				indiceRuta++;
			}else if(indiceRuta == puntosRuta.Length -1){
				indiceRuta = 0;
			}
		}
		
		if(distancia < distanciaDeteccionPlayer){
			playerEnRango = true;
		} else {
			playerEnRango = false;
		}
    	
	    if(tiempoSigAtaque > 0){
	    	tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
	    } else{
	    	tiempoSigAtaque = 0;
	    	VidasPlayer.puedePerderVida = 1;
	    	SigueAlPlayer(playerEnRango);
	    	RotaEnemigo();
	    	ActualizaAnimacion();
	    }
	}
    
	private void SigueAlPlayer(bool playerEnRango){
		//Sigue al player
		if(playerEnRango){
			agente.SetDestination(personaje.position);
			mirarHacia = personaje;
		} else{
			//Regresa a su ruta
			agente.SetDestination(puntosRuta[indiceRuta].position);
			mirarHacia = puntosRuta[indiceRuta];
		}
	}
	
	private void RotaEnemigo(){
		if(this.transform.position.x > mirarHacia.position.x){
			spriteEnemigo.flipX = true;
			Debug.Log("FlipX");
		} else {
			spriteEnemigo.flipX = false;
			Debug.Log("Sin FlipX");
		}
	}
	
	private void ActualizaAnimacion()
	{
		// Calculamos la dirección de movimiento
		Vector3 velocidad = agente.velocity;

		float movX = velocidad.x;
		float movY = velocidad.y;

		// Pasamos los valores al Animator
		animator.SetFloat("movX", movX);
		animator.SetFloat("movY", movY);

		// Determinamos si está en movimiento
		//bool estaCaminando = velocidad.magnitude > 0.05f;
		//animator.SetBool("isWalking", estaCaminando);

		// Guardamos la última dirección (opcional, si luego quieres idle mirando hacia una dirección)
		//if (estaCaminando)
		//{
		//	ultimaDireccion = new Vector2(movX, movY);
		//}
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
