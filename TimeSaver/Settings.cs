using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace TimeSaver
{
    /// <summary>
    /// Contains the settings of the screensaver.
    /// </summary>
    [Serializable]
    [XmlRoot("TimeSaverSettings")]
    public class Settings : IXmlSerializable
    {
        #region Singleton Thread-Safety

        /// <summary>
        /// Singleton class for thread-safe use of the Settings
        /// </summary>
        private class Singleton
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Singleton()
            {
            }

            internal static readonly Settings s_instance = new Settings();
        }

        /// <summary>
        /// Gets the Settings instance.
        /// </summary>
        public static Settings Instance
        {
            get { return Singleton.s_instance; }
        }

        #endregion // Singleton Thread-Safety

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
            TextColor = Color.White;
            BackColor = Color.FromArgb(14, 14, 14);
            DisplayMode = DisplayMode.OnlyOnPrimaryMonitor;
            BlinkTimeSeparator = true;
            UseUpperCase = true;

            // xml serializer
            m_serializer = new XmlSerializer(typeof(Settings));
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        public void Load()
        {
            if (!File.Exists(FilePath))
                return;

            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    Settings settings = m_serializer.Deserialize(fs) as Settings;

                    // copy the settings into this class
                    TextColor = settings.TextColor;
                    BackColor = settings.BackColor;
                    DisplayMode = settings.DisplayMode;
                    BlinkTimeSeparator = settings.BlinkTimeSeparator;
                    UseUpperCase = settings.UseUpperCase;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Saves thie settings.
        /// </summary>
        public void Save()
        {
            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
                    m_serializer.Serialize(fs, this);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        [XmlElement("TextColor")]
        public Color TextColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        [XmlElement("BackColor")]
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the display mode.
        /// </summary>
        /// <value>The display mode.</value>
        [XmlElement("DisplayMode")]
        public DisplayMode DisplayMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to blink with the time separator.
        /// </summary>
        /// <value>
        /// <c>true</c> to blink with the time separator; otherwise, <c>false</c>.
        /// </value>
        [XmlElement("BlinkTimeSeparator")]
        public bool BlinkTimeSeparator { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display the text in upper case.
        /// </summary>
        /// <value>
        /// <c>true</c> to display the text in upper case; otherwise, <c>false</c>.
        /// </value>
        [XmlElement("UseUpperCase")]
        public bool UseUpperCase { get; set; }

        /// <summary>
        /// Gets the path of the settings file.
        /// </summary>
        /// <value>The file path.</value>
        [XmlIgnore]
        private string FilePath
        {
            get 
            {
                if (m_filePath == null)
                {
                    m_filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    if (!m_filePath.EndsWith(@"\"))
                        m_filePath += @"\";
                    m_filePath += Application.ProductName;

                    // create directory
                    Directory.CreateDirectory(m_filePath);

                    // append filename
                    m_filePath += @"\Settings.xml";
                }

                return m_filePath; 
            }
        }

        #region IXmlSerializable Members

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized.</param>
        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            ColorConverter conv = new ColorConverter();

            while (reader.Read())
            {
                // end element
                if (reader.NodeType == System.Xml.XmlNodeType.EndElement &&
                    reader.Name == "TimeSaverSettings")
                    break;

                if (reader.NodeType == System.Xml.XmlNodeType.Element &&
                    !reader.IsEmptyElement)
                {
                    string text = reader.ReadString();
                    switch (reader.Name)
                    {
                        case "TextColor":
                            TextColor = (Color)conv.ConvertFromInvariantString(text);
                            break;

                        case "BackColor":
                            BackColor = (Color)conv.ConvertFromInvariantString(text);
                            break;

                        case "DisplayMode":
                            if (Enum.IsDefined(typeof(DisplayMode), text))
                                DisplayMode = (DisplayMode)Enum.Parse(typeof(DisplayMode), text, true);
                            break;

                        case "BlinkTimeSeparator":
                            bool blink;
                            if (bool.TryParse(text, out blink))
                                BlinkTimeSeparator = blink;
                            break;

                        case "UseUpperCase":
                            bool upperCase;
                            if (bool.TryParse(text, out upperCase))
                                UseUpperCase = upperCase;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized.</param>
        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            ColorConverter conv = new ColorConverter();

            writer.WriteElementString("TextColor", conv.ConvertToInvariantString(TextColor));
            writer.WriteElementString("BackColor", conv.ConvertToInvariantString(BackColor));
            writer.WriteElementString("DisplayMode", DisplayMode.ToString("G"));
            writer.WriteElementString("BlinkTimeSeparator", BlinkTimeSeparator.ToString());
            writer.WriteElementString("UseUpperCase", UseUpperCase.ToString());
        }

        #endregion

        // private variables
        private string m_filePath = null;
        private XmlSerializer m_serializer = null;
    }
}
