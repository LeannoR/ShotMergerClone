using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collective : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Gun")
        {
            if(!ParentGun.instance.guns.Contains(collider.gameObject))
            {
                Debug.Log("Collision");
                collider.GetComponent<BoxCollider>().isTrigger = false;

                ParentGun.instance.StackCollective(collider.gameObject, ParentGun.instance.guns.Count - 1);
                ParentGun.instance.AddCollectivesToList(collider.gameObject);
            }
        }
    }
}
