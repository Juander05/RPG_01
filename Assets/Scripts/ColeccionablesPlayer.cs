using UnityEngine;

public class ColeccionablesPlayer : MonoBehaviour
{
	
	[SerializeField] private int[] valoresInventario; //0-Sin elemento, # de elemento (diferente de 0)

    void Start()
    {
	    BorraArreglo();
    }
    
	private void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag == "vida"){
			if(VidasPlayer.vida<5){
				VidasPlayer.vida++;
				this.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
				Destroy(obj.gameObject);
			}
			
		}
		
		if(obj.tag == "municion"){
			Destroy(obj.gameObject);
		}
		
		if(obj.tag == "coleccionable1"){
			Destroy(obj.gameObject);
		}
		
		if(obj.tag == "coleccionable2"){
			Destroy(obj.gameObject);
		}
	}
	
	private void BorraArreglo(){
		for(int i = 0; i < valoresInventario.Length; i++){
			valoresInventario[i] = 0;
		}
	}

}
