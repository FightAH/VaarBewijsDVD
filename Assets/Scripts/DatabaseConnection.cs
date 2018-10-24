using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
using UnityEngine.UI;

public class DatabaseConnection : MonoBehaviour
{
    private string source;
    public MySqlConnection connection;

    public int ID = 1;

    public Text Tekst;
    public Image Image;
    void Start()
    {

        source = "Server=localhost;" +
                     "Database = vaarbewijsdvd;" +
                     "User ID = root;" +
                     "Pooling = false;" +
                     "Password= ";


        SQLConnection(source);
        Listar(connection);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SQLConnection(string _source)
    {
        connection = new MySqlConnection(_source);
        connection.Open();
    }

    public void Listar(MySqlConnection _connection)
    {
        MySqlCommand command = _connection.CreateCommand();
        command.CommandText = "SELECT Tekst from tekst WHERE ID ='" + ID + "'";
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string tekst = (string)reader["tekst"];

            Tekst.text = tekst;
            Debug.Log(tekst);
            Image.sprite = Resources.Load<Sprite>("Images/"+ID);


        }

    }

}