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
    public Tilemap tilemap; // ������ �� Tilemap
    public Tile plowedTile; // ���� ��� ���������� �����
    public Tile wateredTile; // ���� ��� �������� �����
    public Tile plantedTile; // ���� ��� ����������� ��������

    private CellState[,] cellStates; // ������ ��������� ������

    private void Start()
    {
        int width = tilemap.size.x;
        int height = tilemap.size.y;
        cellStates = new CellState[width, height];
    }

    private void Update()
    {
        // �������� ������� ���� ��� �������������� � ��������
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
            return; // �����, ���� ������ ��� ������
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
                // ����� ����� �������� ������ ��� �������������� � ���������
                break;
        }
    }

    private void PlowCell(Vector3Int cellPosition)
    {
        cellStates[cellPosition.x, cellPosition.y] = CellState.Plowed;
        tilemap.SetTile(cellPosition, plowedTile); // ������������� ���� ��� ���������� �����
        Debug.Log("������ ��������.");
    }

    private void WaterCell(Vector3Int cellPosition)
    {
        cellStates[cellPosition.x, cellPosition.y] = CellState.Watered;
        tilemap.SetTile(cellPosition, wateredTile); // ������������� ���� ��� �������� �����
        Debug.Log("������ ������.");
    }

    private void PlantCell(Vector3Int cellPosition)
    {
        cellStates[cellPosition.x, cellPosition.y] = CellState.Planted;
        tilemap.SetTile(cellPosition, plantedTile); // ������������� ���� ��� ����������� ��������
        Debug.Log("������ ��������.");
    }
}
