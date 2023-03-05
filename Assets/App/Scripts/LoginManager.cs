using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public Button signInButton;
    public Button signUpButton;

    public TMP_InputField nameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {
        signInButton.onClick.AddListener(SignIn);
        signUpButton.onClick.AddListener(SignUp);
        PlayfabManager.Instance.OnSignIn += () => { SceneManager.LoadScene(1); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SignIn()
    {
        PlayfabManager.Instance.SignIn(emailInput.text, passwordInput.text);
    }
    private void SignUp()
    {
        PlayfabManager.Instance.SignUp(emailInput.text, passwordInput.text, nameInput.text);

    }
}
