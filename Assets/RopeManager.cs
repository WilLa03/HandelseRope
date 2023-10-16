using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckIfDestroy(GameObject target)
    {
        if (target == gameObject)
        {
            Destroy(gameObject);
            RemoveEarlierChains();
        }
    }

    public void RemoveEarlierChains()
    {
        int childCount = gameObject.transform.parent.gameObject.GetComponentsInChildren<HingeJoint2D>().Length-1;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(gameObject.transform.parent.gameObject.transform.GetChild(i).gameObject, 0.5f);
        }
    }
    
}
