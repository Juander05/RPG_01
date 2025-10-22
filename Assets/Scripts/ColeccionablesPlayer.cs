using UnityEngine;

public class ColeccionablesPlayer : MonoBehaviour
{
	
	private GameObject player;
	public static string objAColeccionar;
	private Inventario inventario;

    void Start()
	{
		player = GameObject.Find("Player");
	    objAColeccionar = "";
	    inventario = FindObjectOfType<Inventario>();
    }
    
	private void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag == "vida"){
			if(VidasPlayer.vida < 5){
				VidasPlayer.vida++;
				player.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
				Destroy(obj.gameObject);
			}
			
		}
		
		if(obj.tag == "municion"){
			AplicaCambios(obj);
		}
		
		if(obj.tag == "moneda"){
			AplicaCambios(obj);
		}
		
		if(obj.tag == "gema1"){
			AplicaCambios(obj);
		}
		
		if(obj.tag == "gema2"){
			AplicaCambios(obj);
		}
		
		if(obj.tag == "gema3"){
			AplicaCambios(obj);
		}
		
		if(obj.tag == "gema4"){
			AplicaCambios(obj);
		}
	}
	
	private void AplicaCambios(Collider2D obj){
		objAColeccionar = obj.tag;
		inventario.EscribeEnArreglo();
		Destroy(obj.gameObject);
	}

}
