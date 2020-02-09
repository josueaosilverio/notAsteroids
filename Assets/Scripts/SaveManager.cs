using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{

    public ShipData data;

    [SerializeField]
    private GameObject[] shipList;


    private void Start()
    {
        if (LoadPieces() == null)
        {
            bool[] data = new bool[3];
            data[0] = false;
            data[1] = false;
            data[2] = false;
            int money = 0;
            int currentShip = 0;

            SavePieces(data, money, currentShip);
        }


        data = LoadPieces();


        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Instantiate(shipList[data.currentShip], transform.position, Quaternion.identity);
        }

    }
    public static void SavePieces(bool[] data, int money, int currentShip)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ships.jaos";
        FileStream stream = new FileStream(path, FileMode.Create);

        ShipData shipData = new ShipData(data, money, currentShip);

        formatter.Serialize(stream, shipData);
        stream.Close();
    }

    public static ShipData LoadPieces()
    {
        string path = Application.persistentDataPath + "/ships.jaos";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipData data = formatter.Deserialize(stream) as ShipData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
