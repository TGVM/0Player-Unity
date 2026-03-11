using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.GlobalIllumination;

public class LightSystem : MonoBehaviour
{
     public static LightSystem Instance;
    [SerializeField] private List<LightController> nodes = new List<LightController>();

    void Awake()
    {
        Instance = this;
    }

    public void Recalculate()
    {
        foreach (var node in nodes)
        {
            node.SetPowered(false);
        }
        Queue<LightController> queue = new Queue<LightController>();

        foreach (var node in nodes)
        {
            if (node.IsSource())
            {
                node.SetPowered(true);
                queue.Enqueue(node);
            }
        }

        while (queue.Count > 0)
        {
            LightController current = queue.Dequeue();

            foreach (var next in current.Connections())
            {
                if (!next.IsPowered())
                {
                    next.SetPowered(true);
                    queue.Enqueue(next);
                }
            }
        }
    }
}