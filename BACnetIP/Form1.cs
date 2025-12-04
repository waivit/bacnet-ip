using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;
using Modbus.Device;
using System.Management;
using System.IO.BACnet;
using System.Web.UI.WebControls;
using PacketDotNet;
using System.Linq;
using System.Text;

namespace ModBus

    {


    public partial class Form1 : Form
        {
            BacnetClient bacnetClient;
            SerialPort serialPort;
            ModbusSerialMaster master;
            ModbusSerialSlave Slave;


        public Form1()
            {
                InitializeComponent();
                this.Load += new System.EventHandler(this.Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAvailablePorts();
        }


        private void LoadAvailablePorts()
        {
            comboBoxPorts.Items.Clear();

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"))
            {
                foreach (var device in searcher.Get())
                {
                    string fullName = device["Name"]?.ToString(); // เช่น "USB Serial Device (COM3)"
                    string portName = ExtractPortName(fullName);  // ดึง "COM3" ออกมา

                    comboBoxPorts.Items.Add(new KeyValuePair<string, string>(fullName, portName));
                }
            }
            //comboBoxPorts.DisplayMember = "Name";
            //comboBoxPorts.DisplayMember = "Key"; // แสดงชื่อเต็มใน ComboBox
            //comboBoxPorts.ValueMember = "Value"; // เก็บค่า COM Port จริง
            if (comboBoxPorts.Items.Count > 0)
                comboBoxPorts.SelectedIndex = 0;
            else
                comboBoxPorts.Text = "No COM ports found";
        }

        private string ExtractPortName(string fullName)
        {
            int start = fullName.IndexOf("(COM");
            if (start >= 0)
            {
                int end = fullName.IndexOf(")", start);
                if (end > start)
                    return fullName.Substring(start + 1, end - start - 1); // เช่น "COM3"
            }
            return fullName;
        }

        private void button1_Click(object sender, EventArgs e)
            {
            txtBoxOutput.Clear();
            string selectedPort = ((KeyValuePair<string, string>)comboBoxPorts.SelectedItem).Value;
            serialPort = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            try
            {
                serialPort.Open();
                master = ModbusSerialMaster.CreateRtu(serialPort);
                txtBoxOutput.AppendText("Connected to "+ selectedPort+"\r\n");

                // อ่าน Holding Register จาก Slave ID 1 ที่ Address 0 จำนวน 2 ตัว
                ushort[] data = master.ReadHoldingRegisters(1, 0, 2);
                for (int i = 0; i < data.Length; i++)
                {
                    txtBoxOutput.AppendText($"Register {i}: {data[i]}\r\n");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error : " + ex.Message);
                txtBoxOutput.AppendText("Error : " + ex.Message+"\r\n");
            }
            finally
            {
                serialPort?.Close();
            }
        }

        private void comboBoxPorts_Onclick(object sender, EventArgs e)
        {
            //LoadAvailablePorts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadAvailablePorts();
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            
           if(bacnetClient != null)
            { bacnetClient.Dispose(); }
            // สร้าง BACnet client
            bacnetClient = new BacnetClient(new BacnetIpUdpProtocolTransport(0xBAC0, false));
            bacnetClient.Start();



            txtBoxOutput.AppendText("BACnet/IP client started...\r\n");

            // ส่ง WHO-IS เพื่อค้นหาอุปกรณ์
            bacnetClient.WhoIs(0,1);
            txtBoxOutput.AppendText("Sent WhoIs broadcast...\r\n");

            bacnetClient.OnIam += new BacnetClient.IamHandler(OnIamHandler);
        }

        public class BacnetDeviceInfo
        {
            public uint DeviceId { get; set; }
            public BacnetAddress Address { get; set; }
        }

        List<BacnetDeviceInfo> discoveredDevices = new List<BacnetDeviceInfo>();

        private void OnIamHandler(BacnetClient sender, BacnetAddress address, uint deviceId, uint maxApdu, BacnetSegmentations segmentation, ushort vendorId)
        {


            Invoke(new Action(() =>
            {
                txtBoxOutput.AppendText($"IAm received from device {deviceId} at {address}\r\n");
                //discoveredDevices.Add(new { DeviceId = deviceId, Address = sender });
                discoveredDevices.Add(new BacnetDeviceInfo { DeviceId = deviceId, Address = address });
            }));
        }


       


        private void buttonRead_Click(object sender, EventArgs e)
        {
            try
            {
                // กำหนดที่อยู่ของอุปกรณ์ BACnet
                BacnetAddress deviceAddress = new BacnetAddress(BacnetAddressTypes.IP, IPAddr_textBox.Text);
                int InstanceID = int.Parse(InstanceID_textBox.Text);
                int InstanceID_to = int.Parse(InstanceID_to_textBox.Text);
                uint ui = 0;
                var targetDevice = discoveredDevices.FirstOrDefault(d => d.DeviceId == 1);
                

                for (int i=InstanceID; i <= InstanceID_to; i++ )
                {
                    ui = (uint)i;
               
                // กำหนด Object ที่ต้องการอ่าน
                BacnetObjectId objectId = new BacnetObjectId(BacnetObjectTypes.OBJECT_BINARY_OUTPUT, ui);
                

                // อ่านค่าจากอุปกรณ์
                if (bacnetClient.ReadPropertyRequest(targetDevice.Address, objectId, BacnetPropertyIds.PROP_PRESENT_VALUE, out var values))
                {
                        
                    txtBoxOutput.AppendText($"Value: {values[0].Value}\r\n");
                        //byte[] tempval = ASCIIEncoding.UTF8.GetBytes("setProp");
                        //List<BacnetValue> tempBacnetValueval = new List<BacnetValue>();
                        //tempBacnetValueval.Add(new BacnetValue(tempval[1]));
                        //var bacnetfinal = tempBacnetValueval.ToArray();
                        
                        //bacnetClient.WritePropertyRequest(targetDevice.Address, objectId, BacnetPropertyIds.PROP_DESCRIPTION, bacnetfinal);
                        //bacnetClient.WritePropertyRequest(targetDevice.Address, objectId, BacnetPropertyIds.PROP_DESCRIPTION, values);
                }
                

                else
                {
                    txtBoxOutput.AppendText("Read OBJECT_ANALOG_INPUT ["+i+"] failed.\r\n");
                }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void InstanceID_to_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtBoxOutput.Clear();
            string selectedPort = ((KeyValuePair<string, string>)comboBoxPorts.SelectedItem).Value;


            SerialPort serialPort = new SerialPort(selectedPort);
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Open();

            //serialPort = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            try
            {
                serialPort.Open();
                master = ModbusSerialMaster.CreateRtu(serialPort);
                txtBoxOutput.AppendText("Connected to " + selectedPort + "\r\n");

                // อ่าน Holding Register จาก Slave ID 1 ที่ Address 0 จำนวน 2 ตัว
                ushort[] data = master.ReadHoldingRegisters(1, 0, 2);
                for (int i = 0; i < data.Length; i++)
                {
                    txtBoxOutput.AppendText($"Register {i}: {data[i]}\r\n");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error : " + ex.Message);
                txtBoxOutput.AppendText("Error : " + ex.Message + "\r\n");
            }
            finally
            {
                serialPort?.Close();
            }
        }
    }
    }
