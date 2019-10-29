using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver_direct : MonoBehaviour
{

    public GameObject Aim_Crosshair = null;
    enum State
    {
        Idle,
        Aiming,
        Reloading
    };

    State state = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 lastMousePos;
    float countdown = 0.0f;
    bool ButtonDown()
    {
        return Input.GetMouseButtonDown(0);
    }
    bool ButtonUp()
    {
        return Input.GetMouseButtonUp(0);
    }
    bool Inputpos(out Vector2 pos)
    {
        if(Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        { 
            pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            return true;
        }
        pos = Vector2.left;
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        if(state == State.Idle)
        {
            //Wait for touch
            if (ButtonDown())
            {
                lastMousePos = Input.mousePosition;
                state = State.Aiming;
            }

        }
        else if(state == State.Aiming)
        {

            //
            //Aim_Crosshair.
            RectTransform trr = Aim_Crosshair.transform.parent.GetComponent<RectTransform>();
            Vector2 localPoint;

            Vector2 pos;
            bool hasPos = Inputpos(out pos);
            Debug.Assert(hasPos);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(trr, pos, Camera.main, out localPoint);
            RectTransform rePos = Aim_Crosshair.GetComponent<RectTransform>();
            rePos.anchoredPosition = pos;

            //update crosshair distance
            {
                //Fire
                RectTransform[] transforms = Aim_Crosshair.GetComponentsInChildren<RectTransform>();

                foreach (RectTransform tr in transforms)
                {
                    if (tr.name.Equals("Crosshair"))
                    {
                        tr.anchoredPosition = new Vector2(0, 140 + 1400 * pos.y / 2000);

                    }
                }

            }


            if (ButtonUp())
            {

                //Fire
                RectTransform[] transforms = Aim_Crosshair.GetComponentsInChildren<RectTransform>();

                foreach (RectTransform tr in transforms)
                {
                    if(tr.name.Equals("Crosshair"))
                    {
                        Vector3 worldPoint = tr.TransformPoint(new Vector3(tr.pivot.x, tr.pivot.y,0.0f));

                        FloatingTargets targets = GetComponentInParent<FloatingTargets>();
                        targets.TryHit(worldPoint);

                    }
                }

                //Switch state
                state = State.Reloading;
                countdown = 1.0f;
                Aim_Crosshair.SetActive(false);

                rePos.anchoredPosition = new Vector2(0, 0);

                //Do the effect?


            }
        }
        else if(state == State.Reloading)
        {
            //quick reset
            countdown = 0.0f;

            countdown -= Time.deltaTime;
            if(countdown < 0.0f)
            {
                state = State.Idle;
                Aim_Crosshair.SetActive(true);

            }
        }
    }
}
