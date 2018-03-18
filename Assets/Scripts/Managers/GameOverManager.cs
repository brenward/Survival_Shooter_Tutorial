using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;


    Animator anim;
    float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0) {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");

            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay) {
                // .. then reload the currently loaded level.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                if (UnityEditor.Lightmapping.giWorkflowMode == UnityEditor.Lightmapping.GIWorkflowMode.Iterative) {
                    DynamicGI.UpdateEnvironment();
                }
            }
        }
    }
}
