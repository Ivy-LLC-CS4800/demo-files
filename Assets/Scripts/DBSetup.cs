using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using Mono.Data.Sqlite;

public class DBSetup : MonoBehaviour
{

    public TMP_InputField userId;
    public TMP_InputField simType;
    public TMP_InputField time;
    public TMP_InputField score;

    public TextMeshProUGUI runList;
    
    private string dbName = "URI=file:UserLogs.db";

    void Start()
    {
        CreateDB();

        DisplayAll();
    }

    public void CreateDB()
    {
        using ( var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Runs (userId INT, simType INT, time VARCHAR(30), score VARCHAR(30));";
                command.ExecuteNonQuery();
                Debug.Log("yo mama");
            }

            connection.Close();
        }
    }

    public void AddRun()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Runs (userId, simType, time, score) VALUES ('" + userId.text + "', '" + simType.text + "', '" + time.text + "', '" + score.text + "');";
                command.ExecuteNonQuery();
                Debug.Log("skibidi");
            }
            connection.Close();
        }

        DisplayAll();
    }

    public void DisplayAll()
    {
        runList.text = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Runs;";
                Debug.Log("poopybutt");

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        runList.text += reader["userId"] + "\t" + reader["simType"] + "\t" + reader["time"] + "\t\t" + reader["score"] + "\n";

                        reader.Close();
                }
            }
            connection.Close();
        }
    }

    // end of class
}
