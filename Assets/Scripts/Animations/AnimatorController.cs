using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Update()
    {
        Animations();
    }

    void Animations()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isRunning", false);
        }
    }
}
