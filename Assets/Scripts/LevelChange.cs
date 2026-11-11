using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    void Update()
    {
        ChangeLevelInput();
    }
    [SerializeField] private int levelIndex;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Movement>() != null)
        {
            SceneManager.LoadScene(levelIndex);
        }
    }

    private void ChangeLevelInput()
    {
        if(Input.GetKey(KeyCode.L))
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                SceneManager.LoadScene(levelIndex);
            }
        }
    }
}

