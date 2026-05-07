using UnityEngine;

public class Interactable2D : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private string interactionMessage = "Interactuando...";

    public void Interact()
    {
        Debug.Log(interactionMessage);
    }
}