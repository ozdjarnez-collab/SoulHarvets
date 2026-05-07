using UnityEngine;

public class PlayerInteraction2D : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private Interactable2D currentInteractable;
    private Plot2D currentPlot;
    private PlayerInventory2D inventory;

    private void Awake()
    {
        inventory = GetComponent<PlayerInventory2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (currentPlot != null)
            {
                currentPlot.InteractWithPlot(inventory);
                return;
            }

            if (currentInteractable != null)
            {
                currentInteractable.Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Plot2D plot = other.GetComponent<Plot2D>();
        if (plot != null)
        {
            currentPlot = plot;
            Debug.Log("Presiona E para usar la parcela");
            return;
        }

        Interactable2D interactable = other.GetComponent<Interactable2D>();
        if (interactable != null)
        {
            currentInteractable = interactable;
            Debug.Log("Presiona E para interactuar");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Plot2D plot = other.GetComponent<Plot2D>();
        if (plot != null && plot == currentPlot)
        {
            currentPlot = null;
            Debug.Log("Saliste de la parcela");
            return;
        }

        Interactable2D interactable = other.GetComponent<Interactable2D>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            Debug.Log("Saliste del área de interacción");
        }
    }
}