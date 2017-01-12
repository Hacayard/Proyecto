using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitThings : MonoBehaviour {

	//Variables de unidad

	public int Vida;
	public int Fuerza;
	public int Defensa;
	public int Magia;
	public int Espiritu;
	public int Velocidad;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.Z))
		{
				menu_acciones();
		}
		//menu_acciones();(Aqui dentro iran el movimiento y ataques de la unidad)
		//sufrir_daño();
		//curarse();
		//morir();


	
	}

	void menu_acciones ()
	{
		GameObject Interfaz = GameObject.Find ("Menu_acciones");
		GameObject punt = GameObject.Find ("Puntero");

		Image[] Almacen = Interfaz.GetComponentsInChildren<Image> ();

		for (int i = 0; i < Almacen.Length; i++) 
		{
			Almacen [i].enabled = true;
		}
		//Animacion puntero a unidad seleccionada(parar movimiento)
		punt.GetComponent<ComportamientoPuntero>().enabled = false;


	}
}
