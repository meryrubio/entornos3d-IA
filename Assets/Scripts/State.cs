using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct ActionParameters
{
    [Tooltip("Action that is gonna be executed")]
    public Action action;// acciones que van a ser ejecutadas //array de acciones

    [Tooltip("Indicates if the action´s check must be true or false")]
    public bool actionValue;
}

[System.Serializable]

public struct StateParameters
{
    [Tooltip("ActionParameters´, array")]
    public ActionParameters[] actionParameters;

    [Tooltip("If the action´s check equals actionValeu, nextState is pushed")]
    public State nextState;//si la accion check es igual a actionvalue el nextState pushed


    [Tooltip("Se cumplen todas las acciones o solo se tiene que cumplir una?")]
    public bool and;//para que se cumplan todas
}

public abstract class State : ScriptableObject // es abstract porque el Run no va a hacer nada
{
    public StateParameters[] stateparameters; //array de parametros de estado, estructura de datos

    protected State CheckActions(GameObject owner)
    {
        //devolvemos true si alguna de las acciones se cumple o false si es al contrario
        //recorre el array comprobando si la accion que me han puesto se cumple o no//recorre la lista de los parametros
        for (int i = 0; i < stateparameters.Length; i++)
        {
            bool todasLasAccionesSeHanCumplido = true; //asumimos que todas las acciones se van a cumplir
           for(int j = 0; j < stateparameters[i].actionParameters.Length; j++) //en cada parametro tenemos un array que tiene que cumplir asi que tenemos que recorrer ese array
           {
                ActionParameters actionParameter = stateparameters[i].actionParameters[j];
                if (actionParameter.action.Check(owner) == actionParameter.actionValue)//comprobando cada una de las acciones con el valor asignado
                {
                    if (!stateparameters[i].and)// si solo se tiene que cumplir una
                    {
                        //devolvemos el siguiente estado
                        return stateparameters[i].nextState;
                    }
                }
                else if (stateparameters[i].and) //una de las aciiones no se cumple
                {
                    todasLasAccionesSeHanCumplido = false;
                    break;//salimos del bucle porque una accion no se ha cumplido y estamos en and(esta marcado que se tienen que cumplir as dos)
                }
           }

            // si llegamos hasta aqui significa que el disenador ha marcado que todas las acciones tienen que cumplirse y, ademas, se han cumplido
            //comprobar si de verdad se ha cumplido todo
            if (stateparameters[i].and && todasLasAccionesSeHanCumplido)
            {
                return stateparameters[i].nextState;
            }
        }
        return null; //ninguna accion se cumple, por lo que no cambiamos de estado
    }

    public abstract State Run(GameObject owner); // el run comprueba si las acciones se cumplen y ademas ejecuta el comportamiento asociado al estado ( chase = perseguir)

    public void DrawAllACtionsGizmos(GameObject owner)
    {
        foreach( StateParameters parameter in stateparameters)//recorre los parametros
        {
            foreach (ActionParameters aP in parameter.actionParameters)
            {
                aP.action.DrawGizmos(owner);//recorre cada parametro,coge la accion que tiene asociada y  dibuja su gizmo
            }
            
        }
    }
}
