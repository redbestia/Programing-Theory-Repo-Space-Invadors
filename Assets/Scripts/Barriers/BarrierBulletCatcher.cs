using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBulletCatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<RocketBechviour>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}
