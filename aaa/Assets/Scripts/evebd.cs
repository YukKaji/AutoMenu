using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class evebd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/StreamingAssets/db.bytes.db";
        using (IDbConnection dbcon = (IDbConnection)new SqliteConnection(connectionString))
        {
            dbcon.Open();

            // Выбираем нужные нам данные
            var sql = "SELECT id, namef FROM food";
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                dbcmd.CommandText = sql;
                // Выполняем запрос
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    // Читаем и выводим результат
                    while (reader.Read())
                    {
                        const string frmt = "id: {0}; name: {1};";
                        Debug.Log(string.Format(frmt,
                            reader.GetInt32(0),
                            reader.GetString(1)
                          ));
                    }
                }
            }
            // Закрываем соединение
            dbcon.Close();
        }
    }
}
