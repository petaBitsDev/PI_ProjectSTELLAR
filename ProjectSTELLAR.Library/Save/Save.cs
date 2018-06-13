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
        static string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ProjectStellar/";
        static string _list = "list.bin";
        static string _ext = ".sav";

        public static List<SaveGameMetadata> List()
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream saveListFile;
            List<SaveGameMetadata> saveList;
            Directory.CreateDirectory(_path);

            try
            {
                saveListFile = File.OpenRead(_path + _list);
                saveList = (List<SaveGameMetadata>)formatter.Deserialize(saveListFile);
                saveListFile.Close();
                return saveList;
            }
            catch (Exception e)
            {
                saveListFile = File.Create(_path + _list);
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
            string savePath = _path + name + _ext;

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
            }
            file = File.OpenWrite(_path + _list);
            formatter.Serialize(file, saveList);
            file.Close();

            file = File.OpenWrite(savePath);
            formatter.Serialize(file, saveGame);
            file.Close();
        }

        public static SaveGame LoadGame(string name)
        {
            string filePath = _path + name + _ext;
            IFormatter formatter = new BinaryFormatter();
            SaveGame saveGame;
            Stream file;

            file = File.OpenRead(filePath);
            saveGame = (SaveGame) formatter.Deserialize(file);
            file.Close();

            return saveGame;
        }

        public static bool DeleteSave(string name)
        {
            string filePath = _path + _list;
            IFormatter formatter = new BinaryFormatter();
            Stream file;
            List<SaveGameMetadata> list = List();
            SaveGame saveGame;
            try
            {
                foreach(SaveGameMetadata saveMetadata in list)
                {
                    if (saveMetadata.Name == name)
                    {
                        list.Remove(saveMetadata);
                        File.Delete(_path + name + _ext);
                        file = File.OpenWrite(_path + _list);
                        formatter.Serialize(file, list);
                        file.Close();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
