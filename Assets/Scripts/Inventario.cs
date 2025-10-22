using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
	
	private bool muestraInventario;
	public GameObject goInventario;
	[SerializeField] private string[] valoresInventario; //"" Sin elemento, string elemento
	private int numMonedas, numFlechas;
	Button boton; //Botones del inventario
	public Sprite moneda, Gema1, Gema2, Gema3, Gema4, flecha, contenedor;
	[SerializeField] private Button botonFlechas;

    void Start(){
	    muestraInventario = false;
	    BorraArreglo();
	    numFlechas = 0;
	    numMonedas = 0;
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
	
	public void EscribeEnArreglo(){
		if(VerificaEnArreglo() == -1){	//No esta en el inventario
			for(int i = 0; i < valoresInventario.Length; i++){
				if(valoresInventario[i] == ""){	//Lo coloca en la primera posicion vacia que encuentre
					valoresInventario[i] = ColeccionablesPlayer.objAColeccionar;
					DibujaElementos(i);
					break;
				}
			}
		} else {	//Si ya esta en el inventario, ubica su posicion y suma  uno al elemento 
			DibujaElementos(VerificaEnArreglo());
		}
	}
	
	private int VerificaEnArreglo(){
		int pos = -1;
		for(int i = 0; i < valoresInventario.Length; i++){
			if(valoresInventario[i] == ColeccionablesPlayer.objAColeccionar){
				pos = i;
				break;
			}
		}
		return pos;
	}
	
	public void DibujaElementos(int pos){
		StatusInventario();
		boton = GameObject.Find("Elemento ("+pos+")").GetComponent<Button>();
		switch (ColeccionablesPlayer.objAColeccionar){
			case "gema1":
				contenedor = Gema1;
				break;
				
			case "gema2":
				contenedor = Gema2;
				break;
				
			case "gema3":
				contenedor = Gema3;
				break;
				
			case "gema4":
				contenedor = Gema4;
				break;
				
			case "moneda":
				contenedor = moneda;
				numMonedas++;
				boton.GetComponentInChildren<Text>().text = "x" + numMonedas.ToString();
				break;
				
			case "municion":
				contenedor = flecha;
				numFlechas+= 5;
				boton.GetComponentInChildren<Text>().text = "x" + numFlechas.ToString();
				break;
		}
		boton.GetComponent<Image>().sprite = contenedor;
	}
	
	
	public void RestaFlechas(int cantidad)
	{
		numFlechas += cantidad;

		// (Opcional) Actualiza visualmente el texto del botón de flechas si lo tienes visible
		for (int i = 0; i < valoresInventario.Length; i++)
		{
			if (valoresInventario[i] == "municion")
			{
				boton = GameObject.Find("Elemento (" + i + ")").GetComponent<Button>();
				boton.GetComponentInChildren<Text>().text = "x" + numFlechas.ToString();
				break;
			}
		}
	}
	
	public bool UsarFlecha()
	{
		if(numFlechas > 0)
		{
			numFlechas--;

			// Actualiza visualmente el botón si está asignado
			if(botonFlechas != null)
				botonFlechas.GetComponentInChildren<Text>().text = "x" + numFlechas.ToString();

			return true;
		}

		return false;
	}

	public int GetFlechas()
	{
		return numFlechas;
	}
	
	public void BorraArreglo(){
		for(int i = 0; i < valoresInventario.Length; i++){
			valoresInventario[i] = "";
		}
	}
    
}
