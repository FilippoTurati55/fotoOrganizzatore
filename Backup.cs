using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace FotoOrganizzatore
{
    class UnitaEsterna
    {
        string format;
        string label;
        public string name;
        string numeroDiSerie;
        long spazioLibero, spazioDisponibile, spazioTotale;
        DriveType tipo;

        public bool esaminaDisco(DriveInfo driveInfo)
        {
            bool res = false;
            name = driveInfo.Name;
            tipo = driveInfo.DriveType;
            if (driveInfo.IsReady)
            {
                label = driveInfo.VolumeLabel;
                format = driveInfo.DriveFormat;
                spazioDisponibile = driveInfo.AvailableFreeSpace;
                spazioLibero = driveInfo.TotalFreeSpace;
                spazioTotale = driveInfo.TotalSize;
                string drive = name.Substring(0, 1);
                string messaggio = "Win32_LogicalDisk.DeviceID=\"" + drive + ":\"";
                ManagementObject obj = new ManagementObject(messaggio);
                obj.Get();
                numeroDiSerie = obj["VolumeSerialNumber"].ToString();
                res = true;
            }
            return res;
        }
    }
    class Backup
    {
        public void CercaUnitaEsterne()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.Name != "C:\\")
                {
                    UnitaEsterna disco = new UnitaEsterna();
                    if (disco.esaminaDisco(d))
                        Variabili.UnitaEsterne.Add(disco);
                }
            }
        }
    }
}
