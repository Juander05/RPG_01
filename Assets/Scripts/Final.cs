using UnityEngine;

public class Final : MonoBehaviour
{
	public GameObject boton;
	public GameObject fin;
	private bool isPlayerInRange = false;
   
	public void EjecutaFin(){
		fin.SetActive(true);
		Time.timeScale = 0;
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			isPlayerInRange = true;
			boton.SetActive(true);
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			isPlayerInRange = false;
			boton.SetActive(false);
			Debug.Log("no se puede iniciar dialogo");
            
		}
	}
}
