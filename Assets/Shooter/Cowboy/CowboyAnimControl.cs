using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyAnimControl : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int dead = Animator.StringToHash("Dead");
        int dissapeared = Animator.StringToHash("Dissapeared");
/*        
        EnemyCharacter c = 
        if (stateInfo.nameHash == dead)
        {

        }
        if (stateInfo.nameHash == dead)
        {

        }
        clone = Instantiate(particle, animator.rootPosition, Quaternion.identity) as GameObject;
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.AddExplosionForce(power, animator.rootPosition, radius, 3.0f);
        */
    }
}
