using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emitter_pusher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        Vector3 dir = other.transform.position - transform.position;
        dir.z = 0.0f;
        dir.Normalize();
        
        other.transform.GetComponent<Rigidbody2D>().AddForce(dir*1000*Time.deltaTime);
        //Debug.Log("collision");
    }
}
