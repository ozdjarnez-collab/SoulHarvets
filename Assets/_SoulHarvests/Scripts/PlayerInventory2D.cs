using UnityEngine;

public class PlayerInventory2D : MonoBehaviour
{
    [Header("Soul Inventory")]
    [SerializeField] private int harvestedSouls;

    public int HarvestedSouls => harvestedSouls;

    public void AddSoul(int amount)
    {
        harvestedSouls += amount;
        Debug.Log($"Almas cosechadas: {harvestedSouls}");
    }
}