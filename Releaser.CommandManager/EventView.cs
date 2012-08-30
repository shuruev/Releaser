using System.Windows.Forms;
using Newtonsoft.Json;
using Releaser.Core.Events;
using ServiceStack.Text;

namespace Releaser.CommandManager
{
	public partial class EventView : Form
	{
		public EventView(BaseEvent @event)
		{
			InitializeComponent();

			textEventType.Text = @event.Name;
			textEventDate.Text = @event.EventDate.ToString(Constants.DateFormat);
			textJson.Text = JsonConvert.SerializeObject(@event, Formatting.Indented);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
