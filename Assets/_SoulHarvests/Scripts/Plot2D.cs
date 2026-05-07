using UnityEngine;

public class Plot2D : MonoBehaviour
{
    private enum PlotState
    {
        Empty,
        Planted,
        ReadyToHarvest
    }

    [Header("Growth Settings")]
    [SerializeField] private float growthTime = 5f;

    [Header("Harvest Settings")]
    [SerializeField] private int soulsPerHarvest = 1;

    [Header("Visual Colors")]
    [SerializeField] private Color emptyColor = new Color(0.45f, 0.18f, 0.05f);
    [SerializeField] private Color plantedColor = new Color(0.25f, 0.45f, 0.15f);
    [SerializeField] private Color readyColor = new Color(0.1f, 0.8f, 0.7f);

    private PlotState currentState = PlotState.Empty;
    private SpriteRenderer spriteRenderer;
    private float growthTimer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    private void Update()
    {
        if (currentState != PlotState.Planted)
        {
            return;
        }

        growthTimer += Time.deltaTime;

        if (growthTimer >= growthTime)
        {
            currentState = PlotState.ReadyToHarvest;
            UpdateVisual();
            Debug.Log($"{gameObject.name}: alma lista para cosechar");
        }
    }

    public void InteractWithPlot(PlayerInventory2D inventory)
    {
        if (currentState == PlotState.Empty)
        {
            PlantSoul();
        }
        else if (currentState == PlotState.ReadyToHarvest)
        {
            HarvestSoul(inventory);
        }
        else
        {
            Debug.Log($"{gameObject.name}: el alma todavía está creciendo");
        }
    }

    private void PlantSoul()
    {
        currentState = PlotState.Planted;
        growthTimer = 0f;
        UpdateVisual();
        Debug.Log($"{gameObject.name}: alma plantada");
    }

    private void HarvestSoul(PlayerInventory2D inventory)
    {
        if (inventory != null)
        {
            inventory.AddSoul(soulsPerHarvest);
        }

        currentState = PlotState.Empty;
        growthTimer = 0f;
        UpdateVisual();
        Debug.Log($"{gameObject.name}: alma cosechada");
    }

    private void UpdateVisual()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        switch (currentState)
        {
            case PlotState.Empty:
                spriteRenderer.color = emptyColor;
                break;
            case PlotState.Planted:
                spriteRenderer.color = plantedColor;
                break;
            case PlotState.ReadyToHarvest:
                spriteRenderer.color = readyColor;
                break;
        }
    }
}