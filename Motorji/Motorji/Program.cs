using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

/*
 * Žan Gaberc
 */
namespace Motorji
{
    internal class Program
    {
        class Motor
        {
            private string ime;
            private string znamka;
            private string barva;
            private string model;
            private int maxHitrost;
            private double ccm;
            private double teza;
            private int letnik;

            public string Ime
            {
                get => ime;
                set => ime = value;
            }

            public string Znamka
            {
                get => znamka;
                set => znamka = value;
            }

            public string Barva
            {
                get => barva;
                set => barva = value;
            }

            public string Model
            {
                get => model;
                set => model = value;
            }

            public int MaxHitrost
            {
                get => maxHitrost;
                set => maxHitrost = value;
            }

            public double Ccm
            {
                get => ccm;
                set => ccm = value;
            }

            public double Teza
            {
                get => teza;
                set => teza = value;
            }

            public int Letnik
            {
                get => letnik;
                set => letnik = value;
            }

            public Motor()
            {
            }

            public Motor(string ime, string znamka, string barva, string model, int maxHitrost, double ccm, double teza, int letnik)
            {
                this.ime = ime;
                this.znamka = znamka;
                this.barva = barva;
                this.model = model;
                this.maxHitrost = maxHitrost;
                this.ccm = ccm;
                this.teza = teza;
                this.letnik = letnik;
            }

            public override string ToString()
            {
                return Ime + ", " + Znamka + ", " + Barva + ", " + Model + ", " +
                       MaxHitrost + ", " + Ccm + ", " + Teza + ", " + Letnik;
            }

            public virtual string ToStringFormat()
            {
                return Ime + ";" + Znamka + ";" + Barva + ";" + Model + ";" +
                       MaxHitrost + ";" + Ccm + ";" + Teza + ";" + Letnik;
            }
        }

        class VeckolesniMotor : Motor
        {
            private int steviloDodatnihKoles;

            public int SteviloDodatnihKoles
            {
                get => steviloDodatnihKoles;
                set => steviloDodatnihKoles = value;
            }

            public VeckolesniMotor(string ime, string znamka, string barva, string model, int maxHitrost, double ccm, double teza, int letnik, int steviloDodatnihKoles) : base(ime, znamka, barva, model, maxHitrost, ccm, teza, letnik)
            {
                this.steviloDodatnihKoles = steviloDodatnihKoles;
            }
            
            public override string ToString()
            {
                return base.ToString() + ", " + SteviloDodatnihKoles;
            }
            
            public override string ToStringFormat()
            {
                return base.ToStringFormat() + ";" + SteviloDodatnihKoles;
            }
        }

        class Izvedba
        {
            List<Motor> seznam = new List<Motor>();

