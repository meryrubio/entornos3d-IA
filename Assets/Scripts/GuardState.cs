using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "GuardState(s)", menuName = "ScriptableObjects/State/GuardState")]

public class GuardState : State
{
    public Vector3 guardPoint;

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(guardPoint);// su destino es su punto de guardia




        return nextState;
    }
}

