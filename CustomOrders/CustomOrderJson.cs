namespace CustomOrderJson
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Main
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("orderItemId")]
        public string OrderItemId { get; set; }

        [JsonProperty("legacyOrderItemId")]
        public string LegacyOrderItemId { get; set; }

        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("customizationData")]
        public CustomizationData CustomizationData { get; set; }

        [JsonProperty("version3.0")]
        public Version30 Version30 { get; set; }
    }

    public partial class CustomizationData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("children")]
        public List<CustomizationDataChild> Children { get; set; }
    }

    public partial class CustomizationDataChild
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("children")]
        public List<PurpleChild> Children { get; set; }

        [JsonProperty("baseImage")]
        public Image BaseImage { get; set; }

        [JsonProperty("snapshot")]
        public Snapshot Snapshot { get; set; }

        [JsonProperty("svg")]
        public string Svg { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("dimension")]
        public Dimension Dimension { get; set; }
    }

    public partial class Dimension
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public partial class PurpleChild
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("children")]
        public List<FluffyChild> Children { get; set; }
    }

    public partial class FluffyChild
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("optionSelection", NullValueHandling = NullValueHandling.Ignore)]
        public OptionSelection OptionSelection { get; set; }

        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public List<TentacledChild> Children { get; set; }
    }

    public partial class TentacledChild
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("fontSelection", NullValueHandling = NullValueHandling.Ignore)]
        public FontSelection FontSelection { get; set; }

        [JsonProperty("colorSelection", NullValueHandling = NullValueHandling.Ignore)]
        public ColorSelection ColorSelection { get; set; }

        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public List<StickyChild> Children { get; set; }
    }

    public partial class StickyChild
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("children")]
        public List<IndigoChild> Children { get; set; }

        [JsonProperty("dimension")]
        public Dimension Dimension { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }
    }

    public partial class IndigoChild
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("inputValue")]
        public string InputValue { get; set; }
    }

    public partial class Position
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }

    public partial class ColorSelection
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("colorModel")]
        public string ColorModel { get; set; }
    }

    public partial class FontSelection
    {
        [JsonProperty("family")]
        public string Family { get; set; }
    }

    public partial class OptionSelection
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("additionalCost")]
        public AdditionalCost AdditionalCost { get; set; }

        [JsonProperty("overlayImage")]
        public Image OverlayImage { get; set; }
    }

    public partial class AdditionalCost
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public partial class Snapshot
    {
        [JsonProperty("imageName")]
        public string ImageName { get; set; }

        [JsonProperty("dimension")]
        public Dimension Dimension { get; set; }
    }

    public partial class Version30
    {
        [JsonProperty("customizationInfo")]
        public CustomizationInfo CustomizationInfo { get; set; }
    }

    public partial class CustomizationInfo
    {
        [JsonProperty("surfaces")]
        public List<Surface> Surfaces { get; set; }
    }

    public partial class Surface
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("areas")]
        public List<Area> Areas { get; set; }
    }

    public partial class Area
    {
        [JsonProperty("customizationType")]
        public string CustomizationType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("optionValue", NullValueHandling = NullValueHandling.Ignore)]
        public string OptionValue { get; set; }

        [JsonProperty("priceDelta", NullValueHandling = NullValueHandling.Ignore)]
        public PriceDelta PriceDelta { get; set; }

        [JsonProperty("optionImage", NullValueHandling = NullValueHandling.Ignore)]
        public Uri OptionImage { get; set; }

        [JsonProperty("colorName", NullValueHandling = NullValueHandling.Ignore)]
        public string ColorName { get; set; }

        [JsonProperty("fill", NullValueHandling = NullValueHandling.Ignore)]
        public string Fill { get; set; }

        [JsonProperty("fontFamily", NullValueHandling = NullValueHandling.Ignore)]
        public string FontFamily { get; set; }

        [JsonProperty("Dimensions", NullValueHandling = NullValueHandling.Ignore)]
        public Dimension Dimensions { get; set; }

        [JsonProperty("Position", NullValueHandling = NullValueHandling.Ignore)]
        public Position Position { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }

    public partial class PriceDelta
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
    public partial class Config
    {
        public string SKU { get; set; }
        public string FulfillmentSKU { get; set; }
        public string ImageType { get; set; } // Column C
        public string SourceImage { get; set; } // Column D
        public int Width { get; set; }       // Column E
        public int Height { get; set; }      // Column F
        public int? C1_StartX { get; set; }   // Column G
        public int? C1_StartY { get; set; }   // Column H
        public int? C1_Width { get; set; }    // Column I
        public int? C1_Height { get; set; }  // Coulmn J
        public int? C2_StartX { get; set; }  // Column K
        public int? C2_StartY { get; set; }  // Column L
        public int? C2_Width { get; set; }   // Column M
        public int? C2_Height { get; set; }  // Column N
    }

    public partial class OrderDetail
    {
        public string SKU { get; set; }
        public string internalNotes { get; set; }
        public string orderId { get; set; }
        public string orderItemID { get; set; }
    }
}