            private Motor vpisi()
            {
                string ime = "";
                string znamka = "";
                string barva = "";
                string model = "";
                int maxHitrost = 0;
                double ccm = 0;
                double teza = 0;
                int letnik = 0;
                int steviloDodatnihKoles = 0;
                int steviloKoles = 0;

                while (true)
                {
                    Console.WriteLine("Vpiši ime");
                    ime = Console.ReadLine();

                    if (ime.Length >= 3 && ime.Length < 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ime mora biti dolgo vsaj 3 znake in krajše od 30 znakov.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši znamko");
                    znamka = Console.ReadLine();
                    
                    if (znamka.Length >= 3 && znamka.Length < 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Znamka mora biti dolgo vsaj 3 znake in krajše od 30 znakov.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši barvo");
                    barva = Console.ReadLine();
                    
                    if (barva.Length >= 3 && barva.Length < 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Barva mora biti dolgo vsaj 3 znake in krajše od 30 znakov.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši model");
                    model = Console.ReadLine();
                    
                    if (model.Length >= 3 && model.Length < 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Model mora biti dolgo vsaj 3 znake in krajše od 30 znakov.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši maksimalno hitrost");
                    try
                    {
                        maxHitrost = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (maxHitrost >= 40 && maxHitrost <= 300)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Maksmilana hitrost mora biti večja od 40km/h in manjša od 300km/h.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši ccm");
                    try
                    {
                        ccm = double.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (ccm >= 1000 && ccm <= 2000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ccm mora biti od 1000 do 2000.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši težo");
                    try
                    {
                        teza = double.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (teza >= 10 && teza <= 1000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Teža mora biti od 10kg do 1000kg.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši letnik");
                    try
                    {
                        letnik = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }
                    
                    if ((letnik + "").Length == 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Letnik mora biti sestavljen iz 4 številk.");
                    }
                }
                
                while (true)
                {
                    Console.WriteLine("Vpiši število vseh koles (2 - 4)");
                    try
                    {
                        steviloKoles = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }
                    
                    if (steviloKoles >= 2 && steviloKoles <= 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Število koles mora biti 2 do 4.");
                    }
                }

                steviloDodatnihKoles = steviloKoles - 2;

                
                if (steviloDodatnihKoles == 0)
                {
                    Motor motor = new Motor(ime, znamka, barva, model, maxHitrost, ccm, teza, letnik);
                    return motor;
                }
                else
                {
                    VeckolesniMotor motor = new VeckolesniMotor(ime, znamka, barva, model, maxHitrost, ccm, teza, letnik, steviloDodatnihKoles);
                    return motor;
                }
            }
            
            public void dodajanje()
            {
                Motor motor = vpisi();
                seznam.Add(motor);
            }

            public void spremeni()
            {
                int stevilka = -1;
                
                while (true)
                {
                    Console.WriteLine("Vpiši zaporedno številko motorja: 1 - " + seznam.Count);
                    try
                    {
                        stevilka = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (stevilka < 1 || stevilka > seznam.Count)
                    {
                        Console.WriteLine("Neveljavna številka");
                    }
                    else
                    {
                        Motor motor = vpisi();
                        seznam[stevilka - 1] = motor;

                        break;
                    }
                }
            }
            
            
            public void izbrisi()
            {
                int stevilka = -1;
                
                while (true)
                {
                    Console.WriteLine("Vpiši zaporedno številko motorja: 1 - " + seznam.Count);
                    try
                    {
                        stevilka = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (stevilka < 1 || stevilka > seznam.Count)
                    {
                        Console.WriteLine("Neveljavna številka");
                    }
                    else
                    {
                        seznam.RemoveAt(stevilka - 1);
                        Console.WriteLine("Motor je bil izbrisan");

                        break;
                    }
                }
            }

            public void shrani()
            {
                Console.WriteLine("Vpiši ime datoteke");
                string imeDatoteke = Console.ReadLine();

                string text = "";

                foreach (var motor in seznam)
                {
                    text += motor.ToString() + "\n";
                }

                if (File.Exists(imeDatoteke))
                {
                    Console.WriteLine("Želiš obdržati obstoječe shranjene podatke v datoteki in pripisati nove? (da / ne)");
                    string odgovor = Console.ReadLine();

                    if (odgovor == "da")
                    {
                        try
                        {
                            File.AppendAllText(imeDatoteke, text);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka pri dpiranju/pisanju datoteke");
                        }
                    }
                    else
                    {
                        try {
                            File.WriteAllText(imeDatoteke, text);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka pri dpiranju/pisanju datoteke");
                        }
                    }
                }
                else
                {
                    try {
                        File.WriteAllText(imeDatoteke, text);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri odpiranju/pisanju datoteke");
                    }
                }
            }

            public void nalozi()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Vpiši ime datoteke");
                        string imeDatoteke = Console.ReadLine();

                        string[] vrstice = File.ReadAllLines(imeDatoteke);


                        if (seznam.Count > 0)
                        {
                            Console.WriteLine("Želiš obdržati obstoječe podatke in pripisati nove? (da / ne)");
                            string odgovor = Console.ReadLine();

                            if (odgovor == "da")
                            {

                            }
                            else
                            {
                                seznam.Clear();
                            }
                        }

                        foreach (var vrstica in vrstice)
                        {
                            string[] podatki = vrstica.Split(';');
                            Motor motor = new Motor(podatki[0], podatki[1], podatki[2], podatki[3],
                                int.Parse(podatki[4]), Double.Parse(podatki[5]), Double.Parse(podatki[6]),
                                int.Parse(podatki[7]));
                            seznam.Add(motor);
                        }

                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri odpiranju/branju datoteke");
                    }
                }
            }

            public void izpis()
            {
                string text = "";

                foreach (var motor in seznam)
                {
                    Console.WriteLine(motor.ToString());
                }
            }

            public void izbrisiVse()
            {
                seznam.Clear();
            }
            
            public void steviloObjektov()
            {
                Console.WriteLine("Število objektov je " + seznam.Count);
            }

            public void sortiraj()
            {
                seznam = seznam.OrderBy(element => element.MaxHitrost).ToList();
                Console.WriteLine("Seznam je bil sortiran po hitrosti motorjev.");
            }
            
            public void sortiraj2()
            {
                seznam = seznam.OrderBy(element => element.Letnik).ThenBy(element => element.Ime).ToList();
                Console.WriteLine("Seznam je bil sortiran po letnikih in imenih motorjev.");
            }

            public void serializiraj()
            {
                Console.WriteLine("Vpiši ime datoteke");
                string imeDatoteke = Console.ReadLine();

                string text = "";
                

                if (File.Exists(imeDatoteke))
                {
                    Console.WriteLine("Želiš obdržati obstoječe shranjene podatke v datoteki in pripisati nove? (da / ne)");
                    string odgovor = Console.ReadLine();

                    if (odgovor == "da")
                    {
                        try
                        {
                            List<Motor> motorji = new List<Motor>();
                            using (StreamReader file = File.OpenText(imeDatoteke))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                Motor[] seznam = (Motor[]) serializer.Deserialize(file, typeof(Motor[]));
                                motorji.AddRange(seznam.ToList());
                            }
                            
                            motorji.AddRange(seznam);
                            
                            text = JsonConvert.SerializeObject(motorji);
                            
                            File.WriteAllText(imeDatoteke, text);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka pri dpiranju/pisanju datoteke");
                        }
                    }
                    else
                    {
                        try {
                            text = JsonConvert.SerializeObject(seznam);
                            File.WriteAllText(imeDatoteke, text);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka pri dpiranju/pisanju datoteke");
                        }
                    }
                }
                else
                {
                    try {
                        File.WriteAllText(imeDatoteke, text);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri odpiranju/pisanju datoteke");
                    }
                }
            }

            public void deserializiraj()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Vpiši ime datoteke");
                        string imeDatoteke = Console.ReadLine();

                        List<Motor> motorji = new List<Motor>();
                        using (StreamReader file = File.OpenText(imeDatoteke))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            Motor[] seznam = (Motor[]) serializer.Deserialize(file, typeof(Motor[]));
                            motorji = seznam.ToList();
                        }


                        if (seznam.Count > 0)
                        {
                            Console.WriteLine("Želiš obdržati obstoječe podatke in pripisati nove? (da / ne)");
                            string odgovor = Console.ReadLine();

                            if (odgovor == "da")
                            {
                                // Obstoječe motorje v seznamu ohrani
                            }
                            else
                            {
                                // Obstojče metorje pobriše iz seznama
                                seznam.Clear();
                            }
                        }

                        seznam.AddRange(motorji);

                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri odpiranju/branju datoteke");
                    }
                }
            }
        }
        
        public static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("1 Dodajanje novega objekta");
            str.AppendLine("2 Brisanje izbranega objekta");
            str.AppendLine("3 Spreminjanje izbranega objekta");
            str.AppendLine("4 Shranjevanje objektov v datoteko");
            str.AppendLine("5 Nalaganje objektov iz datoteke v polje objektov");
            str.AppendLine("6 Izbriši vse");
            str.AppendLine("7 Število objektov");
            str.AppendLine("8 Izpis");
            str.AppendLine("9 Sortiranje po hitrosti");
            str.AppendLine("10 Sortiranje po letnikih in imenih");
            str.AppendLine("11 Serializiraj v datoteko");
            str.AppendLine("12 Deserializiraj iz datoteke");

            string meni = str.ToString();
            
            
            Izvedba izvedba = new Izvedba();

            while (true)
            {
                Console.WriteLine(meni);
                Console.WriteLine("Izberi številko iz menija");
                int stevilka = int.Parse(Console.ReadLine());
                
                
                switch (stevilka)
                {
                    case 1:
                    {
                        izvedba.dodajanje();
                        break;
                    }
                    case 2:
                    {
                        izvedba.izbrisi();
                        break;
                    }
                    case 3:
                    {
                        izvedba.spremeni();
                        break;
                    }
                    case 4:
                    {
                        izvedba.shrani();
                        break;
                    }
                    case 5:
                    {
                        izvedba.nalozi();
                        break;
                    }
                    case 6:
                    {
                        izvedba.izbrisiVse();
                        break;
                    }
                    case 7:
                    {
                        izvedba.steviloObjektov();
                        break;
                    }
                    case 8:
                    {
                        izvedba.izpis();
                        break;
                    }
                    case 9:
                    {
                        izvedba.sortiraj();
                        break;
                    }
                    case 10:
                    {
                        izvedba.sortiraj2();
                        break;
                    }
                    case 11:
                    {
                        izvedba.serializiraj();
                        break;
                    }
                    case 12:
                    {
                        izvedba.deserializiraj();
                        break;
                    }
                    default:
                    {
                        return;
                    }
                }
            }
        }
    }
}