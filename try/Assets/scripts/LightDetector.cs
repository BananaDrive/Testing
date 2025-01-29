using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetector : MonoBehaviour
{
    private Light[] lightSources;
    public float brightnessThreshold = 1f; 
    private float totalBrightness = 0f;

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
            else if (lightSource.type == LightType.Point || lightSource.type == LightType.Spot)
            {
                HandlePointOrSpotLight(lightSource);
            }
        }

        Debug.Log("Total Brightness: " + totalBrightness);

        if (totalBrightness > brightnessThreshold)
        {
            Debug.Log("TOO BRIGHT!");
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

    void HandlePointOrSpotLight(Light lightSource)
    {
        Vector3 lightDirection = (lightSource.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(lightSource.transform.position, transform.position);

       
        if (!Physics.Raycast(lightSource.transform.position, -lightDirection, distance))
        {
            float intensity = lightSource.intensity / (distance * distance); 

            
            if (lightSource.type == LightType.Spot)
            {
                float angleToPlayer = Vector3.Angle(lightSource.transform.forward, -lightDirection);

                if (angleToPlayer < lightSource.spotAngle / 2)
                {
                    totalBrightness += intensity;
                }
            }
            else
            {
                
                totalBrightness += intensity;
            }
        }
    }
}
