using UnityEngine;

public class MovCamara : MonoBehaviour
{
	
	public Camera camara;

	public void OnTriggerEnter2D(Collider2D obj){
		
		//Portal spawn-pueblo
		if (obj.gameObject.tag == "portal1"){
			Vector3 posicioncamara = new Vector3 (0,15,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (0,12,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal pueblo-spawn
		if (obj.gameObject.tag == "portal2"){
			Vector3 posicioncamara = new Vector3 (0,0,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (0,3,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal pueblo-interseccion
		if (obj.gameObject.tag == "portal3"){
			Vector3 posicioncamara = new Vector3 (23,18,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (16,17.2f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal interseccion-pueblo
		if (obj.gameObject.tag == "portal4"){
			Vector3 posicioncamara = new Vector3 (0,15,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (7,17.2f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal interseccion-cementerio
		if (obj.gameObject.tag == "portal5"){
			Vector3 posicioncamara = new Vector3 (23,3,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (20.5f,6.5f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal cementerio-interseccion
		if (obj.gameObject.tag == "portal6"){
			Vector3 posicioncamara = new Vector3 (23,18,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (20.5f,15.5f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal pueblocaminosur-pueblocaminonorte 
		if (obj.gameObject.tag == "portal7"){
			Vector3 posicioncamara = new Vector3 (0,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (this.transform.position.x,22,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal pueblocaminonorte-pueblocaminosur
		if (obj.gameObject.tag == "portal8"){
			Vector3 posicioncamara = new Vector3 (0,15,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (this.transform.position.x,18,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal pueblohuertosur-pueblohuertonorte
		if (obj.gameObject.tag == "portal9"){
			Vector3 posicioncamara = new Vector3 (0,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (6,20.3f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal pueblohuertonorte-pueblohuertosur
		if (obj.gameObject.tag == "portal10"){
			Vector3 posicioncamara = new Vector3 (0,15,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (6,18.4f,0);
			this.transform.position = posicionPlayer;
		}
		
		
		//Portal puebloizqsur-puebloizqnorte
		if (obj.gameObject.tag == "portal13"){
			Vector3 posicioncamara = new Vector3 (0,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (-7.5f,22,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal puebloizqnorte-puebloizqsur
		if (obj.gameObject.tag == "portal14"){
			Vector3 posicioncamara = new Vector3 (0,15,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (-7.5f,18,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal interseccion-bosque1P1
		if (obj.gameObject.tag == "portal15"){
			Vector3 posicioncamara = new Vector3 (26,32,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (23.5f,29,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque1P1-interseccion
		if (obj.gameObject.tag == "portal16"){
			Vector3 posicioncamara = new Vector3 (23,18,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (23.5f,21,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque1P1-bosque1P2
		if (obj.gameObject.tag == "portal17"){
			Vector3 posicioncamara = new Vector3 (44,32,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (36.2f,this.transform.position.y,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque1P2-bosque1P1
		if (obj.gameObject.tag == "portal18"){
			Vector3 posicioncamara = new Vector3 (26,32,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (33,this.transform.position.y,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque1P2-bosque1P3
		if (obj.gameObject.tag == "portal11"){
			Vector3 posicioncamara = new Vector3 (44,42,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (this.transform.position.x,38.5f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque1P3-bosque1P2
		if (obj.gameObject.tag == "portal12"){
			Vector3 posicioncamara = new Vector3 (44,32,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (this.transform.position.x,35.5f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque1P3-bosque1P4
		if (obj.gameObject.tag == "portal19"){
			Vector3 posicioncamara = new Vector3 (62,42,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (54,this.transform.position.y,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque1P4-bosque1P3
		if (obj.gameObject.tag == "portal20"){
			Vector3 posicioncamara = new Vector3 (44,42,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (51.5f,this.transform.position.y,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal pueblo-estatua
		if (obj.gameObject.tag == "portal21"){
			Vector3 posicioncamara = new Vector3 (0,40,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (0,36.8f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal estatua-pueblo
		if (obj.gameObject.tag == "portal22"){
			Vector3 posicioncamara = new Vector3 (0,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (0,28.4f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal pueblo-bosque2P1
		if (obj.gameObject.tag == "portal23"){
			Vector3 posicioncamara = new Vector3 (-23,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (-15.5f,23.2f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P1-pueblo
		if (obj.gameObject.tag == "portal24"){
			Vector3 posicioncamara = new Vector3 (0,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (-7.5f,23.2f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P1-bosque2P2
		if (obj.gameObject.tag == "portal25"){
			Vector3 posicioncamara = new Vector3 (-41,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (-33.5f,this.transform.position.y,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P2-bosque2P1
		if (obj.gameObject.tag == "portal26"){
			Vector3 posicioncamara = new Vector3 (-23,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (-31,this.transform.position.y,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P2-bosque2P3
		if (obj.gameObject.tag == "portal27"){
			Vector3 posicioncamara = new Vector3 (-41,40,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (-40,36.8f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P3-bosque2P2
		if (obj.gameObject.tag == "portal28"){
			Vector3 posicioncamara = new Vector3 (-41,25,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (-40,28.5f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P3-bosque2P4
		if (obj.gameObject.tag == "portal29"){
			Vector3 posicioncamara = new Vector3 (-41,50,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (this.transform.position.x,46.3F,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P4-bosque2P3
		if (obj.gameObject.tag == "portal30"){
			Vector3 posicioncamara = new Vector3 (-41,40,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (this.transform.position.x,43.5f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P4-bosque2P5
		if (obj.gameObject.tag == "portal31"){
			Vector3 posicioncamara = new Vector3 (-41,40,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (this.transform.position.x,43.5f,0);
			this.transform.position = posicionPlayer;
		}
		
		//Portal bosque2P4-bosque2P5
		if (obj.gameObject.tag == "portal32"){
			Vector3 posicioncamara = new Vector3 (-41,50,-10);
			camara.transform.position = posicioncamara;
			Vector3 posicionPlayer = new Vector3 (this.transform.position.x,46.3F,0);
			this.transform.position = posicionPlayer;
		}
		
	}
	
}
