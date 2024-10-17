using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public bool valeu; //si la ccion se tiene que cumplir o no
    public abstract bool Check(GameObject owner);// recibimos el owner porque lo vamos a ejecutar/

    public abstract void DrawGizmos(GameObject owner);
}
