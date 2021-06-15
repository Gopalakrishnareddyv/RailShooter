using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCollison : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
        //print("Particle collison" +gameObject.name);
    }
}
