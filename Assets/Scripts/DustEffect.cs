using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DestroyObjectDelayed();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 1 seconds after loading the object
        Destroy(gameObject, 1.5f);
    }
}
