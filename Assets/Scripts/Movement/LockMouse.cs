using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{
    [SerializeField] bool isLocked=false;
    void Start()
    {
        if (!isLocked)
        {
            DataStore.Instance.LockMouse();
            isLocked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
