using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MGSC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace QM_TweaksPack
{
    public class ModConfig
    {
        [JsonIgnore]
        public bool DebugLog { get; set; } = false;

        [JsonIgnore]
        public bool CompanionsFollowFloors { get; set; } = true;

        [JsonIgnore]
        public bool CameraOrbitPlanet { get; set; } = true;

        // MCM Related Start

        public void LoadConfigMCM(string configPath)
        {
            if (File.Exists(configPath))
            {
                string[] array = File.ReadAllLines(configPath);
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i].Trim();
                    if (text.Contains('='))
                    {
                        string[] array2 = text.Split(new char[]
                        {
                            '='
                        }, 2);
                        string name = array2[0].Trim();
                        string value = array2[1].Trim();
                        object value2 = this.ConvertValue(value);

                        Plugin.Logger.Log($"name: {name}, value: {value.ToString()}, value: {value2.ToString()}");


                        PropertyInfo property = base.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                        if (property != null)
                        {
                            property.SetValue(this, value2, null);
                        }
                        else
                        {
                            throw new Exception("Property not found LoadConfigMCM configPath: " + name);
                        }
                    }
                }
            }
        }

        public void LoadConfigMCM(Dictionary<string, object> propertiesDictionary)
        {
            foreach (KeyValuePair<string, object> keyValuePair in propertiesDictionary)
            {
                PropertyInfo property = base.GetType().GetProperty(keyValuePair.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                if (property != null)
                {
                    property.SetValue(this, Convert.ChangeType(keyValuePair.Value, property.PropertyType), null);
                }
                else
                {
                    throw new Exception("Property not found LoadConfigMCM propertiesDictionary: " + keyValuePair.Key);
                }
            }
        }

        private object ConvertValue(string value)
        {
            int num;
            if (int.TryParse(value, out num))
            {
                return num;
            }
            float num2;
            if (float.TryParse(value, out num2))
            {
                return num2;
            }
            bool flag;
            if (bool.TryParse(value, out flag))
            {
                return flag;
            }
            Color color;
            if (ColorUtility.TryParseHtmlString(value.Replace("\"", string.Empty), out color))
            {
                return color;
            }
            return value;
        }

        // MCM Related End

        // We don't use json config so for now we dont need this.
        public static ModConfig LoadConfig(string configPath)
        {
            ModConfig config;

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            Plugin.Logger.Log("ModConfig JSON Loading config from " + configPath);
            Plugin.Logger.Log("File.Exists " + File.Exists(configPath));

            if (File.Exists(configPath))
            {

                Plugin.Logger.Log("JSON Loading config from " + configPath);

                try
                {
                    string sourceJson = File.ReadAllText(configPath);

                    config = JsonConvert.DeserializeObject<ModConfig>(sourceJson, serializerSettings);

                    //Add any new elements that have been added since the last mod version the user had.
                    string upgradeConfig = JsonConvert.SerializeObject(config, serializerSettings);

                    if (upgradeConfig != sourceJson)
                    {
                        Plugin.Logger.Log("Updating config with missing elements");
                        //re-write
                        File.WriteAllText(configPath, upgradeConfig);
                    }

                    return config;
                }
                catch (Exception ex)
                {
                    Plugin.Logger.LogError("Error parsing configuration.  Ignoring config file and using defaults");
                    Plugin.Logger.LogException(ex);

                    //Not overwriting in case the user just made a typo.
                    config = new ModConfig();
                    return config;
                }
            }
            else
            {
                config = new ModConfig();

                string json = JsonConvert.SerializeObject(config, serializerSettings);
                File.WriteAllText(configPath, json);

                return config;
            }
        }
    }
}