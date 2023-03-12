using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private void Update()
    {
        DataStore.Instance.ElapsedTime += Time.deltaTime;
        //Debug.Log("Time Elapsed: " + DataStore.Instance.ElapsedTime.ToString("F2"));
    }
}
