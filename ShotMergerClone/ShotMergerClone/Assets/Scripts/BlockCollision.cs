using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Collected" || collider.gameObject.tag == "CollectedTwoBox" || collider.gameObject.tag == "CollectedThreeBox")
        {
            ParentGun.instance.RemoveCollectivesFromGame(collider.gameObject);
            ParentGun.instance.RemoveCollectivesFromGunList(collider.gameObject);
        }
    }
}
