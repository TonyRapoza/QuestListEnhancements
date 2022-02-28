/*  ------------------------------
 *  TaskDatabase.cs
 *  ------------------------------
 *  This script generates a script-based account database and also loads the
 *  saved database of accounts each time the program is loaded.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class TaskDatabase : MonoBehaviour
{
    // Game Object Variables
    public GameObject taskOne;
    public GameObject taskTwo;
    public GameObject taskThree;
    public GameObject taskFour;
    public GameObject taskFive;

    public Text Level;
    public Text XP;

    // Back End Variables
    private string TaskOne;
    private string TaskTwo;
    private string TaskThree;
    private string TaskFour;
    private string TaskFive;

    private int level = 1;
    private int xp = 1000;

    // Creates the lists that will be used for managing runtime database info.
    public List<Task> tasks = new List<Task>();
    public List<ProfileData> data = new List<ProfileData>();

    // Runs when script object is first loaded.
    void Awake()
    {
        BuildTaskDatabase();
        PrintTasks();
        PrintData();
    }

    // Update is called once per frame.
    void Update()
    {
        TaskOne = taskOne.GetComponent<InputField>().text;
        TaskTwo = taskTwo.GetComponent<InputField>().text;
        TaskThree = taskThree.GetComponent<InputField>().text;
        TaskFour = taskFour.GetComponent<InputField>().text;
        TaskFive = taskFive.GetComponent<InputField>().text;
        CheckForTaskUpdates();

    }

    // Calls the handler function for converting database into a runtime list.
    void BuildTaskDatabase()
    {
        tasks = DatabaseHandler.ReadListFromJSON<Task>("tasks.json");
        data = DatabaseHandler.ReadListFromJSON<ProfileData>("data.json");
    }

    // Saves any changes to the task database.
    public void CheckForTaskUpdates()
    {
        tasks[0] = new Task(1,TaskOne);
        tasks[1] = new Task(2, TaskTwo);
        tasks[2] = new Task(3, TaskThree);
        tasks[3] = new Task(4, TaskFour);
        tasks[4] = new Task(5, TaskFive);
        DatabaseHandler.SaveToJSON<Task>(tasks, "tasks.json");
    }

    // Prints saved tasks from read JSON.
    public void PrintTasks()
    {
        taskOne.GetComponent<InputField>().text = tasks[0].toDo;
        taskTwo.GetComponent<InputField>().text = tasks[1].toDo;
        taskThree.GetComponent<InputField>().text = tasks[2].toDo;
        taskFour.GetComponent<InputField>().text = tasks[3].toDo;
        taskFive.GetComponent<InputField>().text = tasks[4].toDo;
    }

    //Prints saved Profile Data from read JSON
    public void PrintData()
    {
        xp = data[0].xp;
        level = data[0].level;
        Level.text = level.ToString();
        XP.text = xp.ToString();
    }

    //===========================================
    // All of the below functions delete a task and either add or subtract xp
    // based on whether the quested failed or succeeded.
    //===========================================
    public void DefeatOne()
    {
        taskOne.GetComponent<InputField>().text = "";
        xp = xp + 200;
        CheckForDataUpdate();
    }

    public void DefeatTwo()
    {
        taskTwo.GetComponent<InputField>().text = "";
        xp = xp + 200;
        CheckForDataUpdate();
    }

    public void DefeatThree()
    {
        taskThree.GetComponent<InputField>().text = "";
        xp = xp + 200;
        CheckForDataUpdate();
    }

    public void DefeatFour()
    {
        taskFour.GetComponent<InputField>().text = "";
        xp = xp + 200;
        CheckForDataUpdate();
    }

    public void DefeatFive()
    {
        taskFive.GetComponent<InputField>().text = "";
        xp = xp + 200;
        CheckForDataUpdate();
    }

    public void CompleteOne()
    {
        taskOne.GetComponent<InputField>().text = "";
        xp = xp - 100;
        CheckForDataUpdate();
    }

    public void CompleteTwo()
    {
        taskTwo.GetComponent<InputField>().text = "";
        xp = xp - 100;
        CheckForDataUpdate();
    }

    public void CompleteThree()
    {
        taskThree.GetComponent<InputField>().text = "";
        xp = xp - 100;
        CheckForDataUpdate();
    }

    public void CompleteFour()
    {
        taskFour.GetComponent<InputField>().text = "";
        xp = xp - 100;
        CheckForDataUpdate();
    }

    public void CompleteFive()
    {
        taskFive.GetComponent<InputField>().text = "";
        xp = xp - 100;
        CheckForDataUpdate();
    }
    //===========================================

    //The below function handles the keeping the user level and xp data up to date
    public void CheckForDataUpdate()
    {
        if (xp <= 0)
        {
            xp = 1000;
            level = level + 1;
        }
        XP.text = xp.ToString();
        Level.text = level.ToString();
        data[0].xp = xp;
        data[0].level = level;
        DatabaseHandler.SaveToJSON<ProfileData>(data, "data.json");
    }
}