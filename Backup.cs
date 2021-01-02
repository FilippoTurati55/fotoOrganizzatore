using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    class UnitaEsterna
    {
        string format;
        string label;           // id costruttore o simile es. Lexar
        public string name;     // percorso. es. f://
        string nomeUnita;       // unità disco es. F
        string numeroDiSerie;   // numero di serie
        long spazioLibero, spazioDisponibile, spazioTotale;
        string identificatore = "";     // identificatore utente es. backup foto
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
        public bool accredita()
        {
            bool result = false;
            string idUnivoco = label + "_" + numeroDiSerie;
            if (Variabili.UnitaEsterneAccreditate.ContainsKey(idUnivoco))
            {
                // unità esterna già registrata
                identificatore = Variabili.UnitaEsterneAccreditate[idUnivoco];
                Variabili.UnitaEsterne.Add(this);
                result = true;
            }
            else
            {
                // unità esterna nuova
                AccreditamentoUnitaBackup aub = new AccreditamentoUnitaBackup();
                aub.inizializza(nomeUnita, label, numeroDiSerie);
                DialogResult dr;
                dr = aub.ShowDialog();
            }
            return result;
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
                    {
                        if (disco.accredita())
                            Variabili.UnitaEsterne.Add(disco);
                    }
                }
            }
        }
    }
}
