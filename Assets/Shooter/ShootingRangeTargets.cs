using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeTargets : MonoBehaviour
{
    
    float countdown = 0.0f;
    public GameObject hiteffect = null;

    List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Object b = Resources.Load("enemy");

        for(int i=0; i<3; i++)
        { 
            GameObject bO = (GameObject)Object.Instantiate(b);
            enemies.Add(bO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown < 0)
        {
            //move characters around

            for (int i = 0; i < enemies.Count; i++)
            {
                Vector3 pos = new Vector3(Random.value * 4 - 2, 0.0f, Random.value * 4 - 2);
                GameObject go = enemies[i];
                EnemyCharacter ec = go.GetComponentInChildren<EnemyCharacter>();

                ec.Reset(4.0f);
                go.transform.position = pos;

                countdown = 6.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryHit(Input.mousePosition);

        }
    }

    public void TryHit(Vector3 screenpos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(screenpos);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            
            if (objectHit.parent != null)
            {
                EnemyBodypart bp = objectHit.parent.GetComponentInChildren<EnemyBodypart>();
                if (bp != null)
                {
                    if (bp.Hit())
                    {
                    }
                }

            }
            // Do something with the object that was hit by the raycast.
            if (hiteffect != null)
            {
                HitEffect he = hiteffect.GetComponent<HitEffect>();
                he.Place(hit.point);
            }
        }

    }
}
