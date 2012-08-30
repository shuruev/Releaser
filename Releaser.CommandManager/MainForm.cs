using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Releaser.CommandManager.Layout;
using Releaser.Core.Client;
using Releaser.Core.Events;
using ServiceStack.Text;

namespace Releaser.CommandManager
{
	public partial class MainForm : Form
	{
		private const int c_pageSize = 100;
		private int m_pageNumber = 1;
		private int m_totalEvents;
		private readonly EngineClient m_engine;
		private readonly LimitedRevertedList<BaseEvent> m_events = new LimitedRevertedList<BaseEvent>(5000);

		public delegate void EventsUpdatedHandler();

		private event EventsUpdatedHandler EventsUpdated;

		public MainForm()
		{
			InitializeComponent();

			var enginePath = ConfigurationManager.AppSettings["EngineUrl"];
			m_engine = new EngineClient(enginePath);

			EventsUpdated += UpdateEventList;
			EventsUpdated += UpdateTotalPages;

			LayoutManager.Load<SimpleLayout>(this, Settings.Default, "MainFormLayout");
		}

		#region Forms event handlers

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadEvents();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			LayoutManager.Save<SimpleLayout>(this, Settings.Default, "MainFormLayout");
			Settings.Default.Save();
		}

		private void numPage_ValueChanged(object sender, EventArgs e)
		{
			m_pageNumber = Convert.ToInt32(numPage.Value);
			UpdateEventList();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadEvents();
		}

		private void listEvents_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listEvents.SelectedItems.Count > 0)
			{
				ListViewItem item = listEvents.SelectedItems[0];
				EventView eventView = new EventView((BaseEvent)item.Tag);
				eventView.ShowDialog(this);
			}
		}

		private void btnSendCommand_Click(object sender, EventArgs e)
		{
			SendCommand sendCommand = new SendCommand(m_engine);
			sendCommand.ShowDialog(this);
			LoadEvents();
		}

		#endregion

		private void LoadEvents()
		{
			textTotalEvents.Text = "Loading...";
			btnRefresh.Enabled = false;

			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += (o, args) =>
			{
				var events = m_engine.GetAllEvents();
				m_events.Clear();
				foreach (var @event in events)
				{
					m_events.Add(@event);
				}

				OnEventsUpdated();

				m_totalEvents = events.Count;
				m_pageNumber = 1;
				numPage.Value = m_pageNumber;
			};

			worker.RunWorkerCompleted += (o, args) =>
			{
				textTotalEvents.Text = m_totalEvents.ToString(CultureInfo.InvariantCulture);
				btnRefresh.Enabled = true;
			};
			worker.RunWorkerAsync();
		}

		private void UpdateEventList()
		{
			Invoke(new MethodInvoker(() =>
			{
				listEvents.BeginUpdate();
				listEvents.Items.Clear();
				int count = 1;

				foreach (var @event in m_events.Skip((m_pageNumber - 1) * c_pageSize).Take(c_pageSize))
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Tag = @event;
					lvi.Text = @event.Name;
					lvi.ToolTipText = JsonConvert.SerializeObject(@event, Formatting.Indented);
					lvi.BackColor = (count % 2 == 0) ? Color.Lavender : Color.White;

					lvi.SubItems.Add(@event.EventDate.ToString(Constants.DateFormat));
					lvi.SubItems.Add(JsonConvert.SerializeObject(@event));

					listEvents.Items.Add(lvi);

					count++;
				}

				listEvents.EndUpdate();
			}));
		}

		private void UpdateTotalPages()
		{
			Invoke(new MethodInvoker(() =>
			{
				int pages = m_events.Count / c_pageSize;
				lblTotalPages.Text = "of {0}".Fmt(pages);

				numPage.Maximum = pages;
			}));
		}

		#region Events

		private void OnEventsUpdated()
		{
			EventsUpdatedHandler handler = EventsUpdated;
			if (handler != null)
				handler();
		}

		#endregion
	}
}
