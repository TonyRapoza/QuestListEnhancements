package com.example.taskmanagement;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    //Interactables Variables
    private EditText username;
    private EditText password;
    private Button login;
    private Button signup;

    //Database Variables
    DatabaseHelper db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        username = (EditText)findViewById(R.id.loginName);
        password = (EditText)findViewById(R.id.loginPass);
        login = (Button)findViewById(R.id.buttonLogin);
        signup = (Button)findViewById(R.id.buttonNewAccount);
        db = new DatabaseHelper(this);

        // Handles signup button clicking
        signup.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view){
                String user = username.getText().toString();
                String pw = password.getText().toString();

                // Checks if username and password are missing
                if(user.equals("")||pw.equals("")) {
                    Toast.makeText(MainActivity.this, "All fields must be entered.", Toast.LENGTH_SHORT).show();
                }else{
                    Boolean checkUser = db.checkUsername(user);
                    if(checkUser==false){
                        Boolean insert = db.insertData(user,pw);
                        if(insert==true){
                            Toast.makeText(MainActivity.this, "Account created!", Toast.LENGTH_SHORT).show();
                            Intent intent = new Intent(MainActivity.this,ScheduleActivity.class);
                            startActivity(intent);
                        }else{
                            Toast.makeText(MainActivity.this, "Account creation failed.", Toast.LENGTH_SHORT).show();
                        }
                    }else{
                        Toast.makeText(MainActivity.this, "Username already exists. Please sign in.", Toast.LENGTH_SHORT).show();
                    }
                }
            }
        });

        // Handles login button clicking
        login.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view){
                String user = username.getText().toString();
                String pw = password.getText().toString();

                // Checks if username and password are missing
                if(user.equals("")||pw.equals("")) {
                    Toast.makeText(MainActivity.this, "All fields must be entered.", Toast.LENGTH_SHORT).show();
                }else{
                    Boolean checkUserPass = db.checkUsernamePassword(user,pw);
                    if(checkUserPass==true){
                        Intent intent = new Intent(MainActivity.this,ScheduleActivity.class);
                        startActivity(intent);
                    }else{
                        Toast.makeText(MainActivity.this, "Username and/or password are invalid. ", Toast.LENGTH_SHORT).show();
                    }
                }
            }
        });
    }
}