using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjectStellar.Library
{
    public static class Save
    {

        public static List<SaveGameMetadata> List()
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream saveListFile;
            List<SaveGameMetadata> saveList;

            try
            {
                saveListFile = File.OpenRead(@"./saves/list.bin");
                saveList = (List<SaveGameMetadata>)formatter.Deserialize(saveListFile);
                saveListFile.Close();
                return saveList;
            }
            catch (Exception e)
            {
                saveListFile = File.Create(@"./saves/list.bin");
                formatter.Serialize(saveListFile, new List<SaveGameMetadata>());
                saveListFile.Close();
                return (new List<SaveGameMetadata>());
            }
        }

        public static void SaveGame(SaveGame saveGame, string name)
        {
            IFormatter formatter = new BinaryFormatter();
            List<SaveGameMetadata> saveList = List();
            bool saveExists = false;
            SaveGameMetadata newSaveMetadata;
            Stream file;
            string savePath = @"./saves/" + name + ".sav";
            string listPath = @"./saves/list.bin";

            foreach (SaveGameMetadata metadata in saveList)
            {
                if (metadata.Name == name)
                {
                    metadata.Date = saveGame.Date;
                    metadata.Population = saveGame.Population;
                    saveExists = true;
                    break;
                }
            }

            if (!saveExists)
            {
                newSaveMetadata = new SaveGameMetadata(name, saveGame.Date, saveGame.Population);
                saveList.Add(newSaveMetadata);
                file = File.OpenWrite(listPath);
                formatter.Serialize(file, saveList);
                file.Close();
            }

            file = File.OpenWrite(savePath);
            formatter.Serialize(file, saveGame);
            file.Close();
        }

        public static SaveGame LoadGame(string name)
        {
            string filePath = @"./saves/" + name + ".sav";
            IFormatter formatter = new BinaryFormatter();
            SaveGame saveGame;
            Stream file;

            file = File.OpenRead(filePath);
            saveGame = (SaveGame) formatter.Deserialize(file);
            file.Close();

            return saveGame;
        }
    }
}
