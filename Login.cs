/*  ------------------------------
 *  Login.cs
 *  ------------------------------
 *  This script handles all of the input field functionality in the login 
 *  frame and triggers account creation, which stores the information in the
 *  script-based databse I have created.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    // Script References
    [SerializeField] internal AccountDatabase accountDB;


    // Game Object Variables
    public GameObject username;
    public GameObject password;
    public Text warning;

    // Back End Variables
    private string Username;
    private string Password;

    // Update is called once per frame.
    void Update()
    {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;


        CheckForTab();
    }

    // This function checks to see if the tab button is pressed while any of the
    // input fields in the Register section are selected. If so, it moves to the
    // next input field.
    public void CheckForTab()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }
    }

    // Handles login when Log In button is clicked
    public void LogInButton()
    {
        // Finds if user account exists and logs in if password is correct.
        UserAccount checkedUser = accountDB.userAccounts.Find(UserAccount => UserAccount.user == Username);
        if (checkedUser != null)
        {
            if (checkedUser.user == Username && checkedUser.password == Password)
            {
                SceneManager.LoadScene("Home");
            }
            else
            {
                warning.text = "Username or password does not exist!";
            }
        }
        else
        {
            warning.text = "Username or password does not exist!";
        }
    }
}
