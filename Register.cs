using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject loggedIn;
    public TMP_InputField usernameInputField;
    public TMP_InputField passwordInputField;
    public TMP_InputField confirmPasswordInputField;
    public TextMeshProUGUI infoText;
    public Button submitButton;
    public Color warningColor;
    public Color normalColor;

    [Header("Customization Options")]
    public int minUsernameLength = 3;
    public int maxUsernameLength = 16;
    public int minPasswordLength = 6;
    public int maxPasswordLength = 32;

    private void Awake()
    {
        usernameInputField.Select();
        usernameInputField.ActivateInputField();
        submitButton.onClick.AddListener(Submit);

        // Remove this line if you don't want to validate input on every change
        usernameInputField.onValueChanged.AddListener(ValidateInput);
        passwordInputField.onValueChanged.AddListener(ValidateInput);
        confirmPasswordInputField.onValueChanged.AddListener(ValidateInput);
    }

    public void ValidateInput(string input)
    {
        string username = usernameInputField.text.Trim();
        string password = passwordInputField.text;
        string confirmPassword = confirmPasswordInputField.text;

        if (username.Length < minUsernameLength || username.Length > maxUsernameLength)
        {
            infoText.text = $"Username must be between {minUsernameLength} and {maxUsernameLength} characters.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        if (password.Length < minPasswordLength || password.Length > maxPasswordLength)
        {
            infoText.text = $"Password must be between {minPasswordLength} and {maxPasswordLength} characters.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        if (password != confirmPassword)
        {
            infoText.text = "Passwords do not match.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        infoText.text = "Press enter to continue.";
        infoText.color = normalColor;
        infoText.gameObject.SetActive(true);
    }

    public void Submit()
    {
        string username = usernameInputField.text.Trim();
        string password = passwordInputField.text;
        string confirmPassword = confirmPasswordInputField.text;

        if (username.Length < minUsernameLength || username.Length > maxUsernameLength)
        {
            infoText.text = $"Username must be between {minUsernameLength} and {maxUsernameLength} characters.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        if (password.Length < minPasswordLength || password.Length > maxPasswordLength)
        {
            infoText.text = $"Password must be between {minPasswordLength} and {maxPasswordLength} characters.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        if (password != confirmPassword)
        {
            infoText.text = "Passwords do not match.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        // Register the user, for example using a server API call.
        // If registration is successful, proceed with the following:

        Game.instance.InitManual(username);
        loggedIn.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
