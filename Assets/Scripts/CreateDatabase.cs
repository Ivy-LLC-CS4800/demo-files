using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class CreateDatabase : MonoBehaviour {

	var dbName = “URL=file:User.db”;

	void Start() {
		CreateDB();
	}//end Start()

	CreateDB() {
		using (var connection = new SqliteConnection(dbName)) {
			connection.Open();
		
			using (var command = connection.CreateCommand()) {
				command.CommandText = “CREATE TABLE IF NOT EXISTS user (username VARCHAR(20), password VARCHAR(20), time DOUBLE, score INT)”;
				command.ExecuteNonQuery();
			}//end using
			Connection.Close;
		}//end using
	}//end CreateDB()
}//end CreateDatabase
