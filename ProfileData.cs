/*  ------------------------------
 *  ProfileData.cs
 *  ------------------------------
 *  This script creates the structure used for establishing value pairs for the
 *  task objects to help keep things organized when the system saves the 
 *  objects and when it loads them upon boot.
 */
using System;

[Serializable]
public class ProfileData
{
    // variables stored in the object.
    public int level;
    public int xp;

    // Serves as the user account constructor.
    public ProfileData(int level, int xp)
    {
        this.level = level;
        this.xp = xp;
    }
}