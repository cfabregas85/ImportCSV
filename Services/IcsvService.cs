using ImportCVS.Models;

namespace ImportCVS.Services
{
    public interface IcsvService
    {
        string AddCSV(string[] path);
        bool CheckedDuplicate(CSVModel cvs);
        bool CheckFileNameFormat(string filename);
        bool CheckValidDate(string filename);
    }
}