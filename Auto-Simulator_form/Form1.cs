using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Auto_Simulator_form
{
    public partial class Form1 : Form
    {
        Vehicle vehicle = null;
        private static int weight = 0;
        private static Form1 form;

        public Form1()
        {
            InitializeComponent();
            cbx_Fahrzeug.DisplayMember = "name";
            lbl_status.Text = "ON";
            cbx_Weight.Visible = false;
            lbl_weight.Visible = false;
            form = this;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbx_Fahrzeug.Items.Add(new Auto("VW Golf", 200));
            cbx_Fahrzeug.Items.Add(new Auto("BMW M4", 430));
            cbx_Fahrzeug.Items.Add(new Auto("Lamborghini Huracan", 640));
            cbx_Fahrzeug.Items.Add(new Lastwagen("Mercedes Lastwagen", 650));
            cbx_Fahrzeug.Items.Add(new Lastwagen("Scania Lastwagen", 770));
            cbx_Fahrzeug.Items.Add(new FireTruck("Fire Truck", 770));



        }



        private void cbx_Cars_SelectedIndexChanged(object sender, EventArgs e)
        {
            vehicle = cbx_Fahrzeug.SelectedItem as Vehicle;

            lbl_PS.Text = vehicle.hp.ToString() + "PS";

            if (vehicle.status == 1)
            {
                lbl_status.Text = "OFF";
            }
            if (vehicle.status == 0)
            {
                lbl_status.Text = "ON";            }

            lbl_ShowSpeed.Text = vehicle.speed.ToString();
            lbl_ShowGear.Text = vehicle.gear.ToString();

            if (vehicle is Lastwagen)
            {
                cbx_Weight.Visible = true;
                lbl_weight.Visible = true;
            }
            else
            {
                cbx_Weight.Visible = false;
                lbl_weight.Visible = false;
            }

        }

        private void lbl_status_Click(object sender, EventArgs e)
        {
            if (this.vehicle != null)
            {
                if (lbl_status.Text == "ON")
                {
                    lbl_status.Text = "OFF";
                    vehicle.StartEngine();
                    lbl_ShowSpeed.Text = vehicle.speed.ToString();
                    lbl_ShowGear.Text = vehicle.gear.ToString();
                    vehicle.EngineSound();
                }
                else
                {
                    lbl_status.Text = "ON";
                    vehicle.StopEngine();
                    lbl_ShowSpeed.Text = vehicle.speed.ToString();
                    lbl_ShowGear.Text = vehicle.gear.ToString();
                }
            }
        }

        private void btn_Brake_Click(object sender, EventArgs e)
        {

        }

        /*private void btn_Gas_Hover(object sender, EventArgs e)
        {
            if (auto.status == 1)
            {
                auto.Accelerate();
            }
        }*/

        private void btn_Gas_MouseHover_1(object sender, EventArgs e)
        {
            if (this.vehicle != null)
            {
                vehicle.Accelerate();
                if (vehicle.status == 1)
                {
                    vehicle.SetGear();
                }
                lbl_ShowSpeed.Text = vehicle.speed.ToString();
                btn_Gas.Visible = false;
                btn_Gas.Visible = true;
                lbl_ShowGear.Text = vehicle.gear.ToString();
            }
        }

        private void btn_Brake_MouseHover(object sender, EventArgs e)
        {
            if (this.vehicle != null)
            {
                vehicle.Brake();
                if (vehicle.status == 1)
                {
                    vehicle.SetGear();
                }
                lbl_ShowSpeed.Text = vehicle.speed.ToString();
                btn_Brake.Visible = false;
                btn_Brake.Visible = true;
                lbl_ShowGear.Text = vehicle.gear.ToString();
            }
        }

        private void btn_honk_Click(object sender, EventArgs e)
        {
            if (vehicle != null && vehicle.status == 1)
            {
                vehicle.Honk();
            }
        }

        public static int getInputFromComboBox()
        {

            return weight;

        }

        private void cbx_Weight_SelectedIndexChanged(object sender, EventArgs e)
        {


            System.Windows.Forms.ComboBox cmb = (System.Windows.Forms.ComboBox)sender;
            if(cmb.SelectedValue == null)
            {
                return;
            }
            int selectedValue = (int)cmb.SelectedValue;
            weight = selectedValue;

        }
    }
}
