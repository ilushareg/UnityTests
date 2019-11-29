using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object o = Resources.Load("Obstacle");
        for(int i=0; i< 100; i++)
        {
            int pos = (int)(Random.value * 10.0f);
            if(pos < 5)
            { 
                GameObject oo = (GameObject)Object.Instantiate(o, this.transform);
                oo.transform.position = new Vector3(i, 0, pos-2);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
