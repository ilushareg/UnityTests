using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wship : MonoBehaviour
{

    static public Wship instance = null;
    FloatingJoystick stick = null;
    //Find the stick
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        stick = Object.FindObjectOfType<FloatingJoystick>();
        
    }

    float fSpeed = 0.0f;
    float fRot = 0.0f;

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x + 10 * Time.deltaTime;

        float leftright = -stick.Horizontal;
        float maxDrag = 10.0f;
        float maxSpeed = 9.0f;

        fSpeed += (leftright * maxSpeed - fSpeed) * Time.deltaTime;

        float z = transform.position.z + fSpeed * Time.deltaTime;

        fRot += (leftright * 85 - fRot) * Time.deltaTime;

        transform.position = new Vector3(x, transform.position.y, z);

        transform.rotation= Quaternion.AngleAxis(fRot, new Vector3(1, 0, 0));


    }

    public void OnReset()
    {
        instance.transform.position = new Vector3(0, 0, 0);
        instance.transform.rotation = Quaternion.identity;
    }
}
