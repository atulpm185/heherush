using UnityEngine;

public class MovementMechanics : MonoBehaviour
{
	#region Singleton class: MovementMechanics

	public static MovementMechanics Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	#endregion

	Camera cam;

	public player player;

	[SerializeField] float pushForce = 1.5f;

	bool isDragging = false;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;

    public int Launching=0;

	public Collision2D col;

	//---------------------------------------
	void Start ()
	{
		cam = Camera.main;
		player.DesactivateRb ();
	}

	void Update ()
	{ 
		
	  if(Launching==0)
	  {
		if (Input.GetMouseButtonDown(0)) {
			isDragging = true;
			OnDragStart ();
		}
		if (Input.GetMouseButtonUp (0)) {
			isDragging = false;
			OnDragEnd ();
		}

		if (isDragging) {
			OnDrag ();
		}
	  }

	}

	//-Drag--------------------------------------
	void OnDragStart ()
	{
		player.DesactivateRb ();
		startPoint = cam.ScreenToWorldPoint (Input.mousePosition);


	}

	void OnDrag ()
	{
		endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
		distance = Vector2.Distance (startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		//just for debug
		Debug.DrawLine (startPoint, endPoint);

	}

	void OnDragEnd ()
	{
		//push the player
		player.ActivateRb ();

		player.Push (force);

	}


}
