using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    float lifeCountdown = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        //find animator
        //find 
    }
}
