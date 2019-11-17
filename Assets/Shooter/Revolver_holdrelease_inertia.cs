using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver_holdrelease_inertia : MonoBehaviour
{

    public GameObject Aim_Crosshair = null;
    Vector3 aim_velocity;

    enum State
    {
        Idle,
        Aiming,
        Shooting,
        Reloading
    };

    State state = State.Idle;

    // Start is called before the first frame update
    void Start()
    {

    }

    Vector3 lastMousePos;
    float countdown = 0.0f;
    Vector3 deceleration;
    float time_to_stop = 0.0f;
    Vector3 startPos;

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
        if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
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
        if (state == State.Idle)
        {
            //Wait for touch
            if (ButtonDown())
            {
                lastMousePos = Input.mousePosition;
                countdown = 0.0f;
                state = State.Aiming;
            }

        }
        else if (state == State.Aiming)
        {

            //
            countdown += Time.deltaTime;


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
                        tr.anchoredPosition = new Vector2(0, 0);

                    }
                }

            }


            if (ButtonUp())
            {

                //let's consider this is length
                aim_velocity = (Input.mousePosition - lastMousePos) / countdown;
                float t = aim_velocity.magnitude / 500.0f/*friction*/;
                deceleration = -aim_velocity / t;
                startPos = rePos.anchoredPosition;

                time_to_stop = t;
                countdown = 0.0f;

                //Switch state
                state = State.Shooting;


            }
        }
        else if (state == State.Shooting)
        {
            countdown += Time.deltaTime;
            time_to_stop -= Time.deltaTime;
            if(time_to_stop <=0 || ButtonDown())
            {
                //Fire
                RectTransform[] transforms = Aim_Crosshair.GetComponentsInChildren<RectTransform>();

                foreach (RectTransform tr in transforms)
                {
                    if (tr.name.Equals("Crosshair"))
                    {
                        Vector3 worldPoint = tr.TransformPoint(new Vector3(tr.pivot.x, tr.pivot.y, 0.0f));

                        ShootingRangeTargets targets = GetComponentInParent<ShootingRangeTargets>();
                        targets.TryHit(worldPoint);

                    }
                }


                countdown = 0.0f;
                state = State.Reloading;

                RectTransform rePos = Aim_Crosshair.GetComponent<RectTransform>();

                rePos.anchoredPosition = new Vector2(0, 0);
                Aim_Crosshair.SetActive(false);
            }
            else
            {
                Vector3 pos = aim_velocity * countdown + deceleration * countdown * countdown / 2;

                RectTransform rePos = Aim_Crosshair.GetComponent<RectTransform>();
                rePos.anchoredPosition = startPos + pos;

            }




        }
        else if (state == State.Reloading)
        {
            //quick reset
            countdown = 0.0f;

            countdown -= Time.deltaTime;
            if (countdown < 0.0f)
            {
                state = State.Idle;
                Aim_Crosshair.SetActive(true);

            }
        }
    }
}
