using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;
using UnityEngine.UI;

public class ListItems : MonoBehaviour {

    public Text txtChange;

    void Start () {
	
	}
    public void Select()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/myDatabase.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(connectionString);

        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * " + "FROM Account";

        dbcmd.CommandText = sqlQuery;

        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string username = reader.GetString(1);
            string password = reader.GetString(2);
            int age = reader.GetInt32(3);
            
            txtChange.text += "\nPlayerName = " + username + "\nPassword = " + password + "\nAge = " + age;

            //highScoreTxt.text = "High Score = " + highestScore;
            //Debug.Log("High Score = " + highestScore);
        }

        reader.Close(); reader = null;
        dbcmd.Dispose(); dbcmd = null;
        dbconn.Close(); dbconn = null;
    }
}
