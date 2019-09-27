using ImportCVS.Contexts;
using ImportCVS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImportCVS.Services
{
    public class csvService : IcsvService
    {

        #region Variables
        private readonly ApplicationDbContext _context;
        List<CSVModel> cvsList = new List<CSVModel>();
        #endregion

        #region Ctr

        public csvService(ApplicationDbContext context)
        {
            this._context = context;
        }

        #endregion

        #region Methods

        public string AddCSV(string[] path )
        {
            foreach (var file in path)
            {
                string filename = Path.GetFileNameWithoutExtension(file);

                if (!this.CheckFileNameFormat(filename))
                {
                    var error = new Log()
                    {
                        message = filename + "does not have the correct format"
                    };
                    this._context.LOG.Add(error);
                    this._context.SaveChanges();
                    continue;
                }                     

                if (!this.CheckValidDate(filename))
                {
                    var error = new Log()
                    {
                        message = filename + "does not have a valid date format"
                    };
                    this._context.LOG.Add(error);
                    this._context.SaveChanges();
                    continue;
                }

                using (var reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        var cvsTemp = new CSVModel();
                        var line = reader.ReadLine();
                        string[] values = line.Split(',');

                        if (values[1].ToString() == "John")
                        {
                            continue;
                        }

                        cvsTemp.csvId = values[0].ToString();
                        cvsTemp.FirstName = values[1].ToString();
                        cvsTemp.LastName = values[2].ToString();

                        if (CheckedDuplicate(cvsTemp))
                        {
                            cvsList.Add(cvsTemp);
                            _context.CSV.Add(cvsTemp);
                            this._context.SaveChanges();
                        }
                    }
                }
            }
            return "The CSV files information have been imported successfully.";            
        }

        public bool CheckFileNameFormat(string filename)
        {
            if (filename.Contains('_')) { return true; }
            else { return false; }
        }

        public bool CheckValidDate(string filename)
        {
            string last = "";

            string[] datename = filename.Split('_');
            string date = datename[1];
            if (date.Length == 8)
            {
                string y = date.Substring(0, 4);
                string m = date.Substring(4, 2);
                string d = date.Substring(6, 2);
                last = y + "/" + m + "/" + d;

                DateTime temp;
                if (DateTime.TryParse(last, out temp))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else {
                return false;
            }
           
        }

        public bool CheckedDuplicate(CSVModel cvs)
        {
            if (!cvsList.Any(c => c.csvId == cvs.csvId && c.FirstName == cvs.FirstName && c.LastName == cvs.LastName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}
