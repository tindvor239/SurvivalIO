using UnityEngine;

public class WinManager : MonoBehaviour
{
    private bool isWinable;

    private void Update()
    {
        if (isWinable)
        {
            var followEnemy = FindAnyObjectByType<FollowEnemy>();
            if (followEnemy != null)
            {
                return;
            }
        }
    }
}
