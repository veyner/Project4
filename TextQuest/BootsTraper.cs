using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TextQuest
{
    internal class Bootstraper
    {
        public List<Quest> Quests { get; set; }
        private string _questDirectory;

        /// <summary>
        /// создание квестовой директории
        /// </summary>
        /// <param name="questDirectory">путь к квестам</param>
        public Bootstraper(string questDirectory)
        {
            Quests = new List<Quest>();
            _questDirectory = questDirectory;
        }

        /// <summary>
        /// Проверка наличия папки и создание папки с квестами, считывание квестов
        /// </summary>
        public void Load()
        {
            if (!Directory.Exists(_questDirectory))
            {
                Directory.CreateDirectory(_questDirectory);
            }

            var fileList = Directory.GetFiles(_questDirectory);
            foreach (var file in fileList)
            {
                var i = LoadQuestData(file);
                Quests.Add(i);
            }
        }

        /// <summary>
        /// Считывается 1 квест из файла
        /// </summary>
        /// <param name="filePath">путь к файлу</param>
        /// <returns>квест</returns>
        private Quest LoadQuestData(string filePath)
        {
            // TODO: Проверить существование файла и не пустой ли он
            using (var reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Quest>(json);
            }
        }
    }
}