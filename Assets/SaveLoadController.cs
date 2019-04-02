using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadController{

	public static void SaveScore(int score)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/score.sav", FileMode.Create);

        Score data = new Score(score);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int LoadScore()
    {
        if(File.Exists(Application.persistentDataPath + "/score.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/score.sav", FileMode.Open);

            Score data = bf.Deserialize(stream) as Score;

            stream.Close();
            return data.score;
        }
        else
            return 0;
    }
}

[Serializable]
public class Score
    {
        public int score;

        public Score(int score)
        {
            this.score = score;
        }
    }