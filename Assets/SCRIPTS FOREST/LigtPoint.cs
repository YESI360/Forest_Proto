using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class LigtPoint : MonoBehaviour
{
    Light myLight;
    public float range;
    public float intensity;
    public int MaxIntensity;
    public int MinIntensity;
    public float speed;

    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.intensity = 0;
    }

    public void LightOn()
    {
        myLight.range += range * 2 * Time.deltaTime;//IMPORTA MAS RANGE
        myLight.intensity = Mathf.Lerp(myLight.intensity, MaxIntensity,Time.deltaTime * speed);
    }
    public void LightOff()
    {
        myLight.range = myLight.range - (range / 4) * Time.deltaTime;//IMPORTA MAS RANGE
        myLight.intensity = Mathf.Lerp(myLight.intensity,MinIntensity, Time.deltaTime * speed);
    }
}
