namespace UpSchool.Wasm.Memento
{
    public class Password
    {
        public int Level { get; set; }
        public string BolumAdi { get; set; }


        public override string ToString()
        {
            return $"{Level}. levelın {BolumAdi} bölümündeyiz.";
        }


        //T anında nesneyi tutacak olan metod.
        public PasswordMemento Kaydet()
        {
            return new PasswordMemento
            {
                BolumAdi = this.BolumAdi,
                Level = this.Level
            };
        }

        //T anındaki nesneye bizi ulaşturacak olan metod.
        public void OncekiniYukle(PasswordMemento Memento)
        {
            this.BolumAdi = Memento.BolumAdi;
            this.Level = Memento.Level;

            Console.WriteLine($"Onceki yuklendi {Memento.BolumAdi} {Memento.Level}");
        }
    }
}
