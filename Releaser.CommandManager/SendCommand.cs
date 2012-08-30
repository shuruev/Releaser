using System;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Releaser.Core.Client;
using Releaser.Core.Commands;
using ServiceStack.Text;

namespace Releaser.CommandManager
{
	public partial class SendCommand : Form
	{
		private readonly EngineClient m_client;

		public class ComboboxItem
		{
			public string Text { get; set; }

			public Type Type { get; set; }

			public override string ToString()
			{
				return Text;
			}
		}

		public SendCommand(EngineClient client)
		{
			m_client = client;
			InitializeComponent();

			InitializeCommandTypes();
		}

		private void InitializeCommandTypes()
		{
			var commandType = typeof(BaseCommand);
			var commandTypes = AppDomain.CurrentDomain
				.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => commandType.IsAssignableFrom(p) && p != commandType)
				.ToList();

			foreach (var type in commandTypes)
			{
				var item = new ComboboxItem();
				item.Text = type.FullName;
				item.Type = type;

				cmbCommandTypes.Items.Add(item);
			}

			if (cmbCommandTypes.Items.Count > 0)
				cmbCommandTypes.SelectedIndex = 0;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			var commandType = ((ComboboxItem)cmbCommandTypes.SelectedItem).Type;
			BaseCommand command;
			try
			{
				command = (BaseCommand)JsonConvert.DeserializeObject(textJson.Text, commandType);
			}
			catch(Exception ex)
			{
				MessageBox.Show(
					"Cannot parse JSON: {0}".Fmt(ex.Message),
					"Wrong JSON",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			m_client.SendCommand(command);
			Close();
		}

		private void cmbCommandTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			var commandType = ((ComboboxItem)cmbCommandTypes.SelectedItem).Type;
			var command = Activator.CreateInstance(commandType);
			textJson.Text = JsonConvert.SerializeObject(command, Formatting.Indented);
		}
	}
}
