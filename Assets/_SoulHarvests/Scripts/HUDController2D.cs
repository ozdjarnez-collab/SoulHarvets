using TMPro;
using UnityEngine;

public class HUDController2D : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInventory2D playerInventory;
    [SerializeField] private TMP_Text soulsText;

    private void Update()
    {
        if (playerInventory == null || soulsText == null)
        {
            return;
        }

        soulsText.text = $"Almas: {playerInventory.HarvestedSouls}";
    }
}