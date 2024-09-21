namespace csharp_patients_management.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }

        public char Sexe { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }
    }
}
