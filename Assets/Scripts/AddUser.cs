using UnityEngine;

public class AddUser : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // TODO: Add code to check that username and password are 20 chaaracters max.
        
        AddUser(userName, password, 0, totalScore, new SQliteConnection(dbName));
    }//end Start()

    // Update is called once per frame
    void Update() {
        
    }//end Update()

    public void AddUser(string userName, string password, bool role, double totalScore, var databaseConnection) {
        using(var connection = databaseConnection) {
            connection.Open();

            using (var command = connection.CreateCommand()) {
                command.CommandText = "INSERT INTO user (username, password, role, score) VALUES ('" + userName + "', '" + password + "', " + role + "', " + score + "'" + ");"
                command.ExecuteNonQuery(); // runs the SQL command
            }//end using
        }//end using
    }//end AddUser()
}//end AddUser()
