using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;

public class DisplayUsers : MonoBehaviour {
    private string dbName;

    void Start() {
        dbName = "Data Source=" + Path.Combine(Application.persistentDataPath, "Database/User.db");
        GameObject UserDataTextDisplay = GameObject.FindWithTag("UserData");
        Text uiText = UserDataTextDisplay.GetComponent<Text>(); 
        DisplayAllUsers(uiText);
    }//end Start()

    public void DisplayAllUsers(Text uiText) {  
        using (var connection = new SqliteConnection(dbName)) {
            connection.Open();

            using (var command = connection.CreateCommand()) {
                command.CommandText = "SELECT * FROM users;";

                using (IDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Debug.Log("User Name: " + reader["username"] + "\tPassword: " + reader["password"] + "\tRole: " + reader["role"] + "\tTotal Score: " + reader["totalScore"]);
                        uiText.text = reader["username"] + "\t" + reader["password"] + "\t" + reader["role"] + "\t" + reader["totalScore"];
                    }//end while-loop
                }//end using
            }//end using

            connection.Close();
        }//end using
    }//end DisplayUsers()
}//end DisplayUsers
