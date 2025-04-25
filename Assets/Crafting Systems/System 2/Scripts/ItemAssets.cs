using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite headSprite;
    public Sprite legSprite;
    public Sprite armSprite;
    public Sprite torsoSprite;
}
