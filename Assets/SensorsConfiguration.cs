using UnityEngine;
using UnityEngine.UI;

public class SensorsConfiguration : MonoBehaviour
{
    public Transform UIPanel;

    public NDIPlayer player;

    // Reference selector
    public Dropdown refDropdown;

    // Jaw selector
    public Dropdown jawDropdown;

    // Lip selectors
    public Dropdown lipLeftDropdown;
    public Dropdown lipRightDropdown;

    // Tongue selectors
    public Dropdown tongueTipDropdown;
    public Dropdown tongueMidDropdown;
    public Dropdown tongueBackDropdown;

    bool isPaused;

    void Start()
    {
        UIPanel.gameObject.SetActive(true);
        isPaused = true;

        // Listener for Ref
        refDropdown.onValueChanged.AddListener(delegate {
            player.S_REF_ID = refDropdown.value;
        });

        // Listener for Jaw
        jawDropdown.onValueChanged.AddListener(delegate {
            player.S_JAW_ID = jawDropdown.value;
        });

        // Listener for Lip corner left
        lipLeftDropdown.onValueChanged.AddListener(delegate {
            player.S_LIP_L_ID = lipLeftDropdown.value;
        });

        // Listener for Lip corner right
        lipRightDropdown.onValueChanged.AddListener(delegate {
            player.S_LIP_R_ID = lipRightDropdown.value;
        });

        // Listener for Tongue tip
        tongueTipDropdown.onValueChanged.AddListener(delegate {
            player.S_TTIP_ID = tongueTipDropdown.value;
        });

        // Listener for Tongue mid
        tongueMidDropdown.onValueChanged.AddListener(delegate {
            player.S_TMID_ID = tongueMidDropdown.value;
        });

        // Listener for Tongue back
        tongueBackDropdown.onValueChanged.AddListener(delegate {
            player.S_TBACK_ID = tongueBackDropdown.value;
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            UnPause();
        }            
    }

    public void Pause()
    {
        isPaused = true;
        UIPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        isPaused = false;
        UIPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}