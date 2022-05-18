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
	public partial class Diagram_form : Form
	{
		private SqlConnection sqlConnection = null;

		public Diagram_form()
		{
			InitializeComponent();
		}

		private void button16_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT YEAR([Check].TIME_AND_DATE) AS 'Years', COUNT(TIME_AND_DATE) AS 'Count of checks' FROM[Check] GROUP BY YEAR([Check].TIME_AND_DATE)", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			chart1.Series["year"].XValueMember = "Years";
			chart1.Series["year"].YValueMembers = "Count of checks";
			chart1.Legends["leg"].Title = "Years";
			chart1.DataSource = dataSet.Tables[0];
			chart1.DataBind();
		}

		private void Diagram_form_Load(object sender, EventArgs e)
		{
			sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["popshopDB"].ConnectionString);

			sqlConnection.Open();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT Category.NAME AS 'Type', COUNT([Operation].Id) AS 'Count of sales' FROM[Category], [Operation] WHERE[Category].ID = [Operation].ID_CATEGORY GROUP BY[Category].NAME", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			chart1.Series["year"].XValueMember = "Type";
			chart1.Series["year"].YValueMembers = "Count of sales";
			chart1.Legends["leg"].Title = "Types";
			chart1.DataSource = dataSet.Tables[0];
			chart1.DataBind();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SqlDataAdapter dataAdapter = new SqlDataAdapter(
				"SELECT [State].NAME AS 'State', COUNT([Operation].Id) AS 'Count of sales' FROM[State], [Operation] WHERE[State].ID = [Operation].ID_STATE GROUP BY[State].NAME", sqlConnection);

			DataSet dataSet = new DataSet();

			dataAdapter.Fill(dataSet);

			chart1.Series["year"].XValueMember = "State";
			chart1.Series["year"].YValueMembers = "Count of sales";
			chart1.Legends["leg"].Title = "States";
			chart1.DataSource = dataSet.Tables[0];
			chart1.DataBind();
		}
	}
}
