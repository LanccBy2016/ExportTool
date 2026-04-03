using System;
using System.Windows.Forms;

namespace ExportTool
{
    public partial class ConnectionForm : Form
    {
        public DatabaseConnection Connection { get; set; }

        public ConnectionForm()
        {
            InitializeComponent();
            Connection = new DatabaseConnection();
            typeComboBox.DataSource = Enum.GetValues(typeof(DatabaseConnection.DatabaseType));
        }

        public ConnectionForm(DatabaseConnection connection)
        {
            InitializeComponent();
            Connection = connection;
            typeComboBox.DataSource = Enum.GetValues(typeof(DatabaseConnection.DatabaseType));
            nameTextBox.Text = connection.Name;
            serverTextBox.Text = connection.Server;
            databaseTextBox.Text = connection.Database;
            usernameTextBox.Text = connection.Username;
            passwordTextBox.Text = connection.Password;
            portTextBox.Text = connection.Port;
            typeComboBox.SelectedItem = connection.Type;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Connection.Name = nameTextBox.Text;
            Connection.Server = serverTextBox.Text;
            Connection.Database = databaseTextBox.Text;
            Connection.Username = usernameTextBox.Text;
            Connection.Password = passwordTextBox.Text;
            Connection.Port = portTextBox.Text;
            Connection.Type = (DatabaseConnection.DatabaseType)typeComboBox.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
