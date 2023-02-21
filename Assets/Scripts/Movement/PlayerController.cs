using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCam;

    [SerializeField] float mouseSens=3.5f;

    [SerializeField] float speed = 6;

    [SerializeField] float moveSmoothTime=0.3f;
    [SerializeField] float mouseSmoothTime = 0.3f;

    float camPitch = 0;

    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta=Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouse();
        UpdateMovement();
    }

    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);


        camPitch -= currentMouseDelta.y*mouseSens;
        camPitch = Mathf.Clamp(camPitch, -90, 90);
        playerCam.localEulerAngles = Vector3.right * camPitch;
        transform.Rotate(Vector3.up, currentMouseDelta.x*mouseSens);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x)*speed;

        controller.Move(velocity * Time.deltaTime);
    }
}
