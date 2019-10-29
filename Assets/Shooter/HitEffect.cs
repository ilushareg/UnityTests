using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        countdown = effectduration;

    }

    static float effectduration = 0.5f;
    float countdown = effectduration;
    private void Awake()
    {
    }

    public void Place(Vector3 pos)
    {
        this.gameObject.SetActive(true);
        this.transform.position = pos;
        countdown = effectduration;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown > 0.0f)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                countdown = 0.0f;
                float alpha = countdown / effectduration;



                this.gameObject.SetActive(false);
            }
        }
        
    }
}
