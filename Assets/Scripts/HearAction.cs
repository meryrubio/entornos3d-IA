using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HearAction(A)", menuName = "ScriptableObjects/Actions/HearAction")]

public class HearAction : Action
{
    public float radius = 20f;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up); // creamos un array como esfera porque escuchamos en todas la direcciones, casteamos una esfera

        GameObject target = owner.GetComponent<TargetReference>().target; //target, ubi del player

        foreach(RaycastHit hit in hits) //recorremos todos los objetos que escuchamos dentro de la esfera
        {
            if(hit.collider.gameObject == target)
            {
                // si coincide con el objetivo le hemos escuchado / oler
                return true;
            }
        }
        return false;// si no coincide, no le escucho / huelo
    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(owner.transform.position, radius);
    }

    //todoas las caaiione no van a tener el mismo gizom, en el estado metodo abstracto que invocase al draw gizmo, y private void OnEnable()
    //{
    //    las state machine ondrawgizmo y llamar al metodo del estado
    //}
}
