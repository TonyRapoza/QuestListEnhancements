/*  ------------------------------
 *  Register.cs
 *  ------------------------------
 *  This script handles all of the input field functionality in the register 
 *  frame and triggers account creation, which stores the information in the
 *  script-based databse I have created.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour
{
    // Script References
    [SerializeField] internal AccountDatabase accountDB;


    // Game Object Variables
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confPassword;
    public Text warning;

    // Back End Variables
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;
    private string filename = "accounts.json";

    // Update is called once per frame
    void Update()
    {
        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfPassword = confPassword.GetComponent<InputField>().text;

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
                email.GetComponent<InputField>().Select();
            }
            else if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            else if (password.GetComponent<InputField>().isFocused)
            {
                confPassword.GetComponent<InputField>().Select();
            }
        }
    }

    
    public void SignUpButton()
    {
        // Checks to see if passwords match
        if (Password == ConfPassword) 
        {
            // Finds if the username exists and creates account if it doesn't.
            UserAccount checkedUser = accountDB.userAccounts.Find(UserAccount => UserAccount.user == Username);
            if (checkedUser == null)
            {
                accountDB.userAccounts.Add(new UserAccount(Username, Password));
                DatabaseHandler.SaveToJSON<UserAccount>(accountDB.userAccounts, filename);
            }
            else
            {
                warning.text = "Username already exists!";
            }
        }
        else
        {
            warning.text = "Passwords do not match!";
        }

        
    }
}
