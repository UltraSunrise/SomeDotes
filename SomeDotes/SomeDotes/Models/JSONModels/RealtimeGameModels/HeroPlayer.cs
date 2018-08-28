namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class HeroPlayer
    {
        [JsonProperty("xpos")]
        public long Xpos { get; set; }              
        [JsonProperty("ypos")]
        public long Ypos { get; set; }              
        [JsonProperty("id")]
        public long Id { get; set; }                
        [JsonProperty("name")]
        public string Name { get; set; }            
        [JsonProperty("level")]
        public long Level { get; set; }             
        [JsonProperty("alive")]
        public bool Alive { get; set; }             
        [JsonProperty("respawn_seconds")]
        public long RespawnSeconds { get; set; }    
        [JsonProperty("buyback_cost")]
        public long BuybackCost { get; set; }       
        [JsonProperty("buyback_cooldown")]
        public long BuybackCooldown { get; set; }   
        [JsonProperty("health")]
        public long Health { get; set; }            
        [JsonProperty("max_health")]
        public long MaxHealth { get; set; }         
        [JsonProperty("health_percent")]
        public long HealthPercentage { get; set; }  
        [JsonProperty("mana")]
        public long Mana { get; set; }              
        [JsonProperty("max_mana")]
        public long MaxMana { get; set; }           
        [JsonProperty("mana_percent")]
        public long ManaPercentage { get; set; }    
        [JsonProperty("silenced")]
        public bool Silenced { get; set; }          
        [JsonProperty("stunned")]
        public bool Stunned { get; set; }           
        [JsonProperty("disarmed")]
        public bool Disarmed { get; set; }          
        [JsonProperty("magicimmune")]
        public bool MagicImmune { get; set; }       
        [JsonProperty("hexed")]
        public bool Hexed { get; set; }             
        [JsonProperty("muted")]
        public bool Muted { get; set; }             
        [JsonProperty("break")]
        public bool Break { get; set; }             
        [JsonProperty("smoked")]
        public bool Smoked { get; set; }            
        [JsonProperty("has_debuff")]
        public bool HasDebuff { get; set; }         
        [JsonProperty("selected_unit")]
        public bool SelectedUnit { get; set; }      
        [JsonProperty("talent_1")]
        public bool Talent1 { get; set; }           
        [JsonProperty("talent_2")]
        public bool Talent2 { get; set; }           
        [JsonProperty("talent_3")]
        public bool Talent3 { get; set; }           
        [JsonProperty("talent_4")]
        public bool Talent4 { get; set; }           
        [JsonProperty("talent_5")]
        public bool Talent5 { get; set; }           
        [JsonProperty("talent_6")]
        public bool Talent6 { get; set; }           
        [JsonProperty("talent_7")]
        public bool Talent7 { get; set; }
        [JsonProperty("talent_8")]
        public bool Talent8 { get; set; }
    }
}
