using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForgotPassword : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject passwordResetSent;
    public TMP_InputField emailInputField;
    public TextMeshProUGUI infoText;
    public Button submitButton;
    public Color warningColor;
    public Color normalColor;

    [Header("Customization Options")]
    [Tooltip("Regular expression pattern to validate email addresses.")]
    public string emailValidationPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

    private void Awake()
    {
        emailInputField.Select();
        emailInputField.ActivateInputField();
        submitButton.onClick.AddListener(Submit);
        emailInputField.onValueChanged.AddListener(ValidateInput);
    }

    public void ValidateInput(string input)
    {
        string email = emailInputField.text.Trim();

        if (IsValidEmail(email))
        {
            infoText.text = "Press enter to continue.";
            infoText.color = normalColor;
            infoText.gameObject.SetActive(true);
        }
        else
        {
            infoText.text = "Please enter a valid email address.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
        }
    }

    private bool IsValidEmail(string email)
    {
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(emailValidationPattern);
        return regex.IsMatch(email);
    }

    public void Submit()
    {
        string email = emailInputField.text.Trim();

        if (!IsValidEmail(email))
        {
            infoText.text = "Please enter a valid email address.";
            infoText.color = warningColor;
            infoText.gameObject.SetActive(true);
            return;
        }

        // Send a password reset request, for example using a server API call.
        // If the request is successful, proceed with the following:

        passwordResetSent.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
