using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject loggedIn;
    public TMP_InputField usernameInputField;
    public TextMeshProUGUI infoText;
    public Button submitButton;
    public Toggle rememberMeToggle;
    public Color warningColor;
    public Color normalColor;

    [Header("Customization Options")]
    public int minUsernameLength = 3;
    public int maxUsernameLength = 16;

    private void Awake()
    {
        usernameInputField.Select();
        usernameInputField.ActivateInputField();
        submitButton.onClick.AddListener(Submit);
        usernameInputField.onValueChanged.AddListener(OnChange);

        LoadRememberedUsername();
    }

    private void LoadRememberedUsername()
    {
        if (PlayerPrefs.HasKey("RememberedUsername"))
        {
            usernameInputField.text = PlayerPrefs.GetString("RememberedUsername");
            rememberMeToggle.isOn = true;
        }
    }

    public void OnChange(string username)
    {
        if (username.Trim() != "")
        {
            infoText.text = "Press enter to continue.";
            infoText.color = normalColor;
            infoText.gameObject.SetActive(true);
        }
    }

    public void Submit()
    {
        string username = usernameInputField.text.Trim();

        if (username == "")
        {
            infoText.text = "Please enter a name.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        if (username.Length < minUsernameLength || username.Length > maxUsernameLength)
        {
            infoText.text = $"Username must be between {minUsernameLength} and {maxUsernameLength} characters.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        if (rememberMeToggle.isOn)
        {
            PlayerPrefs.SetString("RememberedUsername", username);
        }
        else
        {
            PlayerPrefs.DeleteKey("RememberedUsername");
        }

        Game.instance.InitManual(username);
        loggedIn.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
