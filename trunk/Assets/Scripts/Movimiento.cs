using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class Movimiento : MonoBehaviour {

	public int velocidadVertical = 6;
	public int velocidadHorizontal = 6;
	public int gravedad = 20;
	
	private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

	void FixedUpdate() {
        moveDirection.x = Input.GetAxis("Vertical") * velocidadVertical;
		moveDirection.z = Input.GetAxis("Horizontal") * velocidadHorizontal;
		
		moveDirection.y -= gravedad;

        controller.Move(moveDirection * Time.deltaTime);
	}
}
