using UnityEngine;
using System.Collections;

public class despliegue : MonoBehaviour {

	class Indices
	{
		public int x,y;

		public Indices(int a,int b){x=a; y=b;}
	}

	GameObject[,] Casillas;
	Indices Casilla_a_buscar;
	GameObject Esce;
	GameObject pospunt;


	// Use this for initialization
	void Start () {
		Esce = GameObject.Find ("Escenario");
		pospunt = GameObject.Find ("puntero2");
		Casilla_a_buscar = new Indices (0, 0);
		Casillas = Esce.GetComponent<GeneradorEscenario> ().Escenario;

	
	}
	
	// Update is called once per frame
	void Update () {
		EncontrarCasilla (pospunt.transform);
		if (Casillas [Casilla_a_buscar.x, Casilla_a_buscar.y].GetComponent<Casilla> ().deploy == true)
			if (Input.GetKeyDown (KeyCode.Z))
				Despliegue ();

	
	}

	void Despliegue(){
		if (Casillas[Casilla_a_buscar.x,Casilla_a_buscar.y].GetComponent<Casilla>().Unidadencasilla != null) {
			Debug.Log ("No puedes desplegar si hay otra unidad");
			return;
		}
		else{ 
			GameObject Unidadadesplegar = ManagerDespliegue.instancia.Unidad_a_desplegar ();
			Casillas[Casilla_a_buscar.x,Casilla_a_buscar.y].GetComponent<Casilla>().Unidadencasilla = (GameObject)Instantiate (Unidadadesplegar, pospunt.transform.position, pospunt.transform.rotation);
			Casillas[Casilla_a_buscar.x,Casilla_a_buscar.y].GetComponent<Casilla>().Unidadencasilla.transform.parent = GameObject.Find ("Unidades_jugador").transform;
		}	

	}
	void EncontrarCasilla(Transform pos_uni)
	{
		for (int x = 0; x < Esce.GetComponent<GeneradorEscenario>().max_casillas; x++) 
			for (int y = 0; y < Esce.GetComponent<GeneradorEscenario> ().max_casillas; y++)
				if (Casillas [x, y].transform.position.x == pos_uni.position.x)
				if (Casillas [x, y].transform.position.y == pos_uni.position.y) 
				{
					Casilla_a_buscar.x= x;
					Casilla_a_buscar.y= y;
				}
	}
}
