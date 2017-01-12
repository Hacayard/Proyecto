using UnityEngine;

public class ManagerDespliegue : MonoBehaviour {

	public static ManagerDespliegue instancia;

	void Awake ()
	{
		if (instancia != null) {
			Debug.LogError ("Ya hay un Manager de unidades");
			return;
		}
		instancia = this;
	}

	public GameObject unidad_prefab;

	void Start(){
		unidad_despliegue = unidad_prefab;

	}
	private GameObject unidad_despliegue;

	public  GameObject Unidad_a_desplegar(){

		return unidad_despliegue;

	}
}
