using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour
{
	public GameObject menuPrincipal;
	public GameObject menuOpciones;
	
	public void ContinuaJuego() {
		SceneManager.LoadScene("SampleScene");
	}
	
	public void Salir() {
		Application.Quit();
		Debug.Log("El jugador ha salido del juego");
	}
	
	public void OpenOptionsPanel(){
		menuPrincipal.SetActive(false);
		menuOpciones.SetActive(true);
	}
	
	public void OpenMainMenuPanel(){
		menuPrincipal.SetActive(true);
		menuOpciones.SetActive(false);
	}
	
}
