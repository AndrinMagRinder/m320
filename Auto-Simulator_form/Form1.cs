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
        /*
      * Hier werden alle Autos, Lastagen und Feuerwehr autos erstellt
      */
        private void Form1_Load(object sender, EventArgs e)
        {
            cbx_Fahrzeug.Items.Add(new Auto("VW Golf", 200));
            cbx_Fahrzeug.Items.Add(new Auto("BMW M4", 430));
            cbx_Fahrzeug.Items.Add(new Auto("Lamborghini Huracan", 640));
            cbx_Fahrzeug.Items.Add(new Lastwagen("Mercedes Lastwagen", 650));
            cbx_Fahrzeug.Items.Add(new Lastwagen("Scania Lastwagen", 770));
            cbx_Fahrzeug.Items.Add(new FireTruck("Fire Truck", 770));



        }

        /*
        * Hier wird ausgewählt welches Auto oder Lastwagen gewählt wird
        * Dazu wird auch dafür gesorgt, dass man wenn man einen Lastwagen auswählt
        * das Gewicht noch entscheiden kann.
        */

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
        /*
         * lbl_status_Click sorgt dafür, dass das Auto an oder Ausgeschaltet wird
         */
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


        /*
          * btn_Gas_MouseHover_1 sorg dafür, dass wenn ich über gas hovere das Auto losfährt
          * wenn Status auf 1 ist geht das Gear auf 1. Wenn ich dann auf Gas gebe ändert sich das
          * Label showSpeed.
          */
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
        /*
         * btn_Brake_MouseHover macht eigentlich das gleiche wie btn_Gas_MouseHover_1
         * nur bremst es und gibt nicht gas.
         */
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
        /*
       * Wenn ich auf Honk klicke, dann ertönt eine Hupe
       */
        private void btn_honk_Click(object sender, EventArgs e)
        {
            if (vehicle != null && vehicle.status == 1)
            {
                vehicle.Honk();
            }
        }
        /*
         * cbx_Weight_SelectedIndexChanged sorgt dafür, dass ich das gewicht beim Lastwagen 
         * ändern kann
         */
        private void cbx_Weight_SelectedIndexChanged(object sender, EventArgs e)
        {


            System.Windows.Forms.ComboBox cmb = (System.Windows.Forms.ComboBox)sender;
            if(cbx_Weight.SelectedItem == null)
            {
                return;
            }

            if(cbx_Weight.SelectedItem  == "25 Tonnen") 
            {
                Lastwagen.SetWeight(25);
            }
            if (cbx_Weight.SelectedItem == "20 Tonnen")
            {
                Lastwagen.SetWeight(20);
            }
            if (cbx_Weight.SelectedItem == "15 Tonnen")
            {
                Lastwagen.SetWeight(15);
            }
            if (cbx_Weight.SelectedItem == "0 Tonnen")
            {
                Lastwagen.SetWeight(0);
            }


        }
    }
}
