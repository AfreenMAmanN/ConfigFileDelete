using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigFileDelete
{
     class MainClass
    {
        [Obsolete]
        static void Main(string[] args)
        {
            string path = System.Configuration.ConfigurationSettings.AppSettings["Path"];
            string Num_ofdays = System.Configuration.ConfigurationSettings.AppSettings["Num_of_days"];
           
            Console.WriteLine("\n path configured:\n"+ path + "\nNo of days: "+ Num_ofdays);

            
            DirectoryInfo dirinfo = new DirectoryInfo(path);
           
            int cnt_file_present = 0,cnt_file_deleted = 0;
           
           
            FileInfo[] f = dirinfo.GetFiles().OrderBy(p => p.CreationTime).ToArray();
            
             
            foreach (FileInfo fi in f)
            {

                cnt_file_present = cnt_file_present + 1;
               
                
                if (fi.CreationTime < DateTime.Today.AddDays(-Convert.ToInt32(Num_ofdays)))
                {

                    cnt_file_deleted = cnt_file_deleted + 1;


                    fi.Delete();
                      
                    Console.WriteLine("" +fi.FullName + " is successfully deleted\n");
                   

                }
                
                

            }
           
            Console.WriteLine("File present in  folder:"+ cnt_file_present);

            Console.WriteLine("File present before " + Num_ofdays + "days are:" + cnt_file_deleted);
            Console.WriteLine("File deleted are " + cnt_file_deleted);
            
            
            
        }
    }
}
