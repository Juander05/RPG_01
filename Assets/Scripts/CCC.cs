using UnityEngine;

public class CCC : MonoBehaviour
{

	public Transform controladorGolpe;
	public float radioGolpe;
	public int dañoGolpe;
	public float tiempoEntreAtaques;
	public float tiempoSigAtaque;
	private Animator anim;
	[SerializeField] private AudioClip golpeSonido;
	
	public static bool atacando;


    void Start(){
	    anim = GetComponent<Animator>();
    }

	void Update(){
		if(tiempoSigAtaque < 0.05f && tiempoEntreAtaques > 0){
			atacando = false;
		}
		
		if(tiempoSigAtaque > 0){
			tiempoSigAtaque -= Time.deltaTime;
		}
		
		if(Input.GetButtonDown("Fire1") && tiempoSigAtaque <= 0){
			atacando = true;
			activaCapa("Ataque");
			Golpe();
			tiempoSigAtaque = tiempoEntreAtaques;
		}
	}
    
	private void Golpe(){
		if(MovPlayer.dirAtaque == 1){
			anim.SetTrigger("ataqueFAbajo");
			ControladorSonidos.Instance.EjecutarSonido(golpeSonido);
		}
		
		if(MovPlayer.dirAtaque == 2){
			anim.SetTrigger("ataqueFArriba");
			ControladorSonidos.Instance.EjecutarSonido(golpeSonido);
		}
		
		if(MovPlayer.dirAtaque == 3){
			anim.SetTrigger("ataqueFIzquierda");
			ControladorSonidos.Instance.EjecutarSonido(golpeSonido);
		}
		
		if(MovPlayer.dirAtaque == 4){
			anim.SetTrigger("ataqueFDerecha");
			ControladorSonidos.Instance.EjecutarSonido(golpeSonido);
		}
	}
	
	private void VerificaGolpe(){
		Collider2D[] objs = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);	//Verifica que golpeo
		foreach(Collider2D colisionador in objs){
			if(colisionador.CompareTag("enemigo")){
				colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
			}
		}
	}
	
	private void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
	}
	
	private void activaCapa(string Nombre){
		for(int i = 0; i < anim.layerCount; i++){
			anim.SetLayerWeight(i, 0); //Ambos layers con weight en 0
		}
		anim.SetLayerWeight(anim.GetLayerIndex(Nombre),1);
	}
    
}
