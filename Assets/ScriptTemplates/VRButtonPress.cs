using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRButtonPress : MonoBehaviour
{
    public Transform propToMove; // Assign the prop in Inspector
    public float moveAmount = 10.0f; // How much the prop moves
    public float moveSpeed = 2.0f; // Speed of movement

    private Vector3 startPropPos;
    private Vector3 targetPropPos;
    private bool moving = false;
    private bool movedUp = false;

    void Start()
    {
        if (propToMove != null)
        {
            startPropPos = propToMove.position;
            targetPropPos = startPropPos + new Vector3(0, moveAmount, 0);
        }
    }

    public void OnButtonPress(XRBaseInteractor interactor)
    {
        if (!moving && propToMove != null)
        {
            moving = true;
            StartCoroutine(MoveProp());
        }
    }

    private System.Collections.IEnumerator MoveProp()
    {
        Vector3 destination = movedUp ? startPropPos : targetPropPos;
        while (Vector3.Distance(propToMove.position, destination) > 0.01f)
        {
            propToMove.position = Vector3.MoveTowards(propToMove.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }

        movedUp = !movedUp;
        moving = false;
    }
}