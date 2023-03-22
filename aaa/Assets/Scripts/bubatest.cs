using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class bubatest : MonoBehaviour
{
    public Text d1asa, d1hiru, d1pol, d1yoru;
    public Text d2asa, d2hiru, d2pol, d2yoru;
    public Text d3asa, d3hiru, d3pol, d3yoru;
    public Text d4asa, d4hiru, d4pol, d4yoru;
    public Text d5asa, d5hiru, d5pol, d5yoru;
    public Text d6asa, d6hiru, d6pol, d6yoru;
    public Text d7asa, d7hiru, d7pol, d7yoru;
    public Text d8asa, d8hiru, d8pol, d8yoru;
    public Text d9asa, d9hiru, d9pol, d9yoru;
    public Text d10asa, d10hiru, d10pol, d10yoru;
    public Text prsum1, prsum2;

    void Start()
    {           
        int[][] day1 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day2 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day3 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day4 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day5 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day6 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day7 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day8 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day9 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        int[][] day10 = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        string[][] tab = new string[4][] {
            new string[3] { "Zavt_osn", "Zavt_But", "Zavt_Nap" },
            new string[6] { "Obed_salat", "Obed_Osn", "Obed_Nap", "Hlep", "Obed_Vt", "Obed_Vt_dop" },
            new string[1] { "Pold" },
            new string[3] { "Uz_Osn", "Uz_Nap", "Hlep" }
        };
        int[][] ind = new int[4][] {
            new int[3],
            new int[6],
            new int[1],
            new int[3]
        };
        double[] prodsum1 = new double[29];
        double[] prodsum2 = new double[29];

        string connectionString = "URI=file:" + Application.dataPath + "/StreamingAssets/omgw.db";
        IDbConnection dbcon = new SqliteConnection(connectionString);
        dbcon.Open();        
        //Генерация массива с индексами
        for (int i = 0; i < day1.Length; i++) 
        {
            for (int j = 0; j < day1[i].Length; j++) 
            {
                IDbCommand cd = dbcon.CreateCommand();
                cd.CommandText = "SELECT MAX(id) FROM " + tab[i][j];
                IDataReader rd = cd.ExecuteReader();

                while (rd.Read())
                {
                    int a = rd.GetInt32(0);
                    ind[i][j] = a + 1;
                }
                rd.Close();
                rd = null;
            }
        }
        //Функция команды
        int Edb(int[][] zap, int i, int j)
        {
            IDbCommand cd = dbcon.CreateCommand();
            cd.CommandText = "SELECT dop FROM Obed_Vt WHERE id = " + zap[i][j];
            IDataReader rd = cd.ExecuteReader();

            int a = 0;

            while (rd.Read())
            {
                a = rd.GetInt32(0);
            }
            rd.Close();
            rd = null;
            return a;
        }
        //Функция взятия данных о белках жирах углеводах и энерг. ценности
        double bjue(int[][] zap, int i, int j, string stol)
        {
            IDbCommand cd = dbcon.CreateCommand();
            cd.CommandText = "SELECT " + stol + " FROM " + tab[i][j] + " WHERE id = " + zap[i][j];
            IDataReader rd = cd.ExecuteReader();

            double a = 0;

            while (rd.Read())
            {
                a = rd.GetDouble(0);
            }
            rd.Close();
            rd = null;
            return a;
        }
        //Функция взятия имени блюда
        string nameNa(int[][] zap, int i, int j, string stol)
        {
            IDbCommand cd = dbcon.CreateCommand();
            cd.CommandText = "SELECT " + stol + " FROM " + tab[i][j] + " WHERE id = " + zap[i][j];
            IDataReader rd = cd.ExecuteReader();

            string a = "";

            while (rd.Read())
            {
                a = rd.GetString(0);
            }
            rd.Close();
            rd = null;
            return a;
        }
        //Функция подсчета продуктов
        void prodsch(int[][] d1, int[][] d2, int[][] d3, int[][] d4, int[][] d5, double[] aaa)
        {
            string[] prod = { "DrHlep", "KakP", "Kart", "Kolbasa", "Konditer", "Kofe",
                            "KrupiBob", "Makaroni", "MasloSliv", "MasloRast", "MolokoIKis", "MukaKart",
                            "MukaPshen", "Myaso", "Ovosh", "Ptica", "Riba", "Sahar",
                            "Smetana", "Soki", "Sol", "Sir", "Tvorog", "FruktiSvez",
                            "FruktiSuh", "HlepPshen", "HlepRz", "Chay", "Yayco" };
            double[][] promej1 = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            double[][] promej2 = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            double[][] promej3 = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            double[][] promej4 = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            double[][] promej5 = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            for (int i = 0; i < prod.Length; i++)
            {
                for (int j = 0; j < d1.Length; j++)
                {
                    for (int k = 0; k < d1[j].Length; k++)
                    {
                        promej1[j][k] = bjue(d1, j, k, prod[i]);
                        promej2[j][k] = bjue(d2, j, k, prod[i]);
                        promej3[j][k] = bjue(d3, j, k, prod[i]);
                        promej4[j][k] = bjue(d4, j, k, prod[i]);
                        promej5[j][k] = bjue(d5, j, k, prod[i]);
                    }
                }
                for (int j = 0; j < promej1.Length; j++)
                {
                    for (int k = 0; k < promej1[j].Length; k++)
                    {
                        aaa[i] = aaa[i] + promej1[j][k] + promej2[j][k] + promej3[j][k] + promej4[j][k] + promej5[j][k];
                    }
                }
            }
            for (int i = 0; i < aaa.Length; i++)
            {
                Debug.Log(prod[i] + " = " + aaa[i]);
            }
        }
        //Функция генерации дня
        void znac(int[][] mas, int[][] pr)
        {
            double bls, jrs, ugs, ecs;
            do
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = 0; j < mas[i].Length; j++)
                    {
                        if (tab[i][j] == "Obed_Vt_dop" && Edb(mas, i, j - 1) == 1)
                        {
                            int ch = Random.Range(1, ind[i][j]);

                            if (ch != pr[i][j])
                            {
                                mas[i][j] = ch;
                                Debug.Log("[" + i + "][" + j + "]: " + mas[i][j] + " " + tab[i][j]);
                            }
                            else
                            {
                                while (ch == pr[i][j])
                                {
                                    ch = Random.Range(1, ind[i][j]);
                                    mas[i][j] = ch;
                                    Debug.Log("[" + i + "][" + j + "]: " + mas[i][j] + " - Перегенерированное число " + tab[i][j]);
                                }
                            }
                        }
                        else if (tab[i][j] == "Obed_Vt_dop" && Edb(mas, i, j - 1) == 0)
                        {
                            mas[i][j] = 0;
                            continue;
                        }
                        else
                        {
                            int ch = Random.Range(1, ind[i][j]);

                            if (ch != pr[i][j])
                            {
                                mas[i][j] = ch;
                                Debug.Log("[" + i + "][" + j + "]: " + mas[i][j] + " " + tab[i][j]);
                            }
                            else
                            {
                                while (ch == pr[i][j])
                                {
                                    ch = Random.Range(1, ind[i][j]);
                                    mas[i][j] = ch;
                                    Debug.Log("[" + i + "][" + j + "]: " + mas[i][j] + " - Перегенерированное число " + tab[i][j]);
                                }
                            }
                        }
                    }
                }
                double[][] bl = new double[4][] {
                    new double[3],
                    new double[6],
                    new double[1],
                    new double[3]
                };
                double[][] jr = new double[4][] {
                    new double[3],
                    new double[6],
                    new double[1],
                    new double[3]
                };
                double[][] ug = new double[4][] {
                    new double[3],
                    new double[6],
                    new double[1],
                    new double[3]
                };
                double[][] ec = new double[4][] {
                    new double[3],
                    new double[6],
                    new double[1],
                    new double[3]
                };
                for (int i = 0; i < bl.Length; i++)
                {
                    for (int j = 0; j < bl[i].Length; j++)
                    {
                        string stol1 = "Belk";
                        string stol2 = "Jir";
                        string stol3 = "Ugl";
                        string stol4 = "ECen";
                        bl[i][j] = bjue(mas, i, j, stol1);
                        jr[i][j] = bjue(mas, i, j, stol2);
                        ug[i][j] = bjue(mas, i, j, stol3);
                        ec[i][j] = bjue(mas, i, j, stol4);
                    }
                }
                bls = bl[0][0] + bl[0][1] + bl[0][2] + bl[1][0] + bl[1][1] + bl[1][2] + bl[1][3] + bl[1][4] + bl[1][5] + bl[2][0] + bl[3][0] + bl[3][1] + bl[3][2];
                jrs = jr[0][0] + jr[0][1] + jr[0][2] + jr[1][0] + jr[1][1] + jr[1][2] + jr[1][3] + jr[1][4] + jr[1][5] + jr[2][0] + jr[3][0] + jr[3][1] + jr[3][2];
                ugs = ug[0][0] + ug[0][1] + ug[0][2] + ug[1][0] + ug[1][1] + ug[1][2] + ug[1][3] + ug[1][4] + ug[1][5] + ug[2][0] + ug[3][0] + ug[3][1] + ug[3][2];
                ecs = ec[0][0] + ec[0][1] + ec[0][2] + ec[1][0] + ec[1][1] + ec[1][2] + ec[1][3] + ec[1][4] + ec[1][5] + ec[2][0] + ec[3][0] + ec[3][1] + ec[3][2];
            } while ((bls < 40.0 || bls > 60.0) ||
                        (jrs < 40.0 || jrs > 60.0) ||
                        (ugs < 200.0 || ugs > 265.0) ||
                        (ecs < 1650.0 || ecs > 1900.0));
            Debug.Log("bl: " + bls + " jr: " + jrs + " ug: " + ugs + " ec: " + ecs);
        }
        //Функция вывода названия блюда
        void vivod(Text asap, Text hirup, Text polp, Text yorup, int[][] arr) 
        {
            string stol = "nameB";
            string[][] nameBlu = new string[4][] {
                new string[3],
                new string[6],
                new string[1],
                new string[3]
            };
            for (int i = 0; i < nameBlu.Length; i++) 
            {
                for (int j = 0; j < nameBlu[i].Length; j++) 
                {
                    nameBlu[i][j] = nameNa(arr, i, j, stol);
                }
            }
            asap.text = "[" + nameBlu[0][0].ToString() + "] \n" + "[" + nameBlu[0][1].ToString() + "] \n" + "[" + nameBlu[0][2].ToString() + "]";
            hirup.text = "[" + nameBlu[1][0].ToString() + "] \n" + "[" + nameBlu[1][1].ToString() + "] \n" + "[" + nameBlu[1][2].ToString() + "] \n" +
                            "[" + nameBlu[1][3].ToString() + "] \n" + "[" + nameBlu[1][4].ToString() + "] \n" + nameBlu[1][5].ToString();
            polp.text = nameBlu[2][0].ToString();
            yorup.text = "[" + nameBlu[3][0].ToString() + "] \n" + "[" + nameBlu[3][1].ToString() + "] \n" + "[" + nameBlu[3][2].ToString() + "]";
        }
        //Генерация первого дня
        double bls1, jrs1, ugs1, ecs1;
        do {
            for (int i = 0; i < day1.Length; i++)
            {
                for (int j = 0; j < day1[i].Length; j++)
                {
                    if (tab[i][j] == "Obed_Vt_dop" && Edb(day1, i, j - 1) == 1)
                    {
                        int ch = Random.Range(1, ind[i][j]);
                        day1[i][j] = ch;
                        Debug.Log("[" + i + "][" + j + "]: " + day1[i][j] + " " + tab[i][j]);
                    }
                    else if (tab[i][j] == "Obed_Vt_dop" && Edb(day1, i, j - 1) == 0)
                    {
                        day1[i][j] = 0;
                        continue;
                    }
                    else
                    {
                        int ch = Random.Range(1, ind[i][j]);
                        day1[i][j] = ch;
                        Debug.Log("[" + i + "][" + j + "]: " + day1[i][j] + " " + tab[i][j]);
                    }
                }
            }
            double[][] bl = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            double[][] jr = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            double[][] ug = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            double[][] ec = new double[4][] {
                new double[3],
                new double[6],
                new double[1],
                new double[3]
            };
            for (int i = 0; i < bl.Length; i++)
            {
                for (int j = 0; j < bl[i].Length; j++)
                {
                    string stol1 = "Belk";
                    string stol2 = "Jir";
                    string stol3 = "Ugl";
                    string stol4 = "ECen";
                    bl[i][j] = bjue(day1, i, j, stol1);
                    jr[i][j] = bjue(day1, i, j, stol2);
                    ug[i][j] = bjue(day1, i, j, stol3);
                    ec[i][j] = bjue(day1, i, j, stol4);
                }
            }
            bls1 = bl[0][0] + bl[0][1] + bl[0][2] + bl[1][0] + bl[1][1] + bl[1][2] + bl[1][3] + bl[1][4] + bl[1][5] + bl[2][0] + bl[3][0] + bl[3][1] + bl[3][2];
            jrs1 = jr[0][0] + jr[0][1] + jr[0][2] + jr[1][0] + jr[1][1] + jr[1][2] + jr[1][3] + jr[1][4] + jr[1][5] + jr[2][0] + jr[3][0] + jr[3][1] + jr[3][2];
            ugs1 = ug[0][0] + ug[0][1] + ug[0][2] + ug[1][0] + ug[1][1] + ug[1][2] + ug[1][3] + ug[1][4] + ug[1][5] + ug[2][0] + ug[3][0] + ug[3][1] + ug[3][2];
            ecs1 = ec[0][0] + ec[0][1] + ec[0][2] + ec[1][0] + ec[1][1] + ec[1][2] + ec[1][3] + ec[1][4] + ec[1][5] + ec[2][0] + ec[3][0] + ec[3][1] + ec[3][2];
        } while ((bls1 < 30.0 || bls1 > 65.0) ||
                        (jrs1 < 35.0 || jrs1 > 70.0) ||
                        (ugs1 < 203.0 || ugs1 > 265.0) ||
                        (ecs1 < 1650.0 || ecs1 > 1900.0));
        Debug.Log("bl: " + bls1 + " jr: " + jrs1 + " ug: " + ugs1 + " ec: " + ecs1);
        //генерация остальных дней
        znac(day2, day1);
        znac(day3, day2);
        znac(day4, day3);
        znac(day5, day4);
        prodsch(day1, day2, day3, day4, day5, prodsum1);
        znac(day6, day5);
        znac(day7, day6);
        znac(day8, day7);
        znac(day9, day8);
        znac(day10, day9);
        prodsch(day6, day7, day8, day9, day10, prodsum2);
        /*
        while (prodsum1[0] != 0.95 || prodsum1[1] != 3 || prodsum1[2] != 624.65 || prodsum1[3] != 0 || prodsum1[4] != 116.95 ||
                prodsum1[5] != 7.8 || prodsum1[6] != 187.85 || prodsum1[7] != 68.6 || prodsum1[8] != 91.05 || prodsum1[9] != 48.2 ||
                prodsum1[10] != 1432.75 || prodsum1[11] != 12.6 || prodsum1[12] != 168 || prodsum1[13] != 210.75 || prodsum1[14] != 695.8 ||
                prodsum1[15] != 108.35 || prodsum1[16] != 118.75 || prodsum1[17] != 263.2 || prodsum1[18] != 42.2 || prodsum1[19] != 200 ||
                prodsum1[20] != 15.55 || prodsum1[21] != 28.5 || prodsum1[22] != 142.25 || prodsum1[23] != 291.4 || prodsum1[24] != 41.55 ||
                prodsum1[25] != 356.45 || prodsum1[26] != 100 || prodsum1[27] != 1.7 || prodsum1[28] != 100.05);
        */
        vivod(d1asa, d1hiru, d1pol, d1yoru, day1);
        vivod(d2asa, d2hiru, d2pol, d2yoru, day2);
        vivod(d3asa, d3hiru, d3pol, d3yoru, day3);
        vivod(d4asa, d4hiru, d4pol, d4yoru, day4);
        vivod(d5asa, d5hiru, d5pol, d5yoru, day5);
        vivod(d6asa, d6hiru, d6pol, d6yoru, day6);
        vivod(d7asa, d7hiru, d7pol, d7yoru, day7);
        vivod(d8asa, d8hiru, d8pol, d8yoru, day8);
        vivod(d9asa, d9hiru, d9pol, d9yoru, day9);
        vivod(d10asa, d10hiru, d10pol, d10yoru, day10);
        prsum1.text = prodsum1[0] + "\n" + prodsum1[1] + "\n" + prodsum1[2] + "\n" + prodsum1[3] + "\n"
                        + prodsum1[4] + "\n" + prodsum1[5] + "\n" + prodsum1[6] + "\n" + prodsum1[7] + "\n"
                        + prodsum1[8] + "\n" + prodsum1[9] + "\n" + prodsum1[10] + "\n"
                        + prodsum1[11] + "\n" + prodsum1[12] + "\n" + prodsum1[13] + "\n" + prodsum1[14] + "\n"
                        + prodsum1[15] + "\n" + prodsum1[16] + "\n" + prodsum1[17] + "\n" + prodsum1[18] + "\n"
                        + prodsum1[19] + "\n" + prodsum1[20] + "\n" + prodsum1[21] + "\n" + prodsum1[22] + "\n"
                        + prodsum1[23] + "\n" + prodsum1[24] + "\n" + prodsum1[25] + "\n" + prodsum1[26] + "\n"
                        + prodsum1[27] + "\n" + prodsum1[28];
        prsum2.text = prodsum2[0] + "\n" + prodsum2[1] + "\n" + prodsum2[2] + "\n" + prodsum2[3] + "\n"
                        + prodsum2[4] + "\n" + prodsum2[5] + "\n" + prodsum2[6] + "\n" + prodsum2[7] + "\n"
                        + prodsum2[8] + "\n" + prodsum2[9] + "\n" + prodsum2[10] + "\n"
                        + prodsum2[11] + "\n" + prodsum2[12] + "\n" + prodsum2[13] + "\n" + prodsum2[14] + "\n"
                        + prodsum2[15] + "\n" + prodsum2[16] + "\n" + prodsum2[17] + "\n" + prodsum2[18] + "\n"
                        + prodsum2[19] + "\n" + prodsum2[20] + "\n" + prodsum2[21] + "\n" + prodsum2[22] + "\n"
                        + prodsum2[23] + "\n" + prodsum2[24] + "\n" + prodsum2[25] + "\n" + prodsum2[26] + "\n"
                        + prodsum2[27] + "\n" + prodsum2[28];
        dbcon.Close();
    }
}