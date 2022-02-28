/*  ------------------------------
 *  AccountDatabase.cs
 *  ------------------------------
 *  This script generates a script-based account database and also loads the
 *  saved database of accounts each time the program is loaded.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountDatabase : MonoBehaviour
{
    // Creates the list that will be used for managing runtime database info.
    public List<UserAccount> userAccounts = new List<UserAccount>();

    // Runs when script object is first loaded.
    void Awake()
    {
        BuildAccountDatabase();    
    }

    // Calls the handler function for converting database into a runtime list.
    void BuildAccountDatabase()
    {
        userAccounts = DatabaseHandler.ReadListFromJSON<UserAccount>("accounts.json");
    }
}
