using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Mover_Unidad : MonoBehaviour{
	
	class Indices
	{
		public int x,y;

		public Indices(int a,int b){x=a; y=b;}
	}

	private GameObject Esce;
	private GameObject puntero;
	private GameObject[,] Casillas;
	private Indices Indices_cas_actual;
	private int vel_tropa,x_unidad, y_unidad, n_casillas;
	public Sprite casilla_ok,casilla_obstaculo_bad, casilla_vacia_bad, casilla_despliegue_ok;
	public List<GameObject> CasillasValidas = new List<GameObject> ();
	public List<GameObject> CasillasFinales= new List<GameObject> ();




	void Start()
	{
		Indices_cas_actual = new Indices (0, 0);
		Esce = GameObject.Find ("Escenario");
		Casillas = Esce.GetComponent<GeneradorEscenario> ().Escenario;
		n_casillas = Esce.GetComponent<GeneradorEscenario> ().max_casillas;
		puntero = GameObject.Find ("puntero2");
		EncontrarCasilla (puntero.transform);
		x_unidad = Indices_cas_actual.x;
		y_unidad = Indices_cas_actual.y;
	}
		

	public void Mostrar_grid()
	{

		GameObject unidad = Casillas [x_unidad,y_unidad].GetComponent<Casilla> ().Unidadencasilla;
		vel_tropa = unidad.GetComponent<UnitThings> ().Velocidad;

		Calcular_Grid (vel_tropa);
		for (int i = 0; i < CasillasFinales.Count; i++) {
			if (CasillasFinales[i].GetComponent<Casilla>().transitable == true) {
				if (CasillasFinales [i].GetComponent<Casilla> ().deploy == true)
					CasillasFinales [i].GetComponent<SpriteRenderer> ().sprite = casilla_despliegue_ok;
				else
					CasillasFinales [i].GetComponent<SpriteRenderer> ().sprite = casilla_ok;
			}
		}
			

	}

				
	void Calcular_Grid(int velocidad){

		for (int x = 0; x < n_casillas; x++) {
			for (int y = 0; y < n_casillas; y++) {
				float Distancia = Vector2.Distance (Casillas [x_unidad, y_unidad].transform.position, Casillas [x, y].transform.position);
				if (Distancia <= 15* velocidad) {
					CasillasValidas.Add (Casillas [x, y]);
					
				}
			}

			Calcular_Grid_recursivo (Casillas[x_unidad, y_unidad], velocidad+1);
		}	
	}

	void Calcular_Grid_recursivo (GameObject Casilla, int velocidad){
		EncontrarCasilla (Casilla.transform);
		int coste = Casilla.GetComponent<Casilla> ().coste_mov;
		if (!CasillasValidas.Contains(Casilla)) {
			return;
		}
		if(CasillasFinales.Contains(Casilla)){
			return;
		}

		if (velocidad <= 0)
			return;
		else{
			CasillasFinales.Add (Casilla);
			if (Indices_cas_actual.x == 0 && Indices_cas_actual.y == 0) {
					Calcular_Grid_recursivo (Casillas[Indices_cas_actual.x + 1, Indices_cas_actual.y], velocidad - coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y+1], velocidad -coste);
			}
			else if (Indices_cas_actual.x == 0 && Indices_cas_actual.y == n_casillas -1) {
					Calcular_Grid_recursivo (Casillas[Indices_cas_actual.x + 1, Indices_cas_actual.y], velocidad - coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y-1], velocidad -coste);
			}
			else if (Indices_cas_actual.x == n_casillas-1 && Indices_cas_actual.y == 0) {
					Calcular_Grid_recursivo (Casillas[Indices_cas_actual.x - 1, Indices_cas_actual.y], velocidad - coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y+1], velocidad -coste);
			}
			else if (Indices_cas_actual.x == n_casillas - 1 && Indices_cas_actual.y == n_casillas - 1) {
					Calcular_Grid_recursivo (Casillas[Indices_cas_actual.x - 1, Indices_cas_actual.y], velocidad - coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y-1], velocidad -coste);
			}
			else if (Indices_cas_actual.x == 0 && Indices_cas_actual.y > 0 && Indices_cas_actual.y < n_casillas - 1) {
					Calcular_Grid_recursivo (Casillas[Indices_cas_actual.x + 1, Indices_cas_actual.y], velocidad - coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y+1], velocidad -coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y-1], velocidad -coste);
			}
			else if (Indices_cas_actual.y == 0 && Indices_cas_actual.x > 0 && Indices_cas_actual.x < n_casillas - 1) {
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x + 1, Indices_cas_actual.y], velocidad - coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x-1, Indices_cas_actual.y], velocidad -coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y+1], velocidad -coste);
			}
			else if (Indices_cas_actual.x == n_casillas-1 && Indices_cas_actual.y > 0 && Indices_cas_actual.y < n_casillas - 1) {
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x - 1, Indices_cas_actual.y], velocidad - coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y+1], velocidad -coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y-1], velocidad -coste);
			}
			else if (Indices_cas_actual.y == n_casillas-1 && Indices_cas_actual.x > 0 && Indices_cas_actual.x < n_casillas - 1) {
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x + 1, Indices_cas_actual.y], velocidad - coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x-1, Indices_cas_actual.y], velocidad -coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y-1], velocidad -coste);
			}
			else if (Indices_cas_actual.x > 0 && Indices_cas_actual.x < n_casillas-1 && Indices_cas_actual.y >0 && Indices_cas_actual.y < n_casillas-1) {
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x + 1, Indices_cas_actual.y], velocidad -coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x-1, Indices_cas_actual.y], velocidad -coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y-1], velocidad -coste);
					Calcular_Grid_recursivo(Casillas[Indices_cas_actual.x, Indices_cas_actual.y+1], velocidad -coste);
			} else {
				Debug.Log ("Algo ha ido mal");
				return;
			}
				
	}
		return;
}
				
			


	void EncontrarCasilla(Transform pos)
	{
		for (int x = 0; x < n_casillas; x++) 
			for (int y = 0; y < n_casillas; y++)
				if (Casillas [x, y].transform.position.x == pos.position.x)
					if (Casillas [x, y].transform.position.y == pos.position.y) 
					{
						Indices_cas_actual.x = x;
						Indices_cas_actual.y = y;
					}
	}
		

}