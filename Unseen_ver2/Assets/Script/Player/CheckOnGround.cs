using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnGround
{
    const float distanceToGround = 0.1f;

    public bool isGround { get; private set; }

    public void CheckisGrounded(GameObject obj)
    {
        isGround = false;

        RaycastHit hit;
        CapsuleCollider capsuleCollider = obj.GetComponent<CapsuleCollider>();

        bool hitDetect = Physics.BoxCast(capsuleCollider.bounds.center, obj.transform.localScale / 2,
            Vector3.down, out hit, obj.transform.rotation, distanceToGround);

        if (hitDetect && hit.transform.tag == "Floor")
            isGround = true;


        //Ray[] ray = new Ray[20];
        //for (int i = 0; i < 20; i++)
        //{
        //    ray[i] = new Ray(obj.transform.position - new Vector3(0.10f, 0, 0) + new Vector3(0.012f * i, 0, 0), Vector3.down);
        //}

        //for (int i = 0; i < 20; i++)
        //{
        //    if (Physics.Raycast(ray[i], out hit, distanceToGround))
        //    {
        //        if (hit.transform.tag == "Floor" || hit.transform.tag == "MovingFloor" || hit.transform.tag == "TrapFloor")
        //        {
        //            isGround = true;
        //            break;
        //        }
        //    }
        //    else
        //        continue;
        //}

    }
}
