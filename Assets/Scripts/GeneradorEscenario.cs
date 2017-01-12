using UnityEngine;
using System.Collections;

public class GeneradorEscenario : MonoBehaviour {
	
	int indicex, indicey;
	Vector3 posicion_puntero;
	public GameObject casilla,casilla_obstaculo,casilla_despliegue,casilla_vacia;
	public int max_casillas= 20;
	public GameObject[,] Escenario;
	int rand;

	// Use this for initialization
	void Awake () {
		GenerarEscenario ();
	}


	public void GenerarEscenario(){
		posicion_puntero = new Vector3 (0f, 0f, 1f);
		Escenario = new GameObject [max_casillas,max_casillas];
		for (indicex = 0; indicex < max_casillas; indicex++){
			posicion_puntero.y = 0f;
			for (indicey = 0; indicey < max_casillas; indicey++) {
				rand = Random.Range (0, 11);
				if (rand < 7) 
					Escenario [indicex, indicey] = (GameObject)Instantiate (casilla, posicion_puntero, transform.rotation);
				else if(rand > 7 && rand < 9 )
					Escenario [indicex, indicey] = (GameObject)Instantiate (casilla_obstaculo, posicion_puntero, transform.rotation);
				else if(rand > 9 && rand < 11 )
					Escenario [indicex, indicey] = (GameObject)Instantiate (casilla_despliegue, posicion_puntero, transform.rotation);
				else
					Escenario [indicex, indicey] = (GameObject)Instantiate (casilla_vacia, posicion_puntero, transform.rotation);
				posicion_puntero.y = posicion_puntero.y + 12.5f;
			}
			posicion_puntero.x = posicion_puntero.x + 12.5f;
		}

	}
}
