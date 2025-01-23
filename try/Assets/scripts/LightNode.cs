using UnityEngine;

public class LightNode
{
    public Vector3 rotation;
    public LightNode next;

    public LightNode(Vector3 rotation)
    {
        this.rotation = rotation;
        next = null;
    }
}
