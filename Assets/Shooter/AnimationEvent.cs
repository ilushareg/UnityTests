using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // the function to be called as an event
    public void PrintEvent(int i)
    {
        print("PrintEvent: " + i + " called at: " + Time.time);
    }
}
