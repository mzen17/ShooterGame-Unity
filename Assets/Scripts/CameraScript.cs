using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform FollowMain;
    // Update is called once per frame
    void Update()
    {
        Vector3 MainPos = FollowMain.position;
        MainPos.z = -10f;
        
        transform.position = MainPos;
    }
}
