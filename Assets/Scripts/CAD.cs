using UnityEngine;

public class CAD : MonoBehaviour
{
	
	[SerializeField] private GameObject proyectil;
	public float tiempoSigAtaque;
	public float tiempoEntreAtaques;
	public Transform puntoEmision;
	private Animator anim;
	public static int dirDisparo = 0;
	public static bool disparando = false;
	private Inventario inventario;
	[SerializeField] private AudioClip disparoSonido;

    void Start(){
	    anim = GetComponent<Animator>();
	    inventario = FindObjectOfType<Inventario>();
    }

    void Update(){
	    if(tiempoSigAtaque < 0.05f && tiempoEntreAtaques > 0){
	    	disparando = false;
	    }
	    
	    if(tiempoSigAtaque > 0){
	    	tiempoSigAtaque -= Time.deltaTime;
	    }
	    
	    if(Input.GetButtonDown("Fire2") && tiempoSigAtaque <= 0){
	    	if (inventario.GetFlechas() > 0)
	    	{
		    	disparando = true;
		    	activaCapa("Ataque");
		    	Dispara();
		    	tiempoSigAtaque = tiempoEntreAtaques;
	    	}

	    }
    }
    
	void Dispara(){
		
		ControladorSonidos.Instance.EjecutarSonido(disparoSonido);

		switch(MovPlayer.dirAtaque){
		case 1: anim.SetTrigger("ataqueDAbajo"); break;
		case 2: anim.SetTrigger("ataqueDArriba"); break;
		case 3: anim.SetTrigger("ataqueDIzquierda"); break;
		case 4: anim.SetTrigger("ataqueDDerecha"); break;
		case 5: anim.SetTrigger("ataqueDArriba"); break;
		case 6: anim.SetTrigger("ataqueDArriba"); break;
		case 7: anim.SetTrigger("ataqueDAbajo"); break;
		case 8: anim.SetTrigger("ataqueDAbajo"); break;
		}
	}
    
	private void EmiteProyectil(){
		if(inventario.UsarFlecha()) // Esto resta 1 flecha y actualiza la UI
		{
			dirDisparo = MovPlayer.dirAtaque;
			Instantiate(proyectil, puntoEmision.position, transform.rotation);
		}

	}
    
	private void activaCapa(string Nombre){
		for(int i = 0; i < anim.layerCount; i++){
			anim.SetLayerWeight(i, 0); //Ambos layers con weight en 0
		}
		anim.SetLayerWeight(anim.GetLayerIndex(Nombre),1);
	}
}
