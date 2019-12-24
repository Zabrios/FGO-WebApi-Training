using System.Collections.Generic;

namespace FGO.WebApi.Domain.Entities.Models
{
    public class ServantBaseModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<AliasModel> Aliases { get; set; }
        public int Cost { get; set; }
        public string ServantClass { get; set; }
        public int MaxLvl { get; set; }
        public int RarityNum { get; set; }
        public string RarityName { get; set; }
        public int AtkLv1 { get; set; }
        public int AtkMaxLv { get; set; }
        public int AtkLv100 { get; set; }
        public int HpLv1 { get; set; }
        public int HpMaxLv { get; set; }
        public int HpLv100 { get; set; }
        public string CommandCards { get; set; } // will always be ordered Q -> A -> B. Ex: QQAAB
        public ICollection<AscensionModel> Ascensions { get; set; }

    }
}
