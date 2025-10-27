using UnityEngine;

public class AjustarResolucion : MonoBehaviour
{
	void Start()
	{
		int ancho = Display.main.systemWidth;
		int alto = Display.main.systemHeight;

		Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
		Screen.SetResolution(ancho, alto, true);

		Debug.Log($"Resolución ajustada a: {ancho}x{alto}");
	}
}