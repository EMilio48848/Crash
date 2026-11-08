using UnityEngine;

public class AvatarController : MonoBehaviour
{
    [SerializeField]
    private AvatarData[] avatars;

    public void SetActiveAvatar(int numberOfLives)
    {
        for(int i= 0; i < avatars.Length; i++)
        {
            AvatarData avatarData = avatars[i];
            avatarData.avatar.SetActive(avatarData.numberOfLives == numberOfLives);
        }
    }
}
[System.Serializable]

public class AvatarData
{
    public int numberOfLives;
    public GameObject avatar;
}
