namespace OrderDetail
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public class BillTo
    {
        public string name { get; set; }
        public object company { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public object street3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public object phone { get; set; }
        public object residential { get; set; }
        public object addressVerified { get; set; }
    }

    public class ShipTo
    {
        public string name { get; set; }
        public string company { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string street3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public bool residential { get; set; }
        public string addressVerified { get; set; }
    }

    public class Weight
    {
        public double value { get; set; }
        public string units { get; set; }
        public int WeightUnits { get; set; }
    }

    public class Option
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Item
    {
        public int orderItemId { get; set; }
        public string lineItemKey { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public Weight weight { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public double? taxAmount { get; set; }
        public double? shippingAmount { get; set; }
        public string warehouseLocation { get; set; }
        public IList<Option> options { get; set; }
        public int? productId { get; set; }
        public string fulfillmentSku { get; set; }
        public bool adjustment { get; set; }
        public string upc { get; set; }
        public DateTime createDate { get; set; }
        public DateTime modifyDate { get; set; }
    }

    public class InsuranceOptions
    {
        public object provider { get; set; }
        public bool insureShipment { get; set; }
        public double insuredValue { get; set; }
    }

    public class InternationalOptions
    {
        public object contents { get; set; }
        public object customsItems { get; set; }
        public object nonDelivery { get; set; }
    }

    public class AdvancedOptions
    {
        public int? warehouseId { get; set; }
        public bool nonMachinable { get; set; }
        public bool saturdayDelivery { get; set; }
        public bool containsAlcohol { get; set; }
        public bool mergedOrSplit { get; set; }
        public IList<object> mergedIds { get; set; }
        public object parentId { get; set; }
        public int storeId { get; set; }
        public object customField1 { get; set; }
        public object customField2 { get; set; }
        public object customField3 { get; set; }
        public string source { get; set; }
        public object billToParty { get; set; }
        public object billToAccount { get; set; }
        public object billToPostalCode { get; set; }
        public object billToCountryCode { get; set; }
        public object billToMyOtherAccount { get; set; }
    }

    public class Order
    {
        public int orderId { get; set; }
        public string orderNumber { get; set; }
        public string orderKey { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime createDate { get; set; }
        public DateTime modifyDate { get; set; }
        public DateTime? paymentDate { get; set; }
        public DateTime? shipByDate { get; set; }
        public string orderStatus { get; set; }
        public int? customerId { get; set; }
        public string customerUsername { get; set; }
        public string customerEmail { get; set; }
        public BillTo billTo { get; set; }
        public ShipTo shipTo { get; set; }
        public IList<Item> items { get; set; }
        public double orderTotal { get; set; }
        public double amountPaid { get; set; }
        public double taxAmount { get; set; }
        public double shippingAmount { get; set; }
        public string customerNotes { get; set; }
        public string internalNotes { get; set; }
        public bool gift { get; set; }
        public object giftMessage { get; set; }
        public string paymentMethod { get; set; }
        public string requestedShippingService { get; set; }
        public string carrierCode { get; set; }
        public string serviceCode { get; set; }
        public string packageCode { get; set; }
        public string confirmation { get; set; }
        public string shipDate { get; set; }
        public object holdUntilDate { get; set; }
        public Weight weight { get; set; }
        public object dimensions { get; set; }
        public InsuranceOptions insuranceOptions { get; set; }
        public InternationalOptions internationalOptions { get; set; }
        public AdvancedOptions advancedOptions { get; set; }
        public object tagIds { get; set; }
        public object userId { get; set; }
        public bool externallyFulfilled { get; set; }
        public string externallyFulfilledBy { get; set; }
        public object labelMessages { get; set; }
    }

    public class OrderDetail
    {
        public IList<Order> orders { get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
    }

}