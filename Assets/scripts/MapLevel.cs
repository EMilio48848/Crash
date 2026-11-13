using UnityEngine;

public class MapLevel : MonoBehaviour
{
    [SerializeField]
    private MapLevelData nextLevel;
    [SerializeField]
    private MapLevelData previousLevel;
    [SerializeField]
    private string levelName;
    public  string LevelName => levelName;
    public MapLevelData NextLevel => nextLevel;
    public MapLevelData PreviousLevel => previousLevel;
}
[System.Serializable]
public class MapLevelData
{
    public bool enabled;
    public MapLevel level;
    public MapDirection direction;
}

public enum MapDirection
{
    Up,
    Down,
    Left,
    Right
}
