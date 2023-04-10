using TMPro;
using UnityEngine;

using System.Text;
using System.Globalization;

public class CustomInputValidation : MonoBehaviour
{
    public TMP_InputField input;

    public static string RemoveSpecialCharacters(string str)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in str)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ')
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    public void Validate(string x)
    {
        x = CustomInputValidation.TitleCase(x, false);
        input.text = RemoveSpecialCharacters(x);
    }

    public static string TitleCase(string s, bool all)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(all ? s.ToLower() : s);
    }
}
