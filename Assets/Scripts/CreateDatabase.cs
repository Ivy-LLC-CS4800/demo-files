using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class CreateDatabase : MonoBehaviour {
	private string dbName;

    void Start() {
        dbName = Path.Combine(Application.persistentDataPath, "Database/User.db");
		CreateDB();

        //dbName = Path.Combine(Application.persistentDataPath, "Database/User.db");
        //GameObject UserNameInput = 
        // TODO: Add code to check that username and password are 20 chaaracters max.
        // TODO: Get User name and User values.
        string userName = "Purple_Fire_Eater";
        string password = "ILovePupp1e$";
        var role = "Volunteer";
        var totalScore = 90.00;
        AddNewUser(userName, password, role, totalScore);
	}//end Start()
    
    // ArgumentException: Data Source cannot be empty.  Use :memory: to open an in-memory database
    // Mono.Data.Sqlite.SqliteConnection.Open () (at <0c44d5dee87348f195ef2e31b8759f9d>:0)
    // DisplayUsers.DisplayAllUsers (UnityEngine.UI.Text uiText) (at Assets/Scripts/DisplayUsers.cs:17)
    // DisplayUsers.Start () (at Assets/Scripts/DisplayUsers.cs:12)
	public void CreateDB() {
		using (var connection = new SqliteConnection(dbName)) {
			connection.Open();
		
			using (var command = connection.CreateCommand()) {
				command.CommandText = "CREATE TABLE IF NOT EXISTS user (username VARCHAR(20), password VARCHAR(30), role VARCHAR(20), totalScore DOUBLE)";
				command.ExecuteNonQuery();
			}//end using
			connection.Close();
		}//end using
	}//end CreateDB()

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
}//end CreateDatabase
