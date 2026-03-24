namespace BusinessManagementSystem.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ServicioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Notas { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public Cliente? Cliente { get; set; }
        public Servicio? Servicio { get; set; }
    }
}