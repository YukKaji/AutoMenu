using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class test : MonoBehaviour
{
    public Text d1asa;
    public Text d1hiru;
    public Text d1pol;
    public Text d1yoru;
    public Text d2asa;
    public Text d2hiru;
    public Text d2pol;
    public Text d2yoru;
    public Text d3asa;
    public Text d3hiru;
    public Text d3pol;
    public Text d3yoru;

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

        string connectionString = "URI=file:" + Application.dataPath + "/StreamingAssets/omgw.db";
        IDbConnection dbcon = new SqliteConnection(connectionString);
        dbcon.Open();
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
            } while ( (bls < 30.0 || bls > 65.0) || 
                        (jrs < 35.0 || jrs > 70.0) || 
                        (ugs < 203.0 || ugs > 265.0) || 
                        (ecs < 1650.0 || ecs > 1900.0));
            Debug.Log("bl: " + bls + " jr: " + jrs + " ug: " + ugs + " ec: " + ecs);
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
        //Функция подсчета продуктов
        void prodsch(int[][] d1, int[][] d2, int[][] d3, int[][] d4, int[][] d5) 
        {
            string[] prod = { "DrHlep", "KakP", "Kart", "Kolbasa", "Konditer", "Kofe",
                            "KrupiBob", "Makaroni", "MasloSliv", "MasloRast", "MolokoIKis", "MukaKart",
                            "MukaPshen", "Myaso", "Ovosh", "Ptica", "Riba", "Sahar",
                            "Smetana", "Soki", "Sol", "Sir", "Tvorog", "FruktiSvez",
                            "FruktiSuh", "HlepPshen", "HlepRz", "Chay", "Yayco" };
            double[] prodsum = new double[29];
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
                        prodsum[i] = prodsum[i] + promej1[j][k] + promej2[j][k] + promej3[j][k] + promej4[j][k] + promej5[j][k];
                    }
                }
            }
            for (int i = 0; i < prodsum.Length; i++)
            {
                Debug.Log(prod[i] + " = " + prodsum[i]);
            }
        }

        //Генерация первого дня и других
        double bls1, jrs1, ugs1, ecs1;
        do
        {
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
        znac(day2, day1);
        znac(day3, day2);
        znac(day4, day3);
        znac(day5, day4);
        prodsch(day1, day2, day3, day4, day5);
        znac(day6, day5);
        znac(day7, day6);
        znac(day8, day7);
        znac(day9, day8);
        znac(day10, day9);
        prodsch(day6, day7, day8, day9, day10);
        /*
        d1asa.text = week1[0][0, 0].ToString() + "\n" + week1[0][0, 1].ToString() + "\n" + week1[0][0, 2].ToString();
        d1hiru.text = week1[0][1, 0].ToString() + "\n" + week1[0][1, 1].ToString() + "\n" + week1[0][1, 2].ToString();
        d1pol.text = week1[0][2, 0].ToString() + "\n" + week1[0][2, 1].ToString() + "\n" + week1[0][2, 2].ToString();
        d1yoru.text = week1[0][3, 0].ToString() + "\n" + week1[0][3, 1].ToString() + "\n" + week1[0][3, 2].ToString();

        d2asa.text = week1[1][0, 0].ToString() + "\n" + week1[1][0, 1].ToString() + "\n" + week1[1][0, 2].ToString();
        d2hiru.text = week1[1][1, 0].ToString() + "\n" + week1[1][1, 1].ToString() + "\n" + week1[1][1, 2].ToString();
        d2pol.text = week1[1][2, 0].ToString() + "\n" + week1[1][2, 1].ToString() + "\n" + week1[1][2, 2].ToString();
        d2yoru.text = week1[1][3, 0].ToString() + "\n" + week1[1][3, 1].ToString() + "\n" + week1[1][3, 2].ToString();

        d3asa.text = week1[2][0, 0].ToString() + "\n" + week1[2][0, 1].ToString() + "\n" + week1[2][0, 2].ToString();
        d3hiru.text = week1[2][1, 0].ToString() + "\n" + week1[2][1, 1].ToString() + "\n" + week1[2][1, 2].ToString();
        d3pol.text = week1[2][2, 0].ToString() + "\n" + week1[2][2, 1].ToString() + "\n" + week1[2][2, 2].ToString();
        d3yoru.text = week1[2][3, 0].ToString() + "\n" + week1[2][3, 1].ToString() + "\n" + week1[2][3, 2].ToString();
        */
        dbcon.Close();
    }
}