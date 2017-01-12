using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mostrar_info : MonoBehaviour {

		GameObject puntpos;
		GameObject Esce;
		GameObject[,] Matriz_escenario; 
		int maxcas;
		GameObject casilla_actual;
		GameObject info_casilla;
	    GameObject Texto_casilla;



	// Use this for initialization
	void Start () {
		puntpos = GameObject.Find("puntero2");
		Esce = GameObject.Find("Escenario");
		Matriz_escenario = Esce.GetComponent<GeneradorEscenario> ().Escenario;
		maxcas =  Esce.GetComponent<GeneradorEscenario> ().max_casillas;
		info_casilla = GameObject.Find ("Casilla_image");
		Texto_casilla = GameObject.Find ("Texto");


	
	}
	
	// Update is called once per frame
	void Update () {
		
		Mostrar_Imagen ();
	
	}

	void Mostrar_Imagen(){
		if(puntpos.transform.hasChanged) {
			for (int x = 0; x < maxcas; x++) {
				for (int y = 0; y < maxcas; y++) {
					if (Matriz_escenario [x, y].transform.position == puntpos.transform.position)
						casilla_actual = Matriz_escenario [x, y];
				}
			}
			if (casilla_actual != null) {
				info_casilla.GetComponent<RawImage> ().enabled = true;
				info_casilla.GetComponent<RawImage> ().texture = casilla_actual.GetComponent<Casilla> ().casilla_info;
				Texto_casilla.GetComponent<Text> ().enabled = true;
				Texto_casilla.GetComponent<Text> ().text = casilla_actual.GetComponent<Casilla> ().Informacion_escrita.GetComponent<Text> ().text;

			}

		}
	}
}
