using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

public class Logs
{
    FileStream file;
    StreamWriter WriteFile;
    StreamReader ReadFile;

    public void LogAddLine(string line)
    {
        if (!Directory.Exists(@"" + Application.StartupPath + "\\Log\\"))
        {
            Directory.CreateDirectory(@"" + Application.StartupPath + "\\Log\\");
        }
        string filepath = @"" + Application.StartupPath + "\\Log\\Log_" + DateTime.Now.ToShortDateString().Replace("/", "_").Replace(".", "_") + ".txt";
        //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
        file = new FileStream(filepath, FileMode.Append, FileAccess.Write);
        //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
        //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
        //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
        WriteFile = new StreamWriter(file);
        //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
        line = DateTime.Now.ToLocalTime().ToString() +" : "+ line;
        
        WriteFile.WriteLine(line);
        //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
        WriteFile.Flush();
        //Veriyi tampon bölgeden dosyaya aktardık.
        WriteFile.Close();
        file.Close();
        //İşimiz bitince kullandığımız nesneleri iade ettik.
    }
    public void LogAddLine(Exception line, string which)
    {
        if (!Directory.Exists(@"" + Application.StartupPath + "\\Log\\"))
        {
            Directory.CreateDirectory(@"" + Application.StartupPath + "\\Log\\");
        }
        string filepath = @"" + Application.StartupPath + "\\Log\\Log_" + DateTime.Now.ToShortDateString().Replace("/", "_").Replace(".", "_") + ".txt";
        //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
        file = new FileStream(filepath, FileMode.Append, FileAccess.Write);
        //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
        //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
        //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
        WriteFile = new StreamWriter(file);
        //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
        WriteFile.WriteLine(DateTime.Now.ToLocalTime().ToString() + " : " + which +" - "+ line.ToString());
        //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
        WriteFile.Flush();
        //Veriyi tampon bölgeden dosyaya aktardık.
        WriteFile.Close();
        file.Close();
        //İşimiz bitince kullandığımız nesneleri iade ettik.
    }
    public void LogAddLine(string line, string which)
    {
        if (!Directory.Exists(@"" + Application.StartupPath + "\\Log\\"))
        {
            Directory.CreateDirectory(@"" + Application.StartupPath + "\\Log\\");
        }
        string filepath = @"" + Application.StartupPath + "\\Log\\Log_" + DateTime.Now.ToShortDateString().Replace("/", "_").Replace(".", "_") + ".txt";
        //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
        file = new FileStream(filepath, FileMode.Append, FileAccess.Write);
        //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
        //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
        //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
        WriteFile = new StreamWriter(file);
        //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
        line = DateTime.Now.ToLocalTime().ToString() + " : " + line;

        WriteFile.WriteLine(line);
        //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
        WriteFile.Flush();
        //Veriyi tampon bölgeden dosyaya aktardık.
        WriteFile.Close();
        file.Close();
        //İşimiz bitince kullandığımız nesneleri iade ettik.
    }
    public string LogReader(string time)
    {
        if (!Directory.Exists(@"" + Application.StartupPath + "\\Log\\"))
        {
            return null;
        }
        string filepath = @"" + Application.StartupPath + "\\Log\\Log_" + time.Replace("/", "_").Replace(".", "_") + ".txt";
        //Okuma işlem yapacağımız dosyanın yolunu belirtiyoruz.
        FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
        //2.parametre dosyanın açılacağını,
        //3.parametre dosyaya erişimin veri okumak için olacağını gösterir.
        ReadFile = new StreamReader(file);
        //Okuma işlemi için bir StreamReader nesnesi oluşturduk.
        string yazi = ReadFile.ReadLine();
        while (yazi != null)
        {
            yazi += ReadFile.ReadLine();
        }
        //Satır satır okuma işlemini gerçekleştirdik ve ekrana yazdırdık
        //Son satır okunduktan sonra okuma işlemini bitirdik
        ReadFile.Close();
        file.Close();
        return yazi;
        //İşimiz bitince kullandığımız nesneleri iade ettik.
    }

}
