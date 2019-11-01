using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodypart : MonoBehaviour
{
    public string partname = "body";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Hit()
    {
        //find parent EnemyCharacter monobeh and hit it
        Transform p = this.transform.parent;
        while(p)
        {
            EnemyCharacter character = p.GetComponent<EnemyCharacter>();
            character.Hit(partname);
            p = p.parent;
        }

        return true;
    }

}
