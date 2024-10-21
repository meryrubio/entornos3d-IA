using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "GuardState(s)", menuName = "ScriptableObjects/State/GuardState")]

public class GuardState : State
{
    public Vector3 guardPoint;

    public string blendParameter;

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();

        navMeshAgent.SetDestination(guardPoint);// su destino es su punto de guardia
        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed); //la velocidad maxima a la que puede ir es speed, lo dividimos para que quede entre 0 a 1




        return nextState;
    }
}

