using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentGun : MonoBehaviour
{
    public static ParentGun instance;
    public List<GameObject> guns = new List<GameObject>();
    public GameObject parentGun;
    public Transform transformParent;
    public float distance = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StackCollective(GameObject collider, int index)
    {
        collider.transform.parent = transform;
        Vector3 newPos = guns[index].transform.localPosition;
        newPos.z += distance;
        collider.transform.localPosition = newPos;
    }

    public void AddCollectivesToList(GameObject gameObject)
    {
        guns.Add(gameObject);
    }
}
