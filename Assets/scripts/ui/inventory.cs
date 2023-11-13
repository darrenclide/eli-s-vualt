/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    const float tileSizeWidth =100f;
    const float tileSizeHeight =100f;
    InventoryItem[,] inventoryItemSlot;
    RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Init(20,10);
    }
    Vector2 positionOnTheGrid = new Vector2();
    Vector2Int tileGridPosition = new Vector2Int();
    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        positionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        positionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        tileGridPosition.x =(int)(positionOnTheGrid.x / tileSizeWidth);
        tileGridPosition.y =(int)(positionOnTheGrid.y / tileSizeHeight);
        return tileGridPosition;
    }
}
*/