using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class inputselect : MonoBehaviour {

	public EventSystem eventsystem;
	public GameObject SelectedObject;
	public StandaloneInputModule standinput;
	private GameObject Interfaz;
	private GameObject puntero;

	private bool buttonselected;

	// Use this for initialization
	void Start () {
		Interfaz = GameObject.Find("UI/Canvas/Portait_Menu_acciones/Panel_acciones");
		puntero = GameObject.Find ("Puntero");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetAxisRaw("Vertical") != 0 && buttonselected == false)
			{
				eventsystem.SetSelectedGameObject (SelectedObject);
				buttonselected = true;
			}
		if (Input.GetButtonDown ("Cancel")) {
			Interfaz.SetActive (false);
			puntero.GetComponent<ComportamientoPuntero> ().enabled = true;

		}
			
	
	}
}
