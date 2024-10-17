using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
    }

    // Update is called once per frame
    void Update()
    {
        State nextState = currentState.Run(gameObject); // el run debe de estar en el update ya que se ejecuta todo el rato
        // el run nos devuelve un estado (state) que va a ser nulo sino cambiado de estado porque no se cumple o es el siguiente estado en caso de que la accion de cumpla

        if (nextState)
        {
            currentState = nextState; // si nextstate no es nulo, cambiamos la variable, ahora es el nuevo estado
        }
    }
    private void OnDrawGizmos()
    {
        if (currentState)
        {
            currentState.DrawAllACtionsGizmos(gameObject);//si currentsatet tiene algo lo dibujas
        }
        else if (initialState)
        {
            initialState.DrawAllACtionsGizmos(gameObject);// si initialstate tiene algo lo dibuja
        }
    }
}
 