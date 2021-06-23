using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellyCube : MonoBehaviour
{
    public GameObject cube;


    void Start()
    {
    }

    public void agrandarC()
    {
        cube.transform.localScale = new Vector3(3, 3, 3);
    }

    public void achicarC()
    {
        cube.transform.localScale = new Vector3(.5f, .5f, .5f);
    }


}

