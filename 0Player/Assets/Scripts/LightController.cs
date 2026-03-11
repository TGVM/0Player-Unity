using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightController : MonoBehaviour
{
    [SerializeField] private bool isSource;
    [SerializeField] private bool keepPowered;

    [SerializeField] private Color offColor = Color.black;
    [SerializeField] private Color onColor = Color.white;
    [SerializeField] private bool isPowered;
    private SpriteRenderer sr;

    [SerializeField] private List<LightController> connections = new List<LightController>();

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void AddConnection(LightController node)
    {
        if (!connections.Contains(node))
        {
            connections.Add(node);
            LightSystem.Instance.Recalculate();
        }
    }

    public void RemoveConnection(LightController node)
    {
        connections.Remove(node);
        LightSystem.Instance.Recalculate();
    }

    public void SetPowered(bool value)
    {
        if (keepPowered && isPowered) return;

        isPowered = value;
        sr.color = value ? onColor : offColor;
    }

    public bool IsPowered()
    {
        return isPowered;
    }

    public bool IsSource()
    {
        return isSource;
    }

    public List<LightController> Connections()
    {
        return connections;
    }
}
