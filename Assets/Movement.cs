using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 10f;

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        Debug.Log(Input.GetAxis("Horizontal"));

        Vector3 sideX = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, 0f);
        Vector3 sideY = new Vector3(0f, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f);

        transform.position = transform.position + sideX;
        transform.position = transform.position + sideY;


    }
}
