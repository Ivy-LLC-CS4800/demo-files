using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class AddUser : MonoBehaviour {
    private string dbName;

    void Start() {
        dbName = Path.Combine(Application.persistentDataPath, "Database/User.db");
        //GameObject UserNameInput = 
        // TODO: Add code to check that username and password are 20 chaaracters max.
        // TODO: Get User name and User values.
        string userName = "Purple_Fire_Eater";
        string password = "ILovePupp1e$";
        var role = "Volunteer";
        var totalScore = 90.00;
        AddNewUser(userName, password, role, totalScore);
    }//end Start()

    public void AddNewUser(string userName, string password, string role, double totalScore) {
        using(var connection = new SqliteConnection(dbName)) {
            connection.Open();

            using (var command = connection.CreateCommand()) {
                command.CommandText = "INSERT INTO user (username, password, role, totalScore) VALUES ('" + userName + "', '" + password + "', " + role + "', " + totalScore + "'" + ");";
                command.ExecuteNonQuery(); // runs the SQL command
            }//end using

            connection.Close();
        }//end using
    }//end AddUser()
}//end AddUser()
