using UnityEngine;
using UnityEngine.Events;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private MapPlayerController mapPlayerController;
    [SerializeField]
    private  UnityEvent<string> onLevelChosen;
    [SerializeField]
    private UnityEvent onMapStart;

    private void Start()
    {
        onMapStart?.Invoke();
    }
    public void MovePLayer(MapDirection direction)
    {
        if(mapPlayerController.CurrentLevel == null || !mapPlayerController.CanWalk)return;
        CheckLevel(mapPlayerController.CurrentLevel.NextLevel, direction);
        CheckLevel(mapPlayerController.CurrentLevel.PreviousLevel, direction);
    }

    private void CheckLevel(MapLevelData level, MapDirection direction)
    {
        if(level == null) return;
        if(level.direction == direction)
        {
            mapPlayerController.MoveToLevel(level.level);
        }
    }

    public void ChooseLevel()
    {
        if(mapPlayerController.CurrentLevel != null)
        {
            onLevelChosen?.Invoke(mapPlayerController.CurrentLevel.LevelName);
        }
    }

}