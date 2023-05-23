using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public static class ScoreManager
{
	public static void CheckFile()
	{
        if (!File.Exists("../../score.txt")) File.Create("../../score.txt");
    }

    public static List<int> GetScores()
    {
        string[] x = File.ReadAllLines("../../score.txt");
        List<int> ints = new();

        foreach (var item in x)
        {
            ints.Add(Convert.ToInt32(item));
        }
        ints.Sort();
        ints.Reverse();
        

        return ints;
    }

    public static void SaveScore(int score) 
    {
        string[] x = {score.ToString()};
        File.AppendAllLines ("../../score.txt", x);
    }

}
