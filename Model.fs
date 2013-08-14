namespace Centric.fs.DemoConsoleApp

module Model =
    open System

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

    type SkillLevelType =
    | Unknown = 0
    | Beginner = 1
    | Intermediate = 2
    | Advanced = 3
    | Expert = 4

    type DifficultyType =
    | Unknown = 0
    | Easy = 1
    | Average = 2
    | Difficult = 3
    | Extreme = 4

    type ActivityType =
    | Unknown = 0
    | Delivery = 1
    | PracticeManagement = 2
    | BusinessDevelopment = 3
    | Training = 4
    | Interviews = 5
    | BUMeetings = 6
    | Coaching = 7
    | PersonalDevelopment = 8

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
        Title:string option
        Addresses:Address list option
        PhoneNumbers:PhoneNumber list option
    }

    type Person = {
        Id:Guid
        FirstName:string
        LastName:string
        DemographicInfo:Demographics option
    }

    type Time = {
        Hour:int16
        Minute:int16
        IsAM:bool
    }

    type TimeInterval = {
        StartTime:Time
        EndTime:Time option
        ElapsedTime:decimal option
    }

    type Activity = {
        Id:Guid option
        Type:ActivityType
        Summary:string
        Descripiton:string option
        Date:DateTime
        Times:TimeInterval list
        TotalTime:decimal option
    }

    type Skill = {
        Id:Guid option
        Summary:string
        Description:string option
        SkillLevel:SkillLevelType
    }

     type ProjectInfo = {
        Id:Guid option
        StartDate:DateTime
        EndDate:DateTime option
        Contacts:Person list
        Difficulty:DifficultyType
        Role:string
        Summary:string
        Description:string option
        Activities:Activity list
        UtilizedSkills:Skill list
    }

    type Employee = {
        Id:Guid option
        Info:Person
        Projects:ProjectInfo list
        PracticeManagment:Activity list
        BusinessDevelopment:Activity list
        Skills:Skill list
    }

