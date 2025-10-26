using System;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{

    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
	public Animator anim;
    
	private string capaIdle = "Idle";
	private string capaCaminar = "Caminar";
	private bool PlayerMoviendose = false;
	private float ultimoMovX, ultimoMovY;
	
	public static int dirAtaque = 0;	// 1-Front, 2-Back, 3-Left, 4-Right

    void FixedUpdate(){
	    Movimiento();
	    if(CCC.atacando == false && CAD.disparando == false){
	    	AnimacionesPlayer();
	    }
    }

    private void Movimiento(){
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        dirMov = new Vector2( movX, movY ).normalized;
	    rb.linearVelocity = new Vector2 (dirMov.x * velMov ,dirMov.y * velMov);
	    
	    if (movX == -1 && movY == 1) {      //  arriba-izquierda
		    dirAtaque = 5;
	    }
	    else if (movX == 1 && movY == 1) {  //  arriba-derecha
		    dirAtaque = 6;
	    }
	    else if (movX == -1 && movY == -1) { //  abajo-izquierda
		    dirAtaque = 7;
	    }
	    else if (movX == 1 && movY == -1) {  //  abajo-derecha
		    dirAtaque = 8;
	    }
	    else if (movX == -1) {
		    dirAtaque = 3; // izquierda
	    }
	    else if (movX == 1) {
		    dirAtaque = 4; // derecha
	    }
	    else if (movY == -1) {
		    dirAtaque = 1; // abajo
	    }
	    else if (movY == 1) {
		    dirAtaque = 2; // arriba
	    }
        
	    if(movX == 0 && movY == 0){		//Idle
	    	PlayerMoviendose = false;
	    } else{		//Caminar
	    	PlayerMoviendose = true;
	    	ultimoMovX = movX;
	    	ultimoMovY = movY;
	    }
	    
	    ActualizaCapa();
        
    }

    private void AnimacionesPlayer(){
	    anim.SetFloat("movX", ultimoMovX);
	    anim.SetFloat("movY", ultimoMovY);

    }
    
	private void ActualizaCapa(){
		if(CCC.atacando == false && CAD.disparando == false){
			if(PlayerMoviendose){
				ActivaCapa(capaCaminar);
				Debug.Log("Caminando");
			} else{
				ActivaCapa(capaIdle);
				Debug.Log("Idle");
			}
		} else {
			ActivaCapa("Ataque");
		}
	}
	
	private void ActivaCapa(string nombre){
		for(int i=0; i < anim.layerCount; i++){
			anim.SetLayerWeight(i, 0);		//Ambos layers con weight en 0
		}
		
		anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
	}


}
