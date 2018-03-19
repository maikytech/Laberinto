using UnityEngine;
using System.Collections;
using UnityEngine.UI;		//Libreria para manejar texto

public class Player : MonoBehaviour
{
	public float force;
	public Text textTime;			//Variable tipo Text para controlar el cronometro.
	public Button buttonRestart;	//Variable tipo Button para reiniciar el juego.

	private float timeValue;		//Variable privada para manejar el tiempo.
	private bool gameOver;			//Variable privada que nos indica cuando el jugador pierde.

	// Use this for initialization
	void Start ()
	{
		timeValue = 30f;								//Valor inicial del cronometro en 30 segundos.
		buttonRestart.gameObject.SetActive (false);		//Desactivamos el boton de reinicio.
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//El metodo Update inicia solo si el jugador no ha perdido.
		if (gameOver != true)
		{
			//Variables que manejan el movimiento hacia adelante, hacia atras, hacia la derecha y hacia la izquierda.
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");


			//Vector con el que se manejara la posicion del Player.
			Vector3 vector = new Vector3 (h, 0.5f, v);

			//A la variable rb se le asigna la componente Rigibody del Player.
			Rigidbody rb = GetComponent<Rigidbody> ();
			//Le aplicamos una fuerza a rb, que se compone de un vector, una magnitud de la fuerza y un deltaTime.
			rb.AddForce (vector * force * Time.deltaTime);

			/* Time.deltaTime significa que cambiaremos los segundos por frames, es decir, en vez de correr a 10 m/segundo, correra
		 	* 10 m/frame, esto se hace para independizar las variables de tiempo deljuego de la velocidad de reloj y del hardware
		 	* en general en donde se corra el juego. */
			timeValue -= Time.deltaTime;

			if (timeValue <= 0f)
			{
				timeValue = 0.0f;								//Se coloca el cronometro en cero.
				gameOver = true;								//El jugador acaba de perder.
				buttonRestart.gameObject.SetActive (true);		//Se activa el boton de reincio en la pantalla.
			}

			//Se coloca el valor del tiempo constantemente en la pantalla, el valor de timeValue debe castearse a string.
			// "F2" garantiza que timeValue tenga dos caracteres.
			textTime.text = "Tiempo: " + timeValue.ToString ("F2");
		}
	}

	//Metodo que detecta el contacto del objeto actual con otro objeto, en ese momento recibe el collider del segundo objeto.
	void OnTriggerEnter(Collider obj)
	{
		//Pregunta si el tag del segundo objeto es el enlace.
		if (obj.gameObject.tag == "enlace")
		{
			//Preguntamos si la escena en la que estamos es el "Main".
			if(Application.loadedLevelName == "Main")
			{
				//Me lleva a la escena Scene1
				Application.LoadLevel("Scene1");
			}
			else
			{
				//Sino, me lleva a la escena Main, esto en el caso de que ya se encuentre en Scene1.
				Application.LoadLevel("Main");
			}
		}
	}

	public void resetGame()
	{
		//El Application.loadedLevelName devuelve el nombre del nivel actual.
		//El Application.LoadLevel carga el nivel con el nombre del parametro inicial.
		Application.LoadLevel (Application.loadedLevelName);
	}
}
