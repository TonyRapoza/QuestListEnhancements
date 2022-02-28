/*  ------------------------------
 *  Task.cs
 *  ------------------------------
 *  This script creates the structure used for establishing value pairs for the
 *  task objects to help keep things organized when the system saves the 
 *  objects and when it loads them upon boot.
 */
using System;

[Serializable]
public class Task
{
    // variables stored in the object.
    public int id;
    public string toDo;

    // Serves as the user account constructor.
    public Task(int id, string toDo)
    {
        this.id = id;
        this.toDo = toDo;
    }
}