using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTargets : MonoBehaviour
{
    // Start is called before the first frame update
    List<Brick> bricks = null;
    float countdown = 0.0f;

    void Start()
    {
        Object b = Resources.Load("Brick");
        bricks = new List<Brick>();

        for (int i=0; i<7; i++)
        {
            for(int q=0; q<10; q++)
            {
                Vector3 pos = new Vector3(i, q, 0);

                GameObject bO = (GameObject)Object.Instantiate(b);
                bO.transform.position = pos;
                bO.transform.parent = this.transform;
                bricks.Add(bO.GetComponent<Brick>());
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(countdown>0)
        {
            countdown -= Time.deltaTime;
        }

        if(countdown <=0)
        {

            int idx = (int)(Random.value * bricks.Count);
            bricks[idx].SetTargetable(3.0f);

            countdown = 4.0f; 
        }
        
    }
}
