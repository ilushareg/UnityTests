using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    float lifeCountdown = 0.0f;
    float shootCountdown = 0.0f;
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
        if (shootCountdown > 0)
        {
            shootCountdown -= Time.deltaTime;
            if (shootCountdown <= 0.0f)
            {
                animator.SetBool("Shoot", true);
            }
        }

        if (lifeCountdown > 0)
        {
            lifeCountdown -= Time.deltaTime;
            if (lifeCountdown <= 0.0f)
            {
                //start death
                animator.SetBool("Dissapear", true);
            }
        }
    }


    public void Hit(string partname)
    {
        //Debug.Log("hit");
        animator.SetBool("Die", true);
    }

    //preparec character for new life
    public void Reset(float livingTime)
    {
        lifeCountdown = livingTime;
        shootCountdown = lifeCountdown - 2.0f;

        animator.Rebind();

        //find animator
        //find 
    }

    void Fire()
    {
        Debug.Log("Fire");
    }
}
