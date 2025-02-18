namespace MiniTaller.Entidades.Entidades
{
    public class TiposDeTelefono
    {
        public int IdTipoDeTelefono { get; set; }
        public string Tipo { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}