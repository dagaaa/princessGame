using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    private void LateUpdate()
    {
        var position = player.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}