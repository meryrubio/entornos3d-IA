using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "ChaseState(s)" , menuName = "ScriptableObjects/State/ChaseState")]
//para crear una opcion en el menu, para crear estados acciones sin necesidad de codificar nada
//ScriptableObject es  un cacho de codigo que sacamos a los diseñadores para que puedan modificarlo sin tocar el resto del codigo

public class ChaseState : State
{
    //Script PARA PERSEGUIR
 public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>(); //owner tiene el componente de navmeshagent / nos podemos mover
        GameObject target = owner.GetComponent<TargetReference>().target; // oye owner dame tu componente de targetreference / tenemos el objetivo por el que nos vamos a mover

        navMeshAgent.SetDestination(target.transform.position);// el setdestination le dice al agente que su destino es el transform, y el navmeshagent sabe moverse por el terreno





        return nextState;
    }
}
