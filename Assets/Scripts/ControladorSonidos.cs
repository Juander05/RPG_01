using UnityEngine;

public class ControladorSonidos : MonoBehaviour
{
	
	public static ControladorSonidos Instance;
	private AudioSource audioSource;
	
    void Start()
	{
		
		if(Instance == null){
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy(gameObject);
		}
    	
		audioSource = GetComponent<AudioSource>();
		
    }

	public void EjecutarSonido(AudioClip sonido){
		audioSource.PlayOneShot(sonido);
	}
    
}
