using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Barrel : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textElement;

    public int hitPoint = 10;

    public void Update()
    {
        DestroyBarrel();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            hitPoint -= 1;
            SetBarrelHealth();
            Destroy(collider.gameObject);
        }
    }

    public void DestroyBarrel()
    {
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetBarrelHealth()
    {
        textElement.text = hitPoint.ToString(); 
    }

}
