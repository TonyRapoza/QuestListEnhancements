/*  ------------------------------
 *  UserAccount.cs
 *  ------------------------------
 *  This script creates the structure used for establishing value pairs for the
 *  UserAccount objects to help keep things organized when the system saves the 
 *  objects and when it loads them upon boot.
 */
using System;

[Serializable]
public class UserAccount
{
    // variables stored in the object.
    public string user;
    public string password;

    // Serves as the user account constructor.
    public UserAccount(string user, string password)
    {
        this.user = user;
        this.password = password;
    }
}