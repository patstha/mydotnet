﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using SalesforceMapper.Salesforce;
//
//    var salesforceContactPreference = SalesforceContactPreference.FromJson(jsonString);

namespace SalesforceMapper.Salesforce;

using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class SalesforceContactPreference
{
    [JsonProperty("@odata.etag", Required = Required.Always)]
    public string OdataEtag { get; set; }

    [JsonProperty("ItemInternalId", Required = Required.Always)]
    public Guid ItemInternalId { get; set; }

    [JsonProperty("CreatedById", Required = Required.Always)]
    public string CreatedById { get; set; }

    [JsonProperty("CreatedDate", Required = Required.Always)]
    public DateTimeOffset CreatedDate { get; set; }

    [JsonProperty("Id", Required = Required.Always)]
    public string Id { get; set; }

    [JsonProperty("IsDeleted", Required = Required.Always)]
    public bool IsDeleted { get; set; }

    [JsonProperty("LastActivityDate", Required = Required.AllowNull)]
    public object LastActivityDate { get; set; }

    [JsonProperty("LastModifiedById", Required = Required.Always)]
    public string LastModifiedById { get; set; }

    [JsonProperty("LastModifiedDate", Required = Required.Always)]
    public DateTimeOffset LastModifiedDate { get; set; }

    [JsonProperty("LastReferencedDate", Required = Required.Always)]
    public DateTimeOffset LastReferencedDate { get; set; }

    [JsonProperty("LastViewedDate", Required = Required.Always)]
    public DateTimeOffset LastViewedDate { get; set; }

    [JsonProperty("Name", Required = Required.Always)]
    public string Name { get; set; }

    [JsonProperty("OwnerId", Required = Required.Always)]
    public string OwnerId { get; set; }

    [JsonProperty("SystemModstamp", Required = Required.Always)]
    public DateTimeOffset SystemModstamp { get; set; }

    [JsonProperty("ContactEmail__c", Required = Required.Always)]
    public string ContactEmailC { get; set; }

    [JsonProperty("Contact__c", Required = Required.Always)]
    public string ContactC { get; set; }

    [JsonProperty("Email_Opt_In__c", Required = Required.Always)]
    public bool EmailOptInC { get; set; }

    [JsonProperty("Email__c", Required = Required.AllowNull)]
    public object EmailC { get; set; }

    [JsonProperty("Frequency__c", Required = Required.AllowNull)]
    public object FrequencyC { get; set; }

    [JsonProperty("IsInternalUpdate__c", Required = Required.Always)]
    public bool IsInternalUpdateC { get; set; }

    [JsonProperty("Personal_Email_Address__c", Required = Required.AllowNull)]
    public object PersonalEmailAddressC { get; set; }

    [JsonProperty("Personal_Mailing_Country__c", Required = Required.AllowNull)]
    public object PersonalMailingCountryC { get; set; }

    [JsonProperty("Personal_Mailing_State__c", Required = Required.AllowNull)]
    public object PersonalMailingStateC { get; set; }

    [JsonProperty("Personal_Mailing_Zip_Code__c", Required = Required.AllowNull)]
    public object PersonalMailingZipCodeC { get; set; }

    [JsonProperty("Personal_Phone_Number__c", Required = Required.Always)]
    public string PersonalPhoneNumberC { get; set; }

    [JsonProperty("SMS_Opt_In__c", Required = Required.Always)]
    public bool SmsOptInC { get; set; }

    [JsonProperty("Topics_of_Interest__c@odata.type", Required = Required.Always)]
    public string TopicsOfInterestCOdataType { get; set; }

    [JsonProperty("Topics_of_Interest__c", Required = Required.Always)]
    public List<string> TopicsOfInterestC { get; set; }

    [JsonProperty("Unsubscribe__c", Required = Required.Always)]
    public bool UnsubscribeC { get; set; }
}

public partial class SalesforceContactPreference
{
    public static SalesforceContactPreference FromJson(string json) => JsonConvert.DeserializeObject<SalesforceContactPreference>(json, SalesforceMapper.Salesforce.Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this SalesforceContactPreference self) => JsonConvert.SerializeObject(self, SalesforceMapper.Salesforce.Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
        {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
    };
}