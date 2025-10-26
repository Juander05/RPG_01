using UnityEngine;

public class DisparaProyectil : MonoBehaviour
{
	
	[SerializeField] private float velocidad = 8.0f;
	

	void FixedUpdate(){
		
		Vector3 dir = Vector3.zero;

		switch(CAD.dirDisparo){
		case 1: dir = new Vector3(0, -1, 0); break;   // Abajo
		case 2: dir = new Vector3(0, 1, 0); break;    // Arriba
		case 3: dir = new Vector3(-1, 0, 0); break;   // Izquierda
		case 4: dir = new Vector3(1, 0, 0); break;    // Derecha
		case 5: dir = new Vector3(-1, 1, 0).normalized; break;  //  Arriba-Izquierda
		case 6: dir = new Vector3(1, 1, 0).normalized; break;   //  Arriba-Derecha
		case 7: dir = new Vector3(-1, -1, 0).normalized; break; //  Abajo-Izquierda
		case 8: dir = new Vector3(1, -1, 0).normalized; break;  //  Abajo-Derecha
		}

		transform.position += dir * Time.deltaTime * velocidad;

	}
    
	private void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "limites"){
			Destroy(this.gameObject);
		}
		
		if(collision.gameObject.tag == "enemigo"){{
			collision.transform.GetComponent<Enemigo>().TomarDaño(1);
			Destroy(this.gameObject);
		}}
	}
}
