using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a")) {
            transform.Rotate(0,0,10 * Time.deltaTime * 10);
        }

        if(Input.GetKey("b"))
            transform.position += transform.right * Time.deltaTime;

            Debug.Log(transform.right);
    }
}
