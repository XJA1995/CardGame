using System;
using System.IO;
using System.Text;
public class CSV
{
    public void CSVRead()//从CSV文件夹中读取第一张卡牌的信息
    {
        StreamReader sr = new StreamReader(@"e:\Card.csv", Encoding.GetEncoding("utf-8"));//打开文件夹
        string[] line = new string[1];
        line[1] = sr.ReadLine();
        Card card = new Card(line[1].ToString().Split(' ')[0], line[1].ToString().Split(' ')[1], line[1].ToString().Split(' ')[2], Convert.ToInt32(line[1].ToString().Split(' ')[3]), Convert.ToInt32(line[1].ToString().Split(' ')[4]), line[1].ToString().Split(' ')[5]);
        
    }
}
   





    



