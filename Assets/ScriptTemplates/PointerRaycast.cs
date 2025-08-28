using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem; // Use new Input System

public class VRVideoRaycastInteraction : MonoBehaviour
{
    public float interactionDistance = 5f;
    public VideoPlayer[] videoPlayers; // Array to hold all video players
    public TextMeshProUGUI interactionText;  // Assign from UI Canvas
    public XRRayInteractor leftHandRay;  // Assign the left hand XR Ray Interactor
    public XRRayInteractor rightHandRay; // Assign the right hand XR Ray Interactor
    public InputActionReference triggerAction; // Assign the trigger action in the inspector

    private XRRayInteractor activeRay; // Stores the current active ray

    void Update()
    {
        activeRay = GetActiveRayInteractor();

        if (activeRay != null && activeRay.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.transform.CompareTag("VideoButton"))
            {
                ShowInteractionText();

                if (triggerAction.action.WasPressedThisFrame()) // Check if trigger was pressed
                {
                    TogglePlayPause();
                }
                return;
            }
        }

        HideInteractionText();
    }

    void TogglePlayPause()
    {
        bool isPlaying = videoPlayers[0].isPlaying; // Check first video player's state

        foreach (VideoPlayer player in videoPlayers)
        {
            if (isPlaying)
                player.Pause();
            else
                player.Play();
        }
    }

    void ShowInteractionText()
    {
        interactionText.text = videoPlayers[0].isPlaying ? "Pause" : "Play";
        interactionText.enabled = true;
    }

    void HideInteractionText()
    {
        interactionText.enabled = false;
    }

    private XRRayInteractor GetActiveRayInteractor()
    {
        if (rightHandRay != null && rightHandRay.isActiveAndEnabled)
            return rightHandRay;
        if (leftHandRay != null && leftHandRay.isActiveAndEnabled)
            return leftHandRay;
        return null;
    }
}
