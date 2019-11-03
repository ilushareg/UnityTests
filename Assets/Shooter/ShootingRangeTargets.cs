using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeTargets : MonoBehaviour
{
    
    float countdown = 0.0f;
    public GameObject hiteffect = null;

    List<GameObject> enemies = new List<GameObject>();
    SpawnPoint[] spawnPoints;
    //list of indexes which will be reshuffled to select random spawn points without interruption
    int[] spawnPointsOrder;

    // Start is called before the first frame update
    void Start()
    {
        int enemiesAtOnce = 3;


        Object b = Resources.Load("enemy");

        for(int i=0; i< enemiesAtOnce; i++)
        { 
            GameObject bO = (GameObject)Object.Instantiate(b);
            enemies.Add(bO);
        }

        //find all spawnpoints on the level
        spawnPoints = Object.FindObjectsOfType<SpawnPoint>();
        spawnPointsOrder = new int[spawnPoints.Length];
        for(int i=0; i<spawnPointsOrder.Length;i++)
        {
            spawnPointsOrder[i] = i;
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
            for (int i = 0; i < spawnPointsOrder.Length * 5; i++)
            {
                int idx1 = (int)(Random.value * spawnPointsOrder.Length);
                int idx2 = (int)(Random.value * spawnPointsOrder.Length);
                int tmp = spawnPointsOrder[idx1];
                spawnPointsOrder[idx1] = spawnPointsOrder[idx2];
                spawnPointsOrder[idx2] = tmp;
                //select spawnpoints
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                SpawnPoint p = spawnPoints[spawnPointsOrder[i]];

                Vector3 pos = p.transform.position;
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
