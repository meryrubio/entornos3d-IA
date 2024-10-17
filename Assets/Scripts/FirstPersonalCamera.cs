using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonalCamera : MonoBehaviour
{

    //LA ROTACION DEL JUGADOR NO VA EN EL JUGADOR VA EN LA CAMARA


    public float mouseSens;
    public Transform playerTransform;

    private float mouseYRotation;//tiene que llevar un seguimiento de los grados

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; //Confined = tiene limites, Locked = hasta que no clickead no desaparece, None = no hace na
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;//mouse para la rotación en x / la sensibilidad del raton ya va asociada al input
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;//mouse para la rotación en y / la sensibilidad del raton ya va asociada al input

        mouseYRotation -= mouseY; // los ejes no esten invertidos se pone el menos

        transform.localEulerAngles = Vector3.right * mouseYRotation; //los angulos eulerianos son los normales, los estamos modificando/right porque queremos que mire arriba y abajo
        playerTransform.Rotate(Vector3.up * mouseX); // vector 3 = (0,1,0)
    }
}
