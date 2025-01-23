using UnityEngine;

public class LightList
{
    private LightNode head;
    private LightNode current;

    public void Add(Vector3 rotation)
    {
        LightNode newNode = new LightNode(rotation);
        if (head == null)
        {
            head = newNode;
            current = head;
        }
        else
        {
            LightNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
        }
    }

    public Vector3 NextNode()
    {
        if (current == null) return Vector3.zero;

        Vector3 rotation = current.rotation;
        current = current.next ?? head;
        return rotation;
    }

    public void RemovefirstNode()
    {
        if (head == null) return;

        head = head.next;
        if (current == head) current = head;
    }

}
