namespace Edhutil.Models
{
    public class Card
    {
        public static readonly Card Empty = new();

        public string? Ascii_name { get; set; } = null;
        public string Border_color { get; set; } = string.Empty;
        public string? Defense { get; set; } = null;
        public int? Edhrec_rank { get; set; } = null;
        public int? Edhrec_saltiness { get; set; } = null;
        public string? Face_flavor_name { get; set; } = null;
        public double? Face_mana_value { get; set; } = null;
        public string? Face_name { get; set; } = null;
        public string? Flavor_name { get; set; } = null;
        public string? Flavor_text { get; set; } = null;
        public string Frame_version { get; set; } = string.Empty;
        public bool Has_alternative_deck_limit { get; set; } = false;
        public bool Has_foil { get; set; } = false;
        public bool Has_non_foil { get; set; } = false;
        public bool Is_alternative { get; set; } = false;
        public bool Is_full_art { get; set; } = false;
        public bool Is_funny { get; set; } = false;
        public bool Is_online_only { get; set; } = false;
        public bool Is_oversized { get; set; } = false;
        public bool Is_promo { get; set; } = false;
        public bool Is_rebalanced { get; set; } = false;
        public bool Is_reprint { get; set; } = false;
        public bool Is_reserved { get; set; }
        public bool Is_storySpotlight { get; set; } = false;
        public bool Is_textless { get; set; } = false;
        public bool Is_timeshifted { get; set; } = false;
        public string Language { get; set; } = string.Empty;
        public string Layout { get; set; } = string.Empty;
        public string? Loyalty { get; set; } = null;
        public string? Mana_cost { get; set; } = null;
        public double Mana_value { get; set; } = 0.0;
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string? Original_release_date { get; set; } = null;
        public string? Original_text { get; set; } = null;
        public string? Original_type { get; set; } = null;
        public string? Power { get; set; } = null;
        public string Rarity { get; set; } = string.Empty;
        public Guid Scryfall_id { get; set; } = Guid.Empty;
        public string? Security_stamp { get; set; } = null;
        public string Set_code { get; set; } = string.Empty;
        public string? Side { get; set; } = null;
        public string? Signature { get; set; } = null;
        public string? Text { get; set; } = null;
        public string? Toughness { get; set; } = null;
        public string Type { get; set; } = string.Empty;
        public Guid Uuid { get; set; } = Guid.Empty;
        public string? Watermark { get; set; } = null;
    }
}

