using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{
    void Start()
    {
        DataStore.Instance.LockMouse();
    }
}
