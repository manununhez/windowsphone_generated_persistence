using System.IO;
using System.Xml.Serialization;
using Windows.Storage;

namespace WindowsStore.Common.Storage
{
    public class StorageManager
    {
        /// <summary>
        /// Initializes a new instance of the  <see cref="StorageManager" /> class.
        /// As the LocalSettings is divided in containers the constructor needs the key of the container to use.
        /// </summary>
        /// <param name="containerKey">The key.</param>
        /// <param name="isRoaming">if set to <c>true</c> [is roaming].</param>
        public StorageManager(string containerKey, bool isRoaming)
        {
            if (isRoaming)
            {
                InitializeRoamingAppContainer(containerKey);
            }
            else
            {
                InitializeLocalAppContainer(containerKey);
            }
        }

        /// <summary>
        /// Determines whether the local storage contains an object associated to the specified key.
        /// </summary>
        public bool Contains(string key)
        {
            return AppSettingsContainer.Values.ContainsKey(key);
        }

        /// <summary>
        /// Saves the specified object associated to the specified key.
        /// </summary>
        public void Save(string key, object value)
        {
            var serializedValue = XMLSerializer.SerializeToString(value);

            if (AppSettingsContainer.Values.ContainsKey(key))
            {
                AppSettingsContainer.Values[key] = serializedValue;
            }
            else
            {
                AppSettingsContainer.Values.Add(key, serializedValue);
            }
        }

        /// <summary>
        /// Loads an object associated to the specified key.
        /// </summary>
        public T Load<T>(string key)
        {
            if (AppSettingsContainer.Values.ContainsKey(key))
            {
                return XMLSerializer.DeserializeFromString<T>(AppSettingsContainer.Values[key].ToString());
            }

            return default(T);
        }

        /// <summary>
        /// Removes the object associated to the specified key.
        /// </summary>
        public bool Remove(string key)
        {
            if (AppSettingsContainer.Values.ContainsKey(key))
            {
                return AppSettingsContainer.Values.Remove(key);
            }
            return false;
        }

        #region privates

        /// <summary>
        /// Initializes a roaming application container.
        /// </summary>
        /// <param name="containerKey">The container key.</param>
        private void InitializeRoamingAppContainer(string containerKey)
        {
            // todo RoamingQuota
            if (!ApplicationData.Current.RoamingSettings.Containers.ContainsKey(containerKey))
            {
                ApplicationData.Current.RoamingSettings.CreateContainer(containerKey,
                    ApplicationDataCreateDisposition.Always);
            }

            this.AppSettingsContainer = ApplicationData.Current.RoamingSettings.Containers[containerKey];
        }

        /// <summary>
        /// Initializes a local application container.
        /// </summary>
        /// <param name="containerKey">The container key.</param>
        private void InitializeLocalAppContainer(string containerKey)
        {
            if (!ApplicationData.Current.LocalSettings.Containers.ContainsKey(containerKey))
            {
                ApplicationData.Current.LocalSettings.CreateContainer(containerKey,
                    ApplicationDataCreateDisposition.Always);
            }

            this.AppSettingsContainer = ApplicationData.Current.LocalSettings.Containers[containerKey];
        }

        private async void clearLocalData()
        {
            ApplicationData.Current.ClearAsync();
        }

        /// <summary>
        /// Gets or sets the application settings container.
        /// </summary>
        private ApplicationDataContainer AppSettingsContainer { get; set; }

        #endregion

        public static class XMLSerializer
        {
            /// <summary>
            /// Serializes an object to string using XML.
            /// </summary>
            /// <param name="obj">The object.</param>
            public static string SerializeToString(object obj)
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, obj);
                    return writer.ToString();
                }
            }

            /// <summary>
            /// De-serializes an object from XML string.
            /// </summary>
            /// <typeparam name="T">Type of the object to deserialize</typeparam>
            /// <param name="xml">The XML.</param>
            public static T DeserializeFromString<T>(string xml)
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                using (StringReader reader = new StringReader(xml))
                {
                    return (T)deserializer.Deserialize(reader);
                }
            }
        }

    }
}
