using external_drive_lib;
using external_drive_lib.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*using external_drive_lib;
using external_drive_lib.bulk;
using external_drive_lib.interfaces;
using external_drive_lib.monitor;
using external_drive_lib.util;*/

namespace FotoOrganizzatore
{
    public class PortableDrivers
    {
        public static ArrayList elencoDispositiviUsb = new ArrayList();
        public static ArrayList elencoFileSuDispositivo = new ArrayList();

        /*foreach (var child in dest.files)
            child.delete_sync();*/

        /*public static bool LeggiInfoDaDevice(IDrive d)
        {
            bool res = false;
            foreach (var child in d.folders)
            {
                if (child.name == "Memoria condivisa interna")
                {
                    res = LeggiInfoDaDevice(child);
                }
            }
            return res;
        }*/

        /*public static bool LeggiInfoDaDevice(IFolder d)
        {
            bool res = false;
            foreach (var child in d.files)
            {
                if (child.name == "InfoFotografo.txt")
                {
                    res = true;
                }
            }
            return res;
        }*/
        public static int CercaCartellaCameraInTuttiIDispositiviUsb()
        {
            int found = -1;
            //var portable_drives = drive_root.inst.drives.Where(d => d.type.is_portable()).ToList();
            List<IDrive> portable_drives = drive_root.inst.drives.Where(d => d.type.is_portable()).ToList();
            if (portable_drives.Count > 0)
            {
                for (var n = 0; n < portable_drives.Count; n++)
                {
                    if (portable_drives[n].is_available())
                    {
                        /* provvisorio 27 1 21
                         * DispositivoRemoto dr = new DispositivoRemoto();
                        if (!Variabili.DispositiviRemoti.Contains(dr))
                        {
                            Variabili.DispositiviRemoti.Add(dr);
                            if (dr.Esamina(portable_drives[n]))
                                found = 1;
                        }
                        */
                    }
                }
            }
            return found;
        }
        public static int CercaCartellaCameraInUnDispositivoUsb(IDrive dispositivo)
        {
            int found = -1;
            if (dispositivo.is_available())
            {
                DispositivoRemoto dr = new DispositivoRemoto();
                if (!Variabili.DispositiviRemoti.Contains(dr))
                {
                    Variabili.DispositiviRemoti.Add(dr);
                    if (dr.Esamina(dispositivo))
                        found = 1;
                }
            }
            return found;
        }
        /*static bool CercaCartellaCamera(IDrive d)
        {
            bool found = false;
            foreach (var child in d.folders)
            {
                if (CercaCartellaCameraRecursive(child))
                    return true;
            }
            return found;
        }*/
        /*static bool CercaCartellaCameraRecursive(IFolder folder)
        {
            bool found = false;
            if (folder.name.ToUpper() == "CAMERA")
            {
                found = true;
            }
            else
            {
                foreach (var child in folder.child_folders)
                {
                    if (CercaCartellaCameraRecursive(child))
                        return true;
                }
            }
            return found;
        }*/
        static void Copy_all_camera_photos_to_hdd(string pathName)
        {
            var camera = drive_root.inst.try_parse_folder(pathName);
            if (camera != null)
            {
                //var temp = new_temp_path();
                var files = camera.files.ToList();
                //var idx = 0;
                foreach (var file in files)
                {
                    file.copy_sync(Utility.TempPath);
                }
            }
            //else
            // Console.WriteLine("No Android Drive Connected")
            //;
        }
        public static void Enumerate_all_camera_pics()
        {
            var portable_drives = drive_root.inst.drives.Where(d => d.type.is_portable()).ToList();
            if (portable_drives.Count > 0)
            {
                for (var n = 0; n < portable_drives.Count; n++)
                {
                    if (portable_drives[n].is_available())
                    {
                        get_elenco_file(portable_drives[n]);
                    }
                }
                // else Console.WriteLine("First Portable device is not available");
            }
            else
                //Console.WriteLine("No Portable Drives connected")
                ;
        }
        public static void Enumerate_camera_pics_in_folder(string pathName)
        {
            var portable_drives = drive_root.inst.drives.Where(d => d.type.is_portable()).ToList();
            if (portable_drives.Count > 0)
            {
                for (var n = 0; n < portable_drives.Count; n++)
                {
                    if (portable_drives[0].is_available())
                    {
                        get_elenco_file(portable_drives[0]);
                    }
                }
                // else Console.WriteLine("First Portable device is not available");
            }
            else
                //Console.WriteLine("No Portable Drives connected"); Console.WriteLine("Enumerating all photos from Camera folder")
                ;
            /*
             * la parte sotto copioa i file su hard disk del pc
             * 
             * 
             * var camera = drive_root.inst.try_parse_folder(pathName);
            if (camera != null)
            {
                foreach (var folder in camera.child_folders)
                {
                    Enumerate_camera_pics_in_folder(folder.full_path);
                }
                Copy_all_camera_photos_to_hdd(pathName);
            }
            else
                Console.WriteLine("No Android Drive Connected");*/
        }
        static void get_elenco_file(IDrive d)
        {
            var files = d.files.ToList();
            foreach (var fileSingolo in files)
            {
                if (!elencoFileSuDispositivo.Contains(fileSingolo.full_path))
                {
                    //bool immagine = FileImmagini.IsImage(@"c:\Users\carlo\Pictures\Camera Roll\IMG_20190815_111258.jpg");
                    elencoFileSuDispositivo.Add(fileSingolo.full_path);
                    fileSingolo.copy_sync(Utility.TempPath);
                }
            }
            /* eseguire solo se non trovate indicazioni nel file su remoto
             * foreach (var child in d.folders)
            {
                get_elenco_file_recursive(child);
            }*/
        }
        /*static void get_elenco_file(IFolder folder)
        {
            if (folder.name.ToUpper() == "CAMERA")
            {
                var files = folder.files.ToList();
                if (files.Count > 0)
                {
                    foreach (var fileSingolo in files)
                    {
                        if (!elencoFileSuDispositivo.Contains(fileSingolo.full_path))
                            elencoFileSuDispositivo.Add(fileSingolo.full_path);
                    }
                }
            }
        }*/
        static void get_elenco_file_recursive(IFolder folder)
        {
            if (folder.name.ToUpper() == "CAMERA")
            {
                //get_elenco_file(folder);
                var files = folder.files.ToList();
                foreach (var fileSingolo in files)
                {
                    if (!elencoFileSuDispositivo.Contains(fileSingolo.full_path))
                    {
                        //if (FileImmagini.IsImage(fileSingolo.full_path))
                        //{
                        elencoFileSuDispositivo.Add(fileSingolo.full_path);
                        fileSingolo.copy_sync(Utility.TempPath);
                        /*if (1 == 1)
                            fileSingolo.delete_sync();*/
                        //FileImmagini.IsImage("c:\\foto\\" + fileSingolo.name);
                        //}
                    }
                }
            }
            foreach (var child in folder.child_folders)
            {
                get_elenco_file_recursive(child);
            }
        }
        public static void Show_all_portable_drives()
        {
            //Console.WriteLine("Enumerating Portable Drives:");
            elencoDispositiviUsb.Clear();
            var portable_drives = drive_root.inst.drives.Where(d => d.type.is_portable()).ToList();
            foreach (var pd in portable_drives)
            {
                var d = drive_root.inst.try_get_drive("[p1]:/");  // ERA p0
                if (d != null && d.is_available())
                {
                    // cancellato da tempo elencoDispositiviUsb.Add(pd.friendly_name);
                    // cancellato 19 7 22 elencoDispositiviUsb.Add(pd);
                    if (!elencoDispositiviUsb.Contains(pd))
                        elencoDispositiviUsb.Add(pd);
                }
                //Console.WriteLine("Drive Unique ID: " + pd.unique_id + ", friendly name=" + pd.friendly_name
                //  + ", type=" + pd.type + ", available=" + pd.is_available());
            }
            if (portable_drives.Count < 1)
                Console.WriteLine("No Portable Drives connected");
        }
        public static void Wait_for_first_connected_device()
        {
            Console.WriteLine("Waiting for you to plug the first portable device");
            while (true)
            {
                var portable_drives = drive_root.inst.drives.Where(d => d.type.is_portable());
                if (portable_drives.Any())
                    break;
            }
            Console.WriteLine("Waiting for you to make the device availble");
            while (true)
            {
                var d = drive_root.inst.try_get_drive("[p0]:/");
                if (d != null && d.is_available())
                    break;
            }
            Show_all_portable_drives();
        }

    }
}
