using UnityEngine;
using System.Collections;

public class ControllerCamera : MonoBehaviour
{
	//Creamos una instancia del player, tendremos que asignarlo manualmente a traves del inspector de la camara.
	public GameObject player;

	private Vector3 posicionInicial;

	// Use this for initialization
	void Start ()
	{	
		//Vector de distancia entre la posicion de la camara(this) y la posicion del player.
		posicionInicial = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		/* La camara seguira al player, esto lo hacemos asignando a la camara la posicion del player en todo momento mas la 
		posicion Inicial */ 
		this.transform.position = player.transform.position + posicionInicial;
	}
}
