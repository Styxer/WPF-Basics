using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Basics
{
    public class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; //= (sender, e) => { };

        public String Test { get; set; }
       

        public Class1()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while(true)
                {
                    await Task.Delay(250);
                    Test = (i++).ToString();
                }
            });
        }

        public override string ToString()
        {
            return "Hello world";
        }
    }
}
