using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject LightSource;
    private LightList LightRotation;
    public TextMeshProUGUI LightCounter;
    public int Number = 12;
    PlayerMovement PlayerRules;

    public GameObject DeathScreen;
    public GameObject playerUI;

    void Start()
    {
        Time.timeScale = 1f;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerRules = player.GetComponent<PlayerMovement>();
        }

        

        LightRotation = new LightList();
        LightRotation.Add(new Vector3(360, 0, 0));
        LightRotation.Add(new Vector3(25, 0, 0));
        LightRotation.Add(new Vector3(45, 0, 0));
        LightRotation.Add(new Vector3(65, 0, 0));
        LightRotation.Add(new Vector3(85, 0, 0));
        LightRotation.Add(new Vector3(105, 0, 0));
        LightRotation.Add(new Vector3(125, 0, 0));
        LightRotation.Add(new Vector3(145, 0, 0));
        LightRotation.Add(new Vector3(165, 0, 0));
        LightRotation.Add(new Vector3(180, 0, 0));
        LightRotation.Add(new Vector3(190, 0, 0));
        LightRotation.Add(new Vector3(270, 0, 0));

        LightRotation.RemovefirstNode();
    }

    public void LightTime()
    {
        if (LightSource != null)
        {
            Vector3 nextRotation = LightRotation.NextNode();
            LightSource.transform.eulerAngles = nextRotation;
        }
    }

    void Update()
    {
        if (PlayerRules.Dead == true)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LightTime();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            LightRotation.RemovefirstNode();
            Number -= 1;
            LightCounter.text = "Light Options: " + Number;
            
            if (Number <= 0)
            {
                LightCounter.text = "ERROR";
                LightCounter.color = Color.red;
            }
        }
    }

    void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DeathScreen.SetActive(true);
        playerUI.SetActive(false);
    }

    public void TryAgain()
    {
        playerUI.SetActive(true);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
