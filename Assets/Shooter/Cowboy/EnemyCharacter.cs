using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    float lifeCountdown = 0.0f;
    Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        //find Animator
        animator = transform.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Hit(string partname)
    {
        Debug.Log("hit");
    }

    //preparec character for new life
    public void Reset(float livingTime)
    {
        lifeCountdown = livingTime;
        animator.Rebind();

        //find animator
        //find 
    }
}
