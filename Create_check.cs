using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FirstDB
{
	public partial class Create_check : Form
	{
		private SqlConnection sqlConnection = null;
		float sum = 0.0f;

		public Create_check()
		{
			InitializeComponent();
		}

		private void Create_check_Load(object sender, EventArgs e)
		{
			sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["popshopDB"].ConnectionString);

			sqlConnection.Open();

			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT NAME FROM [Category]", sqlConnection);

			DataSet categories = new DataSet();

			dataAdapter.Fill(categories);

			dataGridView2.DataSource = categories.Tables[0];
			///////
			dataAdapter.SelectCommand.CommandText = "SELECT NAME FROM [State]";

			DataSet states = new DataSet();

			dataAdapter.Fill(states);

			dataGridView3.DataSource = states.Tables[0];
			//////
			dataAdapter.SelectCommand.CommandText = "SELECT NAME, SURNAME FROM [Clients]";

			DataSet clients = new DataSet();

			dataAdapter.Fill(clients);

			dataGridView4.DataSource = clients.Tables[0];
		}

		private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				$"SELECT PRICE FROM [Category] WHERE NAME = @selected_category", sqlConnection);

			dataAdapter.SelectCommand.Parameters.AddWithValue("selected_category", dataGridView2.SelectedCells[0].Value);

			DataSet categories_price = new DataSet();

			dataAdapter.Fill(categories_price);

			dataAdapter.SelectCommand.CommandText = $"SELECT IMPACT FROM [State] WHERE NAME = @selected_state";

			dataAdapter.SelectCommand.Parameters.AddWithValue("selected_state", dataGridView3.SelectedCells[0].Value);

			DataSet state_impact = new DataSet();

			dataAdapter.Fill(state_impact);

			sum = float.Parse(categories_price.Tables[0].Rows[0][0].ToString()) + float.Parse(state_impact.Tables[0].Rows[0][0].ToString());

			label4.Text = $"Price: {sum}";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			float total_sum = 0.0f;
			dataGridView1.Rows.Add(dataGridView2.SelectedCells[0].Value, dataGridView3.SelectedCells[0].Value, sum);
			
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				total_sum += float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
				
			}
			label6.Text = $"Total price: {total_sum}";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				"INSERT INTO [Check] (ID_CLIENT) SELECT ID FROM [Clients] WHERE SURNAME = @selected_surname",
				sqlConnection);

			command.Parameters.AddWithValue("selected_surname", dataGridView4.SelectedRows[0].Cells[1].Value);

			command.ExecuteNonQuery();
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				command.Parameters.Clear();
				command.CommandText = $"INSERT INTO [Operation] (ID_CHECK, ID_CATEGORY, ID_STATE) SELECT MAX([Check].ID), [Category].ID, [State].Id FROM[Check], [Category], [State] WHERE[Category].NAME = @selected_category AND[State].NAME = @selected_state GROUP BY[Category].ID, [State].Id";

				command.Parameters.AddWithValue("selected_category", dataGridView1.Rows[i].Cells[0].Value);
				command.Parameters.AddWithValue("selected_state", dataGridView1.Rows[i].Cells[1].Value);
				command.ExecuteNonQuery();
			}

			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
		}
	}
}
