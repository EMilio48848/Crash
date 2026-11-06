using UnityEngine;

public class AvatarController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] avatars;

    public void SetActiveAvatar(int index)
    {
        for(int i= 0; i < avatars.Length; i++)
        {
            avatars[i].SetActive(i == index);
        }
    }
}
