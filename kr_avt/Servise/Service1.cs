using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace kr_avt.Servise
{
        // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 
    {
        public bool Payments(string s, int sum)
        {
            Random rnd = new Random();
            Payment p = new Payment();
            p.Schet = s;
            p.Balanse = rnd.Next(0, 10000);

            Payment ag = new Payment();
            ag.Schet = "0000";
            ag.Balanse = 0;
            if (p.Schet.Equals(ag.Schet)) { return false; }

            else
            {
                if (p.Balanse >= sum)
                {
                    p.Balanse = p.Balanse - sum;
                    ag.Balanse = ag.Balanse + sum;
                    return true;
                }
                else { return false; }
            }
        }
    }
}
