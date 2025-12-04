using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO.Ports;
using NModbus.Serial;
using NModbus;
using NModbus.Data;


namespace ModbusRTU2
{
    class Program
    {
        static void Main(string[] args)
        {

            // สร้าง Serial Port
            String tmp = String.Empty;
            Console.WriteLine("Please specify COMName [ex.COM3]");
            tmp = Console.ReadLine();
            SerialPort serialPort = new SerialPort(string.IsNullOrWhiteSpace(tmp) ? "COM3" : tmp);
            Console.WriteLine("Please specify BaudRate [ex.9600]");
            tmp = Console.ReadLine();
            serialPort.BaudRate = int.Parse(string.IsNullOrWhiteSpace(tmp) ? "9600" : tmp);
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Open();


            // สร้าง Modbus Factory
            var factory = new ModbusFactory();
            var slaveNetwork = factory.CreateRtuSlaveNetwork(serialPort);

            // สร้าง Data Store สำหรับ Power Meter
            //var dataStore = new DefaultSlaveDataStore
            //{
            //    HoldingRegisters = new ushort[100]
            //};

            var dataStore = new DefaultSlaveDataStore();



            Random rnd = new Random();

            // เขียนค่า Voltage, Current, Power ลง Holding Registers
            ushort voltage = (ushort)rnd.Next(220, 240);
            ushort current = (ushort)rnd.Next(5, 15);
            ushort power = (ushort)(voltage * current);
            // เขียนค่าลง HoldingRegisters
            dataStore.HoldingRegisters.WritePoints(0, new ushort[] { voltage });
            dataStore.HoldingRegisters.WritePoints(1, new ushort[] { current });
            dataStore.HoldingRegisters.WritePoints(2, new ushort[] { power });
            Console.WriteLine("HoldingRegisters is " + voltage + ";" + current + ";" + power);



            Task.Run(() =>
            {
                while (true)


                {
                    voltage = (ushort)rnd.Next(220, 240);
                    current = (ushort)rnd.Next(5, 15);
                    power = (ushort)(voltage * current);
                    dataStore.HoldingRegisters.WritePoints(0, new ushort[] { voltage });
                    dataStore.HoldingRegisters.WritePoints(1, new ushort[] { current });
                    dataStore.HoldingRegisters.WritePoints(2, new ushort[] { power });
                    Console.WriteLine("HoldingRegisters is :: " + voltage + " :: " + current + " :: " + power);
                    System.Threading.Thread.Sleep(2000);
                }
            });

            var slave = factory.CreateSlave(1, dataStore);
            slaveNetwork.AddSlave(slave);


            Console.WriteLine("Modbus RTU Power Meter Simulator started...");

            // เริ่มฟังคำสั่งจาก Master
            slaveNetwork.ListenAsync();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Please ENTER to exit");
            Console.ReadLine();

        }


    }
}
