using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MissionPlanner.Controls.BackstageView;
using MissionPlanner.Controls;
using MissionPlanner.Arduino;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigCameraControl : UserControl, IActivate, IDeactivate
    {
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private PictureBox pictureBox2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private PictureBox pictureBox3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private ComboBox comboBox3;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox4;
        private Label label6;
        private Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private PictureBox pictureBox1;

        public ConfigCameraControl()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            // MainV2.comPort.MAV.param["CAM_TRIGG_DIST"].ToString();

            MemoryStream ms;

            if (MainV2.comPort.BaseStream.IsOpen)
            {
                BoardDetect.boards board = BoardDetect.boards.none;
                board = BoardDetect.DetectBoard(MainV2.comPortName);

                clearComboBox(comboBox2);
                clearComboBox(comboBox1);

                switch (board)
                {
                    case BoardDetect.boards.px4: //px4
                        ms = new MemoryStream(File.ReadAllBytes("../../Resources/px4.jpg"));

                        comboBox1.Items.Add("PX4 Only");
                        comboBox2.Items.Add("Aux1");
                        comboBox2.Items.Add("Aux2");
                        label4.Text = "PX4:";
                        break;

                    case BoardDetect.boards.px4v2: //pixhawk
                        ms = new MemoryStream(File.ReadAllBytes("../../Resources/pixhawk.jpg"));

                        comboBox1.Items.Add("Pixhawk Only");
                        comboBox2.Items.Add("Aux1");
                        comboBox2.Items.Add("Aux2");
                        label4.Text = "Pixhawk:";
                        break;

                    case BoardDetect.boards.none: //unknown
                    default: //all the APM versions
                        ms = new MemoryStream(File.ReadAllBytes("../../Resources/apmp2.jpg"));

                        comboBox1.Items.Add("APM Only");
                        comboBox2.Items.Add("A9");
                        comboBox2.Items.Add("Relay 50");
                        label4.Text = "APM:";
                        
                        break;
                }
            }
            else
            {
                pictureBox2.Visible = false;
                panel1.Visible = true;
                comboBox1.SelectedIndex = 0;

                ms = new MemoryStream(File.ReadAllBytes("../../Resources/apmp2.jpg"));
            }

            comboBox1.Items.Add("Camera Control Board");
            setPinTypeComboBox();
            pictureBox1.Image = Image.FromStream(ms);
        }

        public void Deactivate()
        {
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigCameraControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MissionPlanner.Properties.Resources.pixhawk;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // shapeContainer1
            // 
            resources.ApplyResources(this.shapeContainer1, "shapeContainer1");
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            resources.ApplyResources(this.lineShape2, "lineShape2");
            this.lineShape2.Name = "lineShape2";
            // 
            // lineShape1
            // 
            resources.ApplyResources(this.lineShape1, "lineShape1");
            this.lineShape1.Name = "lineShape1";
            // 
            // lineShape3
            // 
            resources.ApplyResources(this.lineShape3, "lineShape3");
            this.lineShape3.Name = "lineShape3";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MissionPlanner.Properties.Resources.IMAG0866_1;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MissionPlanner.Properties.Resources.IMAG0865;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox3, "comboBox3");
            this.comboBox3.Name = "comboBox3";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            resources.GetString("comboBox4.Items"),
            resources.GetString("comboBox4.Items1")});
            resources.ApplyResources(this.comboBox4, "comboBox4");
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox4);
            this.panel1.Controls.Add(this.shapeContainer2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // shapeContainer2
            // 
            resources.ApplyResources(this.shapeContainer2, "shapeContainer2");
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3});
            this.shapeContainer2.TabStop = false;
            // 
            // ConfigCameraControl
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "ConfigCameraControl";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Camera Board
        {
            switch (comboBox1.Text)
            {
                case "PX4 Only":
                case "Pixhawk Only":
                case "APM Only":
                    pictureBox2.Visible = false;
                    panel1.Visible = true;

                    MainV2.comPort.setParam("CAM_TRIGG_TYPE", 0);
                    break;

                case "Camera Control Board":
                    pictureBox2.Visible = true;
                    panel1.Visible = false;

                    MainV2.comPort.setParam("CAM_TRIGG_TYPE", 2);
                    break;

                default:
                    break;
            }

            setPinTypeComboBox();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) //Connection Type
        {
            switch (comboBox4.Text)
            {
                case "Servo":
                    MainV2.comPort.setParam("CAM_TRIGG_TYPE", 0);
                    break;

                case "Relay":
                    MainV2.comPort.setParam("CAM_TRIGG_TYPE", 1);
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //Connection Pin
        {
            switch (comboBox2.Text)
            {
                case "Aux1":
                    MainV2.comPort.setParam("RELAY_PIN", 50);
                    break;

                case "Aux2":
                    MainV2.comPort.setParam("RELAY_PIN", 51);
                    break;

                case "A9":
                    MainV2.comPort.setParam("RELAY_PIN", 13);
                    break;

                case "Relay 50":
                    MainV2.comPort.setParam("RELAY_PIN", 14);
                    break;

                default:
                    //error
                    break;
            }
        }

        private void clearComboBox(ComboBox box)
        {
            for (int i = box.Items.Count - 1; i >= 0; i--)
            {
                box.Items.RemoveAt(i);
            }
        }

        private void setPinTypeComboBox()
        {
            switch (MainV2.comPort.MAV.param["CAM_TRIGG_TYPE"].ToString())
            {
                case "0": //Servo
                    pictureBox2.Visible = false;
                    panel1.Visible = true;
                    comboBox1.SelectedIndex = 0;
                    comboBox4.SelectedIndex = 0;
                    break;

                case "1": //Relay
                    pictureBox2.Visible = false;
                    panel1.Visible = true;
                    comboBox1.SelectedIndex = 0;
                    comboBox4.SelectedIndex = 1;
                    break;

                case "2": //CCB
                    pictureBox2.Visible = true;
                    panel1.Visible = false;
                    comboBox1.SelectedIndex = 1;
                    break;
                default:
                    //error
                    break;
            }
        }

    }
}