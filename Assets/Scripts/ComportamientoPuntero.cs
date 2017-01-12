using UnityEngine;
using System.Collections;


public class ComportamientoPuntero : MonoBehaviour {

	int x,y;
	int x_final, y_final;
	public GameObject puntero;
	GameObject Esce;
	GameObject casilla;

	// Use this for initialization
	void Start () {
		Esce = GameObject.Find ("Escenario");
	}


	// Update is called once per frame
	void Update () {
		StartCoroutine(Movement ());

	}

	IEnumerator Movement() {
		if (Input.GetKey (KeyCode.UpArrow)) {
			for (x = 0; x < Esce.GetComponent<GeneradorEscenario>().max_casillas; x++) {
				for (y = 0; y < Esce.GetComponent<GeneradorEscenario>().max_casillas; y++) {
					if (puntero.transform.position.x == Esce.GetComponent<GeneradorEscenario>().Escenario[x, y].transform.position.x)
						if (puntero.transform.position.y == Esce.GetComponent<GeneradorEscenario>().Escenario[x, y].transform.position.y) {
							x_final = x;
							y_final = y;
						}
								
				}
			}
			if (y_final + 1 < Esce.GetComponent<GeneradorEscenario> ().max_casillas) {
				puntero.transform.position = Esce.GetComponent<GeneradorEscenario> ().Escenario [x_final, y_final + 1].transform.position;
			}
		} 
		else if (Input.GetKey (KeyCode.DownArrow)) {
			for (x = 0; x < Esce.GetComponent<GeneradorEscenario>().max_casillas; x++) {
				for (y = 0; y < Esce.GetComponent<GeneradorEscenario>().max_casillas; y++) {
					if (puntero.transform.position.x == Esce.GetComponent<GeneradorEscenario>().Escenario[x, y].transform.position.x)
					if (puntero.transform.position.y == Esce.GetComponent<GeneradorEscenario>().Escenario[x, y].transform.position.y) {
						x_final = x;
						y_final = y;
					}

				}
			}
			if (y_final != 0) {
				puntero.transform.position = Esce.GetComponent<GeneradorEscenario> ().Escenario [x_final, y_final - 1].transform.position;
			}
			
		}
		else if (Input.GetKey(KeyCode.RightArrow)) {
			for (x = 0; x < Esce.GetComponent<GeneradorEscenario>().max_casillas; x++) {
				for (y = 0; y < Esce.GetComponent<GeneradorEscenario>().max_casillas; y++) {
					if (puntero.transform.position.x == Esce.GetComponent<GeneradorEscenario>().Escenario[x, y].transform.position.x)
					if (puntero.transform.position.y == Esce.GetComponent<GeneradorEscenario>().Escenario[x, y].transform.position.y) {
						x_final = x;
						y_final = y;
					}

				}
			}
			if (x_final + 1 < Esce.GetComponent<GeneradorEscenario> ().max_casillas) {
				puntero.transform.position = Esce.GetComponent<GeneradorEscenario> ().Escenario [x_final + 1, y_final].transform.position;
			}
		}
			
		else if (Input.GetKey(KeyCode.LeftArrow)){
			for (x = 0; x < Esce.GetComponent<GeneradorEscenario>().max_casillas; x++) {
				for (y = 0; y < Esce.GetComponent<GeneradorEscenario>().max_casillas; y++) {
					if (puntero.transform.position.x == Esce.GetComponent<GeneradorEscenario>().Escenario[x, y].transform.position.x)
					if (puntero.transform.position.y == Esce.GetComponent<GeneradorEscenario>().Escenario[x, y].transform.position.y) {
						x_final = x;
						y_final = y;
					}

				}
			}
			if (x_final != 0) {
				puntero.transform.position = Esce.GetComponent<GeneradorEscenario> ().Escenario [x_final - 1, y_final].transform.position;
			}
		}
		yield break;
	}



	void OnCollisionEnter2D (Collision2D coll){
		if (coll.collider.gameObject.tag == "casillas")
			coll.collider.SendMessage ("Casilla_info");
		if (coll.collider.gameObject.tag == "enemigo")
			coll.collider.SendMessage ("Enemigo_info");
		if (coll.collider.gameObject.tag == "Personaje")
			coll.collider.SendMessage ("Personaje_info");
	}

}