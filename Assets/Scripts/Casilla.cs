using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Casilla : MonoBehaviour {

	public bool especial;
	public bool deploy;
	public bool transitable;
	GameObject Unidadencasilla;
	GameObject Esce;
	GameObject pospunt;
	int x,y,x_actual, y_actual;
	public Texture casilla_info;
	public Text Informacion_escrita;






	// Use this for initialization
	void Start (){
		Esce = GameObject.Find ("Escenario");
		pospunt = GameObject.Find ("puntero2");

		
	}
	
	// Update is called once per frame
	void Update () {

		Despliegue ();
		

	}

	void Despliegue(){
		for (x = 0; x < Esce.GetComponent<GeneradorEscenario> ().max_casillas; x++)
		{
			for (y = 0; y < Esce.GetComponent<GeneradorEscenario> ().max_casillas; y++) 
			{
				if (Esce.GetComponent<GeneradorEscenario> ().Escenario [x, y].transform.position == pospunt.transform.position) 
				{
					if (Esce.GetComponent<GeneradorEscenario> ().Escenario [x, y].GetComponent<Casilla> ().deploy == true)
						{
						if(Input.GetKey(KeyCode.Z))
							{
							
									GameObject Unidadadesplegar = ManagerDespliegue.instancia.Unidad_a_desplegar ();
									Unidadencasilla =(GameObject)Instantiate(Unidadadesplegar, pospunt.transform.position, pospunt.transform.rotation);
									return;
								}
							}
						}
				
				}
			}
		return;
		}

}



