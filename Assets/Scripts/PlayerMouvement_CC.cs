using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMouvement_CC : MonoBehaviour
{
    //NO HAY RIGIDBODY -> todo en Update
    //7EL CARACTER private void OnControllerColliderH TIENE UN COLLIDER INTEGRADO

    private CharacterController characterController;

    public float speed, runningSpeed, rotationSpeed, gravityScale, jumpForce;

    private float yvelocity = 0, currentSpeed;

    private Vector3 movementVector;
    private Vector3 auxMovementVector;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravityScale = Mathf.Abs(gravityScale); //no hace falta menos porque se lo ponemos luego
    }

    // Update is called once per frame
    void Update()
    {


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift); //velocidad de running
        float mouseX = Input.GetAxis("Mouse X");//mouse para la rotación / la sensibilidad del raton ya va asociada al input

        bool jumpPressed = Input.GetKey(KeyCode.Space);

        Jump(jumpPressed);

        Movement(x, z, shiftPressed);

        //RotatePlayer(mouseX);
    }

    void Jump(bool jumpPressed)
    {
        if (jumpPressed && characterController.isGrounded)
        {
            yvelocity = 0; //para que siempre el salto sea igual, reiniciamos la velocidad en 0
            yvelocity += Mathf.Sqrt(jumpForce * 3 * gravityScale);// la raiz cuadrada suaviza el salto

        }
    }

    void Movement(float x, float z, bool shiftPressed)
    {
        if (shiftPressed)
        {
            currentSpeed = runningSpeed;//si presionas el shif se cambia a la velocidad de running
        }
        else
        {
            currentSpeed = speed;// si no lo presionas se pone la velocidad normal
        }

         Vector3 movementVector = (transform.forward * currentSpeed * z) + (transform.right * currentSpeed * x);
        auxMovementVector = movementVector;

        if (!characterController.isGrounded)
        {
            yvelocity -= gravityScale; // aqui le añadimos el menos si no estamos en el suelo
        }

        movementVector.y = yvelocity;// le establecemos la y que esta relacioonada con la velocidad

        movementVector *= Time.deltaTime; //movementVector = movementVector * DeltaTime //para que se mueva a la misma velocidad en diferentes pc ->  * deltatime

        characterController.Move(movementVector); // metodo que tiene el character controller para mover el objeto que tinee asignado

    }

    public Vector3 GetMovementVector() //para acceder desde el playeranimations
    {
        return auxMovementVector;
    }

    void RotatePlayer(float mouseX)
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }

}
