using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Phone
    {
        public string Model { get; set; }
        public string Price { get; set; }
        private bool IsCalling { get; set; }
        public void CallTo(string number)
        {
            if (!IsCalling)
            {
                IsCalling = true;
            }

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Caling (this,new CallingEventArgs(
                    string.Format("Длительность разговора {0} секунд",i)));
            }    

        }
        public void HangUp(string number)
        {
            IsCalling = false;
        }
        public event EventHandler<CallingEventArgs> Caling;
    }

    public class PhoneWithCamera : Phone, ICloneable
    {
        public Photo Photo { get; set; }
        public void MakePhoto()
        {
            Photo photo = GetPhoto();
            SavePhoto(photo);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        private Photo GetPhoto()
        {
            return new Photo();
        }
        private void SavePhoto(Photo photo)
        {
            Photo = photo;
        }

    }

    public class SmartPhone : PhoneWithCamera
    {
        public void RenamePhoto(string newName)
        {
            Photo.Name = newName;
        }
    }

    public class Photo
    {
        public string Name { get; set; }
        public double Size
        {
            get { return (Height * Weight)/1024; }
        }

        public int Height { get; set; }
        public int Weight { get; set; }
        public Photo()
        {
            Name = "Photo("+DateTime.Now.ToString()+")";
            Height = 1080;
            Weight = 1920;
        }

    }

    public class CallingEventArgs : EventArgs
    {
        public CallingEventArgs(string message)
        {
            Message = message;
        }
        public string Message { get; private set; }
    }
}
