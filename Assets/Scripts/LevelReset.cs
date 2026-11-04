using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Movement>() != null)
        {
            SceneManager.LoadScene(2);
        }
    }
}
