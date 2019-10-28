using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    enum State
    {
        Idle,
        Busy,
        Lit,
        Hit
    };
    State state = State.Idle;

    // Start is called before the first frame update
    GameObject goUnlit = null;
    GameObject goLit = null;
    GameObject goHit = null;

    float countDown = 0.0f;

    void Start()
    {
       
        Transform[] transforms = transform.GetComponentsInChildren<Transform>();

        foreach(Transform t in transforms)
        {
            if("TargetUnlit".Equals(t.gameObject.name))
            {
                goUnlit = t.gameObject;
            }
            else if("TargetLit".Equals(t.gameObject.name))
            {
                goLit = t.gameObject;
            }
            else if("TargetHit".Equals(t.gameObject.name))
            {
                goHit = t.gameObject;
            }

        }

        Reset();

    }

    private void Reset()
    {

        SetIdle();

    }

    private void SetIdle()
    {
        goUnlit.SetActive(true);
        goLit.SetActive(false);
        goHit.SetActive(false);

    }

    private void SetBusy( float time )
    {
        countDown = time;

        goUnlit.SetActive(true);
        goLit.SetActive(false);
        goHit.SetActive(false);

    }

    public bool SetTargetable(float time)
    {
        state = State.Lit;
        countDown = time;
        goUnlit.SetActive(false);
        goLit.SetActive(true);
        goHit.SetActive(false);

        return true;
    }

    public bool SetHit()
    {
        state = State.Hit;
        countDown = 2.0f;
        goUnlit.SetActive(false);
        goLit.SetActive(false);
        goHit.SetActive(true);

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
        }

        if(state == State.Idle)
        {

        }
        else if (state == State.Busy)
        {
            if (countDown <= 0.0f)
            {
                SetIdle();
            }
        }
        else if (state == State.Lit)
        {
            if (countDown <= 0.0f)
            {
                SetBusy(1.0f);
            }
        }
        else if (state == State.Hit)
        {
            if (countDown <= 0.0f)
            {
                SetBusy(2.0f);
            }

        }

    }
}
