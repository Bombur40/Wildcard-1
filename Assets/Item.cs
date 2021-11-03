using UnityEngine;

public enum Rarity {
    Common = 0,
    Uncommon = 1,
    Rare = 2
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {
    
    public new string name;
    public string description;
    public Sprite texture;
    public Rarity rarity;

}