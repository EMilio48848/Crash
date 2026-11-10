using System;
using UnityEngine;

public class MapPlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Animator characterAnimator;
    private MapLevel levelToMove;
    private MapLevel currentLevel;
    public MapLevel CurrentLevel {
        get => currentLevel;
        set
        {
            currentLevel = value;
            transform.position = value.transform.position;
            characterAnimator.Play("idle");
            canWalk = true;
            transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
        }
}

private bool canWalk = true;
public bool CanWalk => canWalk;
public void Initialize(MapLevel startingLevel)
{
    currentLevel = startingLevel;
}

private void MoveToLevel(MapLevel newLevel)
    {
        levelToMove = newLevel;
        canWalk = false;
        characterAnimator.Play("Walk");
    }

private void Update()
{
        if(levelToMove != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, levelToMove.transform.position, Time.deltaTime * moveSpeed);
            transform.LookAt(levelToMove.transform.position);
            if(Vector3.Distance(transform.position, levelToMove.transform.position) < 0.1f)
            {
                CurrentLevel = levelToMove;
                levelToMove = null;
            }
        }
}
}
