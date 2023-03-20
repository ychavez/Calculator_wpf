using System.IO.Ports;
using System.Threading;

namespace Productos_wpf.ViewModel.Services
{
    public class SerialReader
    {
        SerialPort _serialPort = new SerialPort("COM8", 2400, Parity.None, 8, StopBits.One);
        private string data;

        public SerialReader()
        {
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.ReadTimeout = 52;
            _serialPort.Open();
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(50);
             data = _serialPort.ReadLine();
        }

        public string Read() => data;
    }
}
