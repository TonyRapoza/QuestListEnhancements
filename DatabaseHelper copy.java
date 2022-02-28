package com.example.taskmanagement;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

import com.google.android.material.appbar.AppBarLayout;

public class DatabaseHelper extends SQLiteOpenHelper {

    public static final String dbName = "Login.db";

    public DatabaseHelper(Context context) {
        super(context, "Login.db", null, 1);
    }


    @Override
    public void onCreate(SQLiteDatabase MyDB) {
        //Creates users table with username and password columns
        MyDB.execSQL("create Table users(username TEXT primary key, password TEXT)");
        MyDB.execSQL("create Table tasks(date TEXT primary key, time TEXT, event TEXT)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase MyDB, int oldVersion, int newVersion) {
        MyDB.execSQL("drop Table if exists users");
        MyDB.execSQL("drop Table if exists tasks");
    }

    // Function for inserting new usernames and passwords.
    public Boolean insertData(String username, String password){
        SQLiteDatabase MyDB = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("username", username);
        contentValues.put("password", password);
        long result = MyDB.insert("users", null,contentValues);
        if(result==-1) return false;
        else
            return true;
    }
    // Function for inserting tasks into database.
    public Boolean insertTask(String date, String time, String event){
        SQLiteDatabase MyDB = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("date", date);
        contentValues.put("time", time);
        contentValues.put("event", event);
        long result = MyDB.insert("tasks", null,contentValues);
        if(result==-1) return false;
        else
            return true;
    }

    // checks if username exists
    public Boolean checkUsername(String username){
        SQLiteDatabase MyDB = this.getWritableDatabase();
        Cursor cursor = MyDB.rawQuery("Select * from users where username = ?", new String[] {username});
        if(cursor.getCount()>0)
            return true;
        else
            return false;
    }

    // checks if username and password are correct
    public Boolean checkUsernamePassword(String username, String password){
        SQLiteDatabase MyDB = this.getWritableDatabase();
        Cursor cursor = MyDB.rawQuery("Select * from users where username = ? and password =?", new String[] {username, password});
        if(cursor.getCount()>0)
            return true;
        else
            return false;
    }
}
