namespace Edhutil.Api
{
    public class Card
    {
        public string? AsciiName { get; set; } = null;
        public string BorderColor { get; set; } = string.Empty;
        public string? Defense { get; set; } = null;
        public int? EdhrecRank { get; set; } = null;
        public int? EdhrecSaltiness { get; set; } = null;
        public string? FaceFlavorName { get; set; } = null;
        public double? FaceManaValue { get; set; } = null;
        public string? FaceName { get; set; } = null;
        public string? FlavorName { get; set; } = null;
        public string? FlavorText { get; set; } = null;
        public string? FrameVersion { get; set; } = null;
        public bool HasAlternativeDeckLimit { get; set; } = false;
        public bool HasFoil { get; set; } = false;
        public bool HasNonFoil { get; set; } = false;
        public bool IsAlternative { get; set; } = false;
        public bool IsFullArt { get; set; } = false;
        public bool IsFunny { get; set; } = false;
        public bool IsOnlineOnly { get; set; } = false;
        public bool IsOversized { get; set; } = false;
        public bool IsPromo { get; set; } = false;
        public bool IsRebalanced { get; set; } = false;
        public bool IsReprint { get; set; } = false;
        public bool IsReserved { get; set; }
        public bool IsStorySpotlight { get; set; } = false;
        public bool IsTextless { get; set; } = false;
        public bool IsTimeshifted { get; set; } = false;
        public string Language { get; set; } = string.Empty;
        public string Layout { get; set; } = string.Empty;
        public string? Loyalty { get; set; } = null;
        public string? ManaCost { get; set; } = null;
        public double ManaValue { get; set; } = 0.0;
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string? OriginalReleaseDate { get; set; } = null;
        public string? OriginalText { get; set; } = null;
        public string? OriginalType { get; set; } = null;
        public string? Power { get; set; } = null;
        public string Rarity { get; set; } = string.Empty;
        public string? SecurityStamp { get; set; } = null;
        public string SetCode { get; set; } = string.Empty;
        public string? Side { get; set; } = null;
        public string? Signature { get; set; } = null;
        public string? Text { get; set; } = null;
        public string? Toughness { get; set; } = null;
        public string Type { get; set; } = string.Empty;
        public Guid Uuid { get; set; } = Guid.Empty;
        public string? Watermark { get; set; } = null;
    }
}

