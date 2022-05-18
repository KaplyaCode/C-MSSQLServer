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
	public partial class Form1 : Form
	{
		private SqlConnection sqlConnection = null;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["popshopDB"].ConnectionString);

			sqlConnection.Open();

			button1_Click(sender, e);
			button2_Click(sender, e);
			button3_Click(sender, e);
			button4_Click(sender, e);
			button5_Click(sender, e);
		}


		private void button1_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT * FROM [Category]", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView1.DataSource = dataSet.Tables[0];
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT * FROM [Check]", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView2.DataSource = dataSet.Tables[0];
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT * FROM [Clients]", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView3.DataSource = dataSet.Tables[0];
		}

		private void button4_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT * FROM [Operation]", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView4.DataSource = dataSet.Tables[0];
		}

		private void button5_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT * FROM [State]", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView5.DataSource = dataSet.Tables[0];
		}

		private void button6_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				$"INSERT INTO [Category] (NAME, DESCRIPTION, PRICE) VALUES (@NAME, @DESCRIPTION, @PRICE)", 
				sqlConnection);

			float money = float.Parse(textBox3.Text);

			command.Parameters.AddWithValue("NAME", textBox1.Text);
			command.Parameters.AddWithValue("DESCRIPTION", textBox2.Text);
			command.Parameters.AddWithValue("PRICE", money);

			command.ExecuteNonQuery();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				$"DELETE FROM [Category] WHERE ID = @selected_id",
				sqlConnection);

			command.Parameters.AddWithValue("selected_id", Int32.Parse(dataGridView1.SelectedCells[0].Value.ToString()));

			command.ExecuteNonQuery();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				"UPDATE [Category] SET NAME = @new_name, DESCRIPTION = @new_description, PRICE = @new_price WHERE ID = @selected_id", 
				sqlConnection);

			float money = float.Parse(textBox3.Text);

			command.Parameters.AddWithValue("new_name", textBox1.Text);
			command.Parameters.AddWithValue("new_description", textBox2.Text);
			command.Parameters.AddWithValue("new_price", money);
			command.Parameters.AddWithValue("selected_id", Int32.Parse(dataGridView1.SelectedCells[0].Value.ToString()));

			command.ExecuteNonQuery();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				$"INSERT INTO [Clients] (NAME, SURNAME, PHONE, IDENTIFY, PASSPORT, AUTHORITY) VALUES (@NAME, @SURNAME, @PHONE, @IDENTIFY, @PASSPORT, @AUTHORITY)",
				sqlConnection);

			command.Parameters.AddWithValue("NAME", textBox4.Text);
			command.Parameters.AddWithValue("SURNAME", textBox5.Text);
			command.Parameters.AddWithValue("PHONE", textBox6.Text);
			command.Parameters.AddWithValue("IDENTIFY", textBox7.Text);
			command.Parameters.AddWithValue("PASSPORT", textBox8.Text);
			command.Parameters.AddWithValue("AUTHORITY", textBox9.Text);

			command.ExecuteNonQuery();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				$"DELETE FROM [Clients] WHERE ID = @selected_id",
				sqlConnection);

			command.Parameters.AddWithValue("selected_id", Int32.Parse(dataGridView3.SelectedCells[0].Value.ToString()));

			command.ExecuteNonQuery();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				"UPDATE [Clients] SET NAME = @NAME, SURNAME = @SURNAME, PHONE = @PHONE, IDENTIFY = @IDENTIFY, PASSPORT = @PASSPORT, AUTHORITY = @AUTHORITY WHERE ID = @selected_id",
				sqlConnection);

			command.Parameters.AddWithValue("NAME", textBox4.Text);
			command.Parameters.AddWithValue("SURNAME", textBox5.Text);
			command.Parameters.AddWithValue("PHONE", textBox6.Text);
			command.Parameters.AddWithValue("IDENTIFY", textBox7.Text);
			command.Parameters.AddWithValue("PASSPORT", textBox8.Text);
			command.Parameters.AddWithValue("AUTHORITY", textBox9.Text);
			command.Parameters.AddWithValue("selected_id", Int32.Parse(dataGridView3.SelectedCells[0].Value.ToString()));

			command.ExecuteNonQuery();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				$"INSERT INTO [State] (NAME, DESCRIPTION, IMPACT) VALUES (@NAME, @DESCRIPTION, @IMPACT)",
				sqlConnection);

			float money = float.Parse(textBox12.Text);

			command.Parameters.AddWithValue("NAME", textBox10.Text);
			command.Parameters.AddWithValue("DESCRIPTION", textBox11.Text);
			command.Parameters.AddWithValue("IMPACT", money);

			command.ExecuteNonQuery();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				$"DELETE FROM [State] WHERE ID = @selected_id",
				sqlConnection);

			command.Parameters.AddWithValue("selected_id", Int32.Parse(dataGridView5.SelectedCells[0].Value.ToString()));

			command.ExecuteNonQuery();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			SqlCommand command = new SqlCommand(
				"UPDATE [State] SET NAME = @new_name, DESCRIPTION = @new_description, IMPACT = @new_impact WHERE ID = @selected_id",
				sqlConnection);

			float money = float.Parse(textBox12.Text);

			command.Parameters.AddWithValue("new_name", textBox10.Text);
			command.Parameters.AddWithValue("new_description", textBox11.Text);
			command.Parameters.AddWithValue("new_impact", money);
			command.Parameters.AddWithValue("selected_id", Int32.Parse(dataGridView5.SelectedCells[0].Value.ToString()));

			command.ExecuteNonQuery();
		}

		Create_check create_Check;

		private void button15_Click(object sender, EventArgs e)
		{
			create_Check = new Create_check();
			create_Check.Show();
		}

		private void button16_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT [Clients].NAME, [Clients].SURNAME, [Check].TIME_AND_DATE, [Category].NAME AS 'CATEGORY', [State].NAME AS 'STATE' FROM[Clients], [Operation], [Category], [State], [Check] WHERE[Clients].[ID] = [Check].ID_CLIENT AND[Check].ID = [Operation].ID_CHECK AND[Category].ID = [Operation].ID_CATEGORY AND[State].Id = [Operation].ID_STATE", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView4.DataSource = dataSet.Tables[0];
		}

		private void button17_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT [Clients].NAME, [Clients].SURNAME, [Check].TIME_AND_DATE, SUM([Category].PRICE + [State].IMPACT) FROM[Clients], [Operation], [Category], [State], [Check] WHERE[Clients].[ID] = [Check].ID_CLIENT AND[Check].ID = [Operation].ID_CHECK AND[Category].ID = [Operation].ID_CATEGORY AND[State].Id = [Operation].ID_STATE GROUP BY[Clients].NAME, [Clients].SURNAME, [Check].TIME_AND_DATE", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView2.DataSource = dataSet.Tables[0];
		}

		private void button18_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(textBox13.Text, sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView2.DataSource = dataSet.Tables[0];
		}

		private void button19_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(textBox14.Text, sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			dataGridView4.DataSource = dataSet.Tables[0];
		}

		private void button20_Click(object sender, EventArgs e)
		{
			printDocument1.PrintPage += printDocument1_PrintPage;
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.ShowDialog();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			//Width=827 Height=1169
			Font font = new Font("Times New Roman", 14, FontStyle.Regular);
			e.Graphics.DrawString("POPSHOP\nCORPORATION", font, Brushes.Black, new Point(550, 50));
			e.Graphics.DrawString("Daily report", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(350, 150));
			e.Graphics.DrawString($"As of {DateTime.Now.ToShortDateString()}, the total number of checks held: {dataGridView2.Rows.Count}\nMore details in table:", font, Brushes.Black, new Point(100, 190));

			Bitmap bmp = new Bitmap(dataGridView2.Size.Width+10, dataGridView2.Size.Height+10);
			dataGridView2.DrawToBitmap(bmp, dataGridView2.Bounds);
			e.Graphics.DrawImage(bmp, 30, 250, 780.0f, dataGridView2.Size.Height-50);

			e.Graphics.DrawString("Illya Kapyshin", new Font("Times New Roman", 14, FontStyle.Italic), Brushes.Black, new Point(650, 580));

			e.Graphics.DrawImage(new Bitmap(Image.FromFile("D:\\Programing\\SQL\\FirstDB\\Resources\\seal.png")), 620, 550, 100.0f, 100.0f);

			e.Graphics.DrawString($"Date: {DateTime.Now.ToShortDateString()}", font, Brushes.Black, new Point(100, 580));
		}

		private void button21_Click(object sender, EventArgs e)
		{
			Diagram_form diagram = new Diagram_form();
			diagram.Show();
		}
	}
}
