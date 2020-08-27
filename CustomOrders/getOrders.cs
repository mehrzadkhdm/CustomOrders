using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomOrders
{
    public partial class getOrders : Form
    {
        public CustomOrders parentForm = null;

        public getOrders(CustomOrders customOrders)
        {
            InitializeComponent();
            parentForm = (CustomOrders)this.Owner;
            parentForm = customOrders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response;
            RestClient client = new RestClient();

            //client = new RestClient("https://ssapi.shipstation.com/stores");
            //client.Timeout = -1;
            //request.AddHeader("Host", "ssapi.shipstation.com");
            //request.AddHeader("Authorization", getAuthorizationString());
            //IRestResponse restResponse = client.ExecuteAsGet(request, "GET");

            if (radioButtonUnshipped.Checked)
            {
                client = new RestClient("https://ssapi.shipstation.com/orders?storeId=133331&orderStatus=awaiting_shipment");
                client.Timeout = -1;
                request.AddHeader("Host", "ssapi.shipstation.com");
                request.AddHeader("Authorization", getAuthorizationString());
                //textBox1.Text = response.Content;
            }
            else if (radioButtonDateRange.Checked)
            {
                string a = "https://ssapi.shipstation.com/orders?storeId=133331&+ " +
                    "createDateStart=" + dateTimePicker1.Value.AddDays(-1).ToShortDateString() + 
                    "&createDateEnd=" + dateTimePicker2.Text;

                client = new RestClient("https://ssapi.shipstation.com/orders?storeId=133331&" +
                    "createDateStart=" + dateTimePicker1.Value.AddDays(-1).ToShortDateString() +
                    "&createDateEnd=" + dateTimePicker2.Text);

                client.Timeout = -1;
                request.AddHeader("Host", "ssapi.shipstation.com");
                request.AddHeader("Authorization", getAuthorizationString());
                //textBox1.Text = response.Content;
            }
            else
            {
                client = new RestClient("https://ssapi.shipstation.com/orders?storeId=133331&orderNumber=" + textBoxOrderNumber.Text.Trim());
                client.Timeout = -1;
                request.AddHeader("Host", "ssapi.shipstation.com");
                request.AddHeader("Authorization", getAuthorizationString());


                //textBox1.Text = response.Content;
            }
            parentForm.request = request;
            parentForm.client = client;
            Close();

        }
        private string getAuthorizationString()
        {

            return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(parentForm.ShipStationAPIKey + ":" + parentForm.ShipStationAPISecret));
        }

        private void radioButtonUnshipped_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUnshipped.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                textBoxOrderNumber.Enabled = false;
            }

        }

        private void radioButtonOrderNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOrderNumber.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                textBoxOrderNumber.Enabled = true;
            }
        }

        private void radioButtonDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonDateRange.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                textBoxOrderNumber.Enabled = false;
            }
        }

        private void getOrders_Load(object sender, EventArgs e)
        {

        }
    }

}
