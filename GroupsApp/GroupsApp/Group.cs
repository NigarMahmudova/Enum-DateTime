using System;
using System.Collections.Generic;
using System.Text;

namespace GroupsApp
{
    internal class Group
    {
        public string GroupNo;
        public GroupType Type;
        public DateTime StartDate;

        public void ShowInfo()
        {
            Console.WriteLine($"GroupNo: {GroupNo} - Type: {Type} - StartDate: {StartDate.ToString("dd-MM-yyyy HH:mm")}");
        }
    }
}
