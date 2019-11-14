using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartPhone myPhone = new SmartPhone{ Model = "Samsung" , Price = "1000" };
            myPhone.MakePhoto();
            PhoneWithCamera NewPhone = new PhoneWithCamera();
            NewPhone = (PhoneWithCamera)myPhone.Clone();
            myPhone.RenamePhoto("Пейзаж");

            NewPhone = (SmartPhone) NewPhone;
            

            //myPhone.Caling += PhoneCalling;
            //myPhone.CallTo("86484534");
            myPhone.MakePhoto();
            Console.WriteLine("Телефон: {0}. Цена: {1}", myPhone.Model, myPhone.Price);
            myPhone.MakePhoto();
            Console.WriteLine("Фото: {0} сохраненно. Размер: {1}", myPhone.Photo.Name, myPhone.Photo.Size);
            myPhone.RenamePhoto("Пейзаж");
            Console.WriteLine("Новое имя фото: {0}. Размер: {1}", myPhone.Photo.Name, myPhone.Photo.Size);
            Console.Read();
        }

        static void PhoneCalling(object sender, CallingEventArgs e)
        {
           Console.WriteLine(e.Message);
        }
    }
}
