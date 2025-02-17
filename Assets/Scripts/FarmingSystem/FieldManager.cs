using UnityEngine;
using UnityEngine.Tilemaps;

public enum CellState
{
    Unplowed,
    Plowed,
    Watered,
    Planted
}

public class FieldManager : MonoBehaviour
{
    public Tilemap tilemap; // Ссылка на Tilemap
    public Tile plowedTile; // Тайл для вспаханной земли
    public Tile wateredTile; // Тайл для поливной земли
    public Tile plantedTile; // Тайл для посаженного растения

    private CellState[,] cellStates; // Массив состояний клеток

    private void Start()
    {
        int width = tilemap.size.x;
        int height = tilemap.size.y;
        cellStates = new CellState[width, height];
    }

    private void Update()
    {
        // Проверка нажатий мыши для взаимодействия с клетками
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);
            HandleCellInteraction(cellPosition);
        }
    }

    private void HandleCellInteraction(Vector3Int cellPosition)
    {
        if (cellPosition.x < 0 || cellPosition.y < 0 ||
            cellPosition.x >= cellStates.GetLength(0) ||
            cellPosition.y >= cellStates.GetLength(1))
        {
            return; // Выход, если клетка вне границ
        }

        switch (cellStates[cellPosition.x, cellPosition.y])
        {
            case CellState.Unplowed:
                PlowCell(cellPosition);
                break;
            case CellState.Plowed:
                WaterCell(cellPosition);
                break;
            case CellState.Watered:
                PlantCell(cellPosition);
                break;
            case CellState.Planted:
                // Здесь можно добавить логику для взаимодействия с растением
                break;
        }
    }

    private void PlowCell(Vector3Int cellPosition)
    {
        cellStates[cellPosition.x, cellPosition.y] = CellState.Plowed;
        tilemap.SetTile(cellPosition, plowedTile); // Устанавливаем тайл для вспаханной земли
        Debug.Log("Клетка вспахана.");
    }

    private void WaterCell(Vector3Int cellPosition)
    {
        cellStates[cellPosition.x, cellPosition.y] = CellState.Watered;
        tilemap.SetTile(cellPosition, wateredTile); // Устанавливаем тайл для поливной земли
        Debug.Log("Клетка полита.");
    }

    private void PlantCell(Vector3Int cellPosition)
    {
        cellStates[cellPosition.x, cellPosition.y] = CellState.Planted;
        tilemap.SetTile(cellPosition, plantedTile); // Устанавливаем тайл для посаженного растения
        Debug.Log("Семена посажены.");
    }
}
