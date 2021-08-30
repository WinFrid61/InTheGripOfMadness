using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float timeOffset;
    [SerializeField]
    Vector2 posOffset;

    int obj;

    private Vector3 velocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;


        //transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

    }
}
