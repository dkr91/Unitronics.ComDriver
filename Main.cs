using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.ServiceProcess;
using Unitronics.ComDriver.Messages.DataRequest;


namespace Unitronics.ComDriver
{
    class Main
    {
       

        public static void main()
        {
            
            //Haussteuerung
            {
                Channel ch = new Ethernet("192.168.47.6", 20257, EthProtocol.TCP);
                PLC plc = PLCFactory.GetPLC(ch, 0);
                Console.WriteLine(plc.PlcName);
                plc.SetExecuter(OperandsExecuterType.ExecuterPartialBinaryMix);

                Console.WriteLine(plc.Version + "\t");
                Console.WriteLine(plc.RTC + "\tPLC Timer \n" + System.DateTime.Now + "\tUTC Time");
//Until here
                plc_haussterung plcHaussterung = new plc_haussterung(ch);
                ReadWriteRequest[] rw = plcHaussterung.init();

                while (true)
                {
                    plcHaussterung.readData();
                    Thread.Sleep(60000);
                }

            }


        //Kompressor
          /*  {
                Channel ch = new Ethernet("192.168.47.12", 20256, EthProtocol.TCP);
                PLC plc = PLCFactory.GetPLC(ch, 0);
                Console.WriteLine(plc.PlcName);
                plc.SetExecuter(OperandsExecuterType.ExecuterPartialBinaryMix);

                Console.WriteLine(plc.Version);
                Console.WriteLine(plc.PLCChannel);
                Console.WriteLine(plc.RTC + " \t" + System.DateTime.Now);

                object[] values = new object[2048];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = (object) i;
                }

                ReadWriteRequest[] rw = new ReadWriteRequest[1];

                ReadWriteRequest getCurr = new ReadOperands
                {
                    NumberOfOperands = 1,
                    OperandType = OperandTypes.TimerPreset,
                    StartAddress = 0,
                    TimerValueFormat = TimerValueFormat.TimeFormat,
                };
                rw[0] = getCurr;
                try
                {
                    plc.ReadWrite(ref rw);
                    Console.WriteLine(rw[0].ResponseValues);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + ":" + e.StackTrace);
                    throw;
                }
                
            }*/
            
        }
    }
}