namespace DesafioLocalizaBdd.Application.Models
{
    /// <summary>
    /// Modelo representacional de um checklist
    /// </summary>
    public class ChecklistModel
    {
        /// <summary>
        /// Está limpo
        /// </summary>
        public bool CarroLimpo { get; set; }
        
        /// <summary>
        /// Tanque está cheio
        /// </summary>
        public bool TanqueCheio { get; set; }
        
        /// <summary>
        /// Possui Amassados
        /// </summary>
        public bool PossuiAmassados { get; set; }
        
        /// <summary>
        /// Possui arranhoes
        /// </summary>
        public bool PossuiArranhoes { get; set; }
    }
}
