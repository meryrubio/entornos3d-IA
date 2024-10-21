using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMouvement_CC playerMouvement_CC;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMouvement_CC = GetComponent<PlayerMouvement_CC>();
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        //bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        //if(x!= 0 || z!= 0)
        //{
        //    //se esta moviendo 
        //    if(shiftPressed) //si se esta moviendo y tiene shifpresionado
        //    {
        //        //y ademas está corriendo
        //        animator.SetBool("isrunning", true);
        //        animator.SetBool("iswalking", false);
        //    }
        //    else
        //    {
        //        //y ademas esta andando
        //        animator.SetBool("isrunning", false);
        //        animator.SetBool("iswalking", true);
        //    }
        //}
        //else
        //{
        //    //esta quieto
        //    animator.SetBool("isrunning", false);
        //    animator.SetBool("iswalking", false);
        //}
    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed", playerMouvement_CC.GetCurrentSpeed() / playerMouvement_CC.runningSpeed);
    }
}
