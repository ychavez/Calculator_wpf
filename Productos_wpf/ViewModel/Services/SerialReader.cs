using System;
using System.IO.Ports;

namespace Productos_wpf.ViewModel.Services
{
    public class SerialReader
    {
        SerialPort _serialPort = new("COM11", 2400, Parity.None, 8, StopBits.One);
        string data;

        public SerialReader()
        {
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(ExecDataRecived);
            _serialPort.ReadTimeout = 50;
        }

        public void Open() 
        {
            if (!_serialPort.IsOpen)
                _serialPort.Open();
        }
        public void Close() 
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
        }

        private void ExecDataRecived(object sender, SerialDataReceivedEventArgs e)
        {
            data = _serialPort.ReadLine();
        }

        public string Read() => data;
    }
}
