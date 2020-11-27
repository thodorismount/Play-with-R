using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    Camera cam;
    Transform my;
    Rigidbody2D body;
    
    void Awake()
    {
        cam = Camera.main;
        my = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float camDis = cam.transform.position.y - my.position.y;
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis*2.8f));

        float AngleRad = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        body.rotation = angle-90;
    }
}