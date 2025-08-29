using NModbus;
using NModbus.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;

namespace PacomArbetstest
{
    public class ModBus
    {
        /// <summary>
        ///    Modbus TCP master read inputs
        /// </summary>
        public static void ModbusTcpMasterReadInputs()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                // Read five input values
                ushort startAddress = 100;
                ushort numInputs = 5;
                bool[] inputs = master.ReadInputs(1, startAddress, numInputs);

                // Print the results
                for (int i = 0; i < numInputs; i++)
                {
                    Console.WriteLine($"Input {(startAddress + i)}={(inputs[i] ? 1 : 0)}");
                }
            }
        }

        /// <summary>
        /// Modbus TCP master read coils
        /// </summary>
        /// <param name="startAddress"></param>
        /// <returns></returns>
        public static bool ModbusTcpMasterReadCoils(ushort startAddress)
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);
                ushort numCoils = 1;
                bool[] coils = master.ReadCoils(1, startAddress, numCoils);
                for (int i = 0; i < numCoils; i++)
                {
                    Console.WriteLine($"Coil {(startAddress + i)}={(coils[i] ? 1 : 0)}");
                }
                return coils.Length > 0 && coils[0];
            }
        }


        /// <summary>
        /// Modbus TCP master write single coil
        /// </summary>
        /// <param name="coilAddress"></param>
        /// <param name="status"></param>
        public static void ModbusTcpMasterWriteSingleCoil(ushort coilAddress, bool status)
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);
                bool coilValue = status;
                master.WriteSingleCoil(1, coilAddress, coilValue);
                Console.WriteLine($"Wrote value {coilValue} to coil {coilAddress}.");
            }
        }
    }
}
