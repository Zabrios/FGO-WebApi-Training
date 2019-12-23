using System.Collections.Generic;

namespace FGO.WebApi.Domain.Entities
{
    public class ServantBaseModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string[] Alias { get; set; }
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

    }
}
