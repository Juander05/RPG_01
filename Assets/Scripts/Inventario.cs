using UnityEngine;

public class Inventario : MonoBehaviour
{
	
	private bool muestraInventario;
	public GameObject goInventario;
	private GameObject player;

    void Start(){
	    muestraInventario = false;
	    player = GameObject.Find("Player");
    }

    
    
	public void StatusInventario(){
		if(muestraInventario){
			muestraInventario = false;
			goInventario.SetActive(false);
			Time.timeScale = 1;
		} else{
			muestraInventario = true;
			goInventario.SetActive(true);
			Time.timeScale = 0;
		}
	}
	
	
    
}
