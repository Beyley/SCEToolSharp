using SCEToolSharp;

const string eboot = "/home/jvyden/.config/rpcs3/dev_hdd0/game/NPUA80543/USRDIR/EBOOT.BIN";

LibSceToolSharp.SetRapDirectory("/home/jvyden/.config/rpcs3/dev_hdd0/home/00000001/exdata/");
LibSceToolSharp.PrintInfos(eboot);
LibSceToolSharp.Decrypt(eboot, "/tmp/EBOOT.ELF");