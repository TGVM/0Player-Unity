using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Connector : MonoBehaviour
{
    [SerializeField] private LightController node;

    void OnTriggerEnter2D(Collider2D other)
    {
        Connector otherConnector = other.GetComponent<Connector>();
        if (otherConnector != null)
        {
            node.AddConnection(otherConnector.node);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Connector otherConnector = other.GetComponent<Connector>();
        if (otherConnector != null)
        {
            node.RemoveConnection(otherConnector.node);
        }
    }
}