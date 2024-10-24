using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TimePassedAction (A)", menuName = "ScriptableObjects/Actions/TimePassedAction")]

public class TimePassedAction : Action
{
    //accion que te devuelva true si ha pasado un tiempo sino false

    public float maxTime;
    private float currentTime = 0;
    public override bool Check(GameObject owner)
    {
        currentTime += Time.deltaTime; //el timepo que pasa entre frames

        if(currentTime >= maxTime) //comprobar
        {
            currentTime = 0;// reiniciar contador
            return true;
        }
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
       
    }

   
}
