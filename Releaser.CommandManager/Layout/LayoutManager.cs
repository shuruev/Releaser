using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Releaser.CommandManager.Layout
{
	/// <summary>
	/// Provides layout saving for windows forms.
	/// </summary>
	public class LayoutManager
	{
		/// <summary>
		/// Loads layout for specified form.
		/// </summary>
		public static void Load<T>(
			Form form,
			ApplicationSettingsBase settings,
			string settingName) where T : class, ILayoutHolder, new()
		{
			T layout = Read<T>(settings, settingName);
			if (layout == null)
				return;

			layout.SetLayout(form);
		}

		/// <summary>
		/// Saves layout for specified form.
		/// </summary>
		public static void Save<T>(
			Form form,
			ApplicationSettingsBase settings,
			string settingName) where T : class, ILayoutHolder, new()
		{
			T layout = Read<T>(settings, settingName);
			if (layout == null)
				layout = new T();

			layout.GetLayout(form);

			Write(layout, settings, settingName);
		}

		/// <summary>
		/// Reads layout from settings.
		/// </summary>
		private static T Read<T>(
			SettingsBase settings,
			string settingName) where T : class, ILayoutHolder, new()
		{
			string xml = (string)settings[settingName];
			if (!String.IsNullOrEmpty(xml))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				using (StringReader sr = new StringReader(xml))
				{
					try
					{
						return (T)serializer.Deserialize(sr);
					}
					catch
					{
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Writes specified layout to settings.
		/// </summary>
		private static void Write<T>(
			T layout,
			SettingsBase settings,
			string settingName) where T : class, ILayoutHolder, new()
		{
			StringBuilder xml = new StringBuilder();
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (StringWriter sw = new StringWriter(xml))
			{
				serializer.Serialize(sw, layout);
			}

			settings[settingName] = xml.ToString();
		}
	}
}
