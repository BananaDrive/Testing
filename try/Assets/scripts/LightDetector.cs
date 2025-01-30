using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightDetector : MonoBehaviour
{
    private Light[] lightSources;
    public float brightnessThreshold = 1f; 
    private float totalBrightness = 0f;
    public bool Burning = false;
    public TextMeshProUGUI BrightnessLevel;

    private void Start()
    {
       
        lightSources = FindObjectsOfType<Light>();
    }

    private void Update()
    {
        totalBrightness = 0f; 

        foreach (Light lightSource in lightSources)
        {
            if (lightSource.type == LightType.Directional)
            {
                HandleDirectionalLight(lightSource);
            }
        }

        Debug.Log("Total Brightness: " + totalBrightness);
        BrightnessLevel.text = "Brightness: " + totalBrightness;

        if (totalBrightness > brightnessThreshold)
        {
            Debug.Log("TOO BRIGHT!");
            Burning = true;
        }
    }

    void HandleDirectionalLight(Light directionalLight)
    {
        Vector3 lightDirection = -directionalLight.transform.forward;

        if (!Physics.Raycast(transform.position, lightDirection, out RaycastHit hit))
        {
            
            totalBrightness += directionalLight.intensity;
        }
    }

   
}
