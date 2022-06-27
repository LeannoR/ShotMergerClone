using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collective : MonoBehaviour
{
    public static int currentShootPerSec = 1;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "CollectTwoBox"|| collider.gameObject.tag == "Collect" || collider.gameObject.tag == "CollectThreeBox" || collider.gameObject.tag == "Gun")
        {
            if (!ParentGun.instance.guns.Contains(collider.gameObject))
            {
                if(collider.gameObject.tag == "CollectTwoBox")
                {
                    collider.gameObject.tag = "CollectedTwoBox";
                    ParentGun.instance.StackCollectiveToGun(collider.gameObject, ParentGun.instance.guns.Count - 1);
                    ParentGun.instance.AddCollectivesToGunList(collider.gameObject);
                    ParentGun.instance.SetShootPerSec(ShootPerSecTwoBox());
                }
                else if (collider.gameObject.tag == "Collect")
                {
                    collider.gameObject.tag = "Collected";
                    ParentGun.instance.StackCollectiveToGun(collider.gameObject, ParentGun.instance.guns.Count - 1);
                    ParentGun.instance.AddCollectivesToGunList(collider.gameObject);
                    ParentGun.instance.SetShootPerSec(ShootPerSec());
                }
                else if (collider.gameObject.tag == "CollectThreeBox")
                {
                    collider.gameObject.tag = "CollectedThreeBox";
                    ParentGun.instance.StackCollectiveToGun(collider.gameObject, ParentGun.instance.guns.Count - 1);
                    ParentGun.instance.AddCollectivesToGunList(collider.gameObject);
                    ParentGun.instance.SetShootPerSec(ShootPerSecThreeBox());
                }
            }
        }
        else if (collider.gameObject.tag == "Barrel")
        {
            ParentGun.instance.RemoveCollectivesFromGame(gameObject);
            ParentGun.instance.RemoveCollectivesFromGunList(gameObject);
        }
    }

    public int ShootPerSecTwoBox()
    {
        currentShootPerSec = ParentGun.instance.GetShootPerSec();
        currentShootPerSec *= 2;
        return currentShootPerSec;
    }
    public int ShootPerSec()
    {
        currentShootPerSec = ParentGun.instance.GetShootPerSec();
        currentShootPerSec += 1;
        return currentShootPerSec;
    }

    public int ShootPerSecThreeBox()
    {
        currentShootPerSec = ParentGun.instance.GetShootPerSec();
        currentShootPerSec += 3;
        return currentShootPerSec;
    }

}
