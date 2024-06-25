using UnityEngine;
using UnityEngine.UI;

public class TowerPlacer : MonoBehaviour
{
    public GameObject[] towerPrefabs; 
    public int maxTowers = 5; 
    private int currentTowerCount = 0; 
    private int selectedTowerIndex = 0; 
    private Camera mainCamera;
    public Text selectedTowerText; 

    void Start()
    {
        mainCamera = Camera.main;
        UpdateSelectedTowerText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentTowerCount < maxTowers)
        {
            PlaceTower();
        }
    }

    public void SelectTower(int index)
    {
        selectedTowerIndex = index;
        UpdateSelectedTowerText();
    }

    void UpdateSelectedTowerText()
    {
        selectedTowerText.text = "Selected Tower: " + towerPrefabs[selectedTowerIndex].name;
    }

    void PlaceTower()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10.0f; 
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        Instantiate(towerPrefabs[selectedTowerIndex], worldPosition, Quaternion.identity);
        currentTowerCount++;
    }
}
