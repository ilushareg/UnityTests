using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTargets : MonoBehaviour
{
    // Start is called before the first frame update
    List<Brick> bricks = null;
    float countdown = 0.0f;

    public GameObject hiteffect = null;
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

            for (int i = 0; i < 3; i++)
            {
                int idx = (int)(Random.value * bricks.Count);
                bricks[idx].SetTargetable(4.0f);

                countdown = 6.0f;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            //TryHit(Input.mousePosition);

        }
    }

    public void TryHit(Vector3 screenpos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(screenpos);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Brick br = objectHit.parent.GetComponentInChildren<Brick>();
            if (br != null)
            {
                if (br.SetHit())
                {


                }
                //hit.transform.position
                if (hiteffect != null)
                {
                    HitEffect he = hiteffect.GetComponent<HitEffect>();
                    he.Place(hit.transform.position);
                }
            }
            // Do something with the object that was hit by the raycast.
        }

    }
}
