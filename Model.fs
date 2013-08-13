namespace Centric.fs.DemoConsoleApp

module Model =
    open System

    type GenderType =
    | Unknown = 0
    | Male = 1
    | Female = 2
    | Other = 3

    type AddressType =
    | Unknown = 0
    | Home = 1
    | Business = 2
    | Other = 3

    type PhoneType =
    | Unknown = 0
    | Home = 1
    | Work = 2
    | Mobile = 3
    | Other = 4

    type GeographicRegion =
    | State of string
    | Province of string
    | Territory of string
    | County of string

    type PostalCode =
    | FiveDigit of string
    | NineDigit of string
    | AlphaNumeric of string
    | Generic of string

    type Address = {
        Id:Guid option
        Type:AddressType
        Line1:string
        Line2:string option
        Line3:string option
        City:string
        Region:GeographicRegion
        Country:string
        Zip:PostalCode
    }

    type PhoneNumber = {
        Id:Guid option
        CountryCode:string
        AreaCode:string option
        Prefix:string option
        Number:string
        Type:PhoneType
    }

    type Demographics = {
        Id:Guid option
        DateOfBirth:DateTime option
        Gender:GenderType option
        Addresses:Address list option
        PhoneNumbers:PhoneNumber list option
    }

    type Person = {
        Id:Guid
        FirstName:string
        LastName:string
        DemographicInfo:Demographics option
    }

    type ProjectInfo = {
        Id:Guid option
        StartDate:DateTime
        EndDate:DateTime option
        Contact:Person option
    }

    type Employee = {
        Id:Guid
        Info:Person
        Projects:ProjectInfo list
    }

