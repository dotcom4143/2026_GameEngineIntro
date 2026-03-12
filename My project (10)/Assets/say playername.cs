using UnityEngine;

public class sayplayername : MonoBehaviour
{
    public string playerName;

    private void Start()
    {
        Debug.Log("Hello " + playerName);
    }
}
