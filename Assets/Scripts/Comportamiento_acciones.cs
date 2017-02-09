using UnityEngine;
using System.Collections;

public class Comportamiento_acciones : MonoBehaviour {

	class Indices
	{
		public int x,y;

		public Indices(int a,int b){x=a; y=b;}
	}

	GameObject Esce;
	GameObject[,] Casillas;
	Indices Indices_cas_actual;
	public Material Azul,Rojo;




	void Start()
	{
		Indices_cas_actual = new Indices (0, 0);
		Esce = GameObject.Find ("Escenario");
		Casillas = Esce.GetComponent<GeneradorEscenario> ().Escenario;
	}

	public void Mover_unidad(GameObject unidad)
	{

		Mostrar_grid (unidad);
	}

	private void Mostrar_grid(GameObject unidad)
	{
		EncontrarCasilla (unidad.transform);
		UnitThings Stats = unidad.GetComponent<UnitThings> ();
		for (int x = Indices_cas_actual.x; x < Indices_cas_actual.x+Stats.Velocidad; x++) {
			for (int y = Indices_cas_actual.y; y <Indices_cas_actual.y+Stats.Velocidad; y++) {
				if (Casillas[x,y].GetComponent<Casilla>().transitable == false) {
					Casillas[x,y].GetComponent<SpriteRenderer>().material = Azul;
				} else {
					Casillas[x,y].GetComponent<SpriteRenderer>().material = Rojo;
				}
			}
			
		}

	}

	void EncontrarCasilla(Transform pos_uni)
	{
		for (int x = 0; x < Esce.GetComponent<GeneradorEscenario>().max_casillas; x++) 
			for (int y = 0; y < Esce.GetComponent<GeneradorEscenario> ().max_casillas; y++)
				if (Casillas [x, y].transform.position.x == pos_uni.position.x)
					if (Casillas [x, y].transform.position.y == pos_uni.position.y) 
					{
					Indices_cas_actual.x= x;
					Indices_cas_actual.y= y;
					}
	}
}
