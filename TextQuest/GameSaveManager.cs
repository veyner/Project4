using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class GameSaveManager
    {
        /* 1. Взять список сохранений
         * 2. Взять сохранение
         * 3. Сохранить
            Отдельный файл под каждое сохранение
             */

        /// <summary>
        /// Проверка наличия и создание папки сохранений; Получение списка сохранений квеста
        /// </summary>
        /// <param name="PathToTheSaves">Путь к сохранениям</param>
        /// <returns>Список сохранений</returns>
        public List<GameState> GetSaves(string PathToTheSaves)
        {
            if (!Directory.Exists(PathToTheSaves))
            {
                Directory.CreateDirectory(PathToTheSaves);
            }

            var saveList = new List<GameState>();
            var saveFiles = Directory.GetFiles(PathToTheSaves);
            foreach (var save in saveFiles)
            {
                var i = LoadSave(Path.GetFileName(save));
                saveList.Add(i);
            }
            return saveList;
        }

        /// <summary>
        /// Загрузка сохранения квеста
        /// </summary>
        /// <param name="savePath">путь к сохранению</param>
        /// <returns>Сохранение</returns>
        public GameState LoadSave(string savePath)
        {
            var fullSavePath = Path.Combine(Properties.Settings.Default.PathToSaves, savePath);
            // TODO: Проверить существование файла и не пустой ли он
            // TODO: Вынести save.json либо в константы либо в properties приложения
            using (var reader = new StreamReader(fullSavePath))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<GameState>(json);
            }
        }

        /// <summary>
        /// Сохранение игры
        /// </summary>
        /// <param name="gameState">на какой арке и на каком экране игра сохранена</param>
        public void SaveGame(GameState gameState)
        {
            var fullSavePath = Path.Combine(Properties.Settings.Default.PathToSaves, gameState.Name + ".json");
            // TODO: Вынести save.json либо в константы либо в properties приложения
            using (var writer = new StreamWriter(fullSavePath))
            {
                var json = JsonConvert.SerializeObject(gameState);
                writer.Write(json);
            }
        }
    }
}