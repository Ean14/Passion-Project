using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Mouse Look
    public static float speedH = 0.5f;
    public static float speedV = 0.5f;
    public float yaw = 0.0f;
    public float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor .lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook();
        hold();
    }

    private void mouseLook()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    public void shoot()
    {

    }

    public void hold()
    {
        while (Input.GetMouseButton(1))
        {

        }
    }
}
