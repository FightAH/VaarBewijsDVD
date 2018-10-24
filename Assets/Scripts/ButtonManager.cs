using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private string source;
    private MySqlConnection connection;

    public static int ID = 1;

    public Text Tekst;
    public Text Titel;
    public Image Image;

    public GameObject Button;

    void Start()
    {

        source = "Server=localhost;" +
                     "Database = vaarbewijsdvd;" +
                     "User ID = root;" +
                     "Pooling = false;" +
                     "Password= ";


        SQLConnection(source);
        Listar(connection);
        Listar2(connection);
    }
    void Update()
    {
        if(ID == 24)
        {
            Tekst.text = "Einde Les";
            Image.sprite = Resources.Load<Sprite>("Images/24");
            Button.SetActive(true);
        }
        else
        {
            Button.SetActive(false);
        }
        if (ID < 24)
        {
            Debug.Log(ID);
            Listar(connection);
            Listar2(connection);
        }
    }

    void SQLConnection(string _source)
    {
        connection = new MySqlConnection(_source);
        connection.Open();
    }

    void Listar(MySqlConnection _connection)
    {
        MySqlCommand command = _connection.CreateCommand();
        command.CommandText = "SELECT Tekst from tekst WHERE ID ='" + ID + "'";
        MySqlDataReader reader = command.ExecuteReader();
        

        while (reader.Read())
        {
            string tekst = (string)reader["tekst"];
            Tekst.text = tekst;
            Debug.Log(tekst);
            Image.sprite = Resources.Load<Sprite>("Images/" + ID);
        }
        reader.Close();
    }
    void Listar2(MySqlConnection _connection)
    {
        MySqlCommand command = _connection.CreateCommand();
        command.CommandText = "SELECT Titel from tekst WHERE ID ='" + ID + "'";
        MySqlDataReader reader = command.ExecuteReader();


        while (reader.Read())
        {
            string titel = (string)reader["titel"];
            Titel.text = titel;
            Debug.Log(titel);
        }
        reader.Close();
    }


    // Use this for initialization
    public void MainMenu(string MainMenu)
    {
        SceneManager.LoadScene("Startscherm");
        ID = 1;
    }

    public void Lessen(string Lessen)
    {
        SceneManager.LoadScene("Lessen");
        ID = 1;

    }

    public void Les1(string Les1)
    {
        SceneManager.LoadScene("Les1");
    }

    public void Les2(string Les2)
    {
        SceneManager.LoadScene("Les2");
    }

    public void QuitGame(string QuitGame)
    {
        Application.Quit();
    }
    public void WebShop(string WebShop)
    {
        Application.OpenURL("https://www.theoriethuis.nl/");
    }
    public void Vorige(string Vorige)
    {
        if (ID > 1)
        {
            ID = ID - 1;
            Debug.Log(ID);
            Listar(connection);
            Listar2(connection);
        }
    }
    public void Volgende(string Volgende)
    {
        if (ID < 24)
        {
            ID = ID + 1;
            Debug.Log(ID);
            Listar(connection);
            Listar2(connection);
        }
    }
}
    
