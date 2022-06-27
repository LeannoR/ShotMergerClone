using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParentGun : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textElement;
    public static ParentGun instance;
    public List<GameObject> guns = new List<GameObject>();
    public GameObject parentGun;
    public Transform transformParent;
    public float distance = 1f;
    public float threeBoxCenter = 0.75f;
    public static int shootPerSec = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Update()
    {
        ShowShootPerSec();
    }
    public void StackCollectiveToGun(GameObject collider, int index)
    {
        collider.transform.parent = transform;
        Vector3 newPos = guns[index].transform.localPosition;
        if (collider.gameObject.tag == "CollectedThreeBox")
        {
            Transform transformChild = collider.gameObject.GetComponent<Transform>();
            newPos.z = transformChild.localPosition.z - threeBoxCenter;
        }
        else
        {
            newPos.z += distance;
        }
        collider.transform.localPosition = newPos;
    }

    public void AddCollectivesToGunList(GameObject gameObject)
    {
        guns.Add(gameObject);
    }

    public void RemoveCollectivesFromGunList(GameObject gameObject)
    {
        guns.Remove(gameObject);
    }
    
    public void RemoveCollectivesFromGame(GameObject gameObject)
    {
        if (gameObject.tag == "Collected")
        {
            SetShootPerSec(GetShootPerSec() - 1);
        }
        else if (gameObject.tag == "CollectedTwoBox")
        {
            SetShootPerSec(GetShootPerSec() / 2);
        }
        else if (gameObject.tag == "CollectedThreeBox")
        {
            SetShootPerSec(GetShootPerSec() - 3);
        }
        Destroy(gameObject);
    }
    public void ShowShootPerSec()
    {
        textElement.text = shootPerSec.ToString();
    }

    public int SetShootPerSec(int collectiveBullet)
    {
        shootPerSec = collectiveBullet;
        return shootPerSec;
    }

    public int GetShootPerSec()
    {
        return shootPerSec;
    }
}
