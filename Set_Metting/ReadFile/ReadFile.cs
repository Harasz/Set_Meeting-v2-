using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Set_Metting.ReadFile
{
    class ReadFile
    {
        protected StreamReader MemberList;
        public string[][] ListMembers { get; private set; }
        public int  MembersCount { get; private set; }

        public ReadFile(string path)
        {
            try
            {
                Encoding enc = Encoding.GetEncoding("Windows-1250");
                this.MemberList = new StreamReader(path, enc);
                this.ReadList();
            }
            catch (Exception e)
            {
                Notifications.Notif.Error(e.Message);
            }
        }

        protected void ReadList()
        {
            List<string> members = new List<string>();

            while (!this.MemberList.EndOfStream)
            {
                members.Add(this.MemberList.ReadLine());
            }

            if (members.Count % 2 != 0)
                this.MembersCount = members.Count+1;
            else
                this.MembersCount = members.Count + 1;

            Set_Metting.Notifications.Notif.Info(String.Format("Wczytano zawodników: {0}", members.Count));
            ListMembers = this.GenQueue(members);
        }

        protected string[][] GenQueue(List<string> data)
        {
            List<string[]> result = new List<string[]>();
            List<string> que = new List<string>();
            List<string> que2 = new List<string>();

            if (data.Count % 2 != 0)
                data.Add("PAUZA");

            for (int i = 1; i < data.Count/2; i++)
                que.Add(data[i]);

            for (int i = data.Count-1; i >= data.Count/2; i--)
                que2.Add(data[i]);

            string temp;
            string temp2;

            for(int i=0;i<data.Count-1;i++)
            {
                result.Add(new string[] { data[0], que2[0] });
                for (int j=0; j<(data.Count/2)-1;j++)
                {
                    result.Add(new string[] { que[j], que2[j + 1] });
                }
                temp = que[que.Count - 1];
                que.RemoveAt(que.Count - 1);
                que2.Add(temp);
                temp2 = que2[0];
                que2.RemoveAt(0);
                que.Insert(0, temp2);
            }

            Set_Metting.Notifications.Notif.Info(String.Format("Ustawiono par: {0}", result.Count));
            return result.ToArray();
        }

        protected string[][] Combinations(string[] data)
        {
            List<string[]> result = new List<string[]>();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    result.Add(new string[] { data[i], data[j] });
                }
            }
            return result.ToArray();
        }
    }
}
