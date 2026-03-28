Feature: To Verify Order Manager functionalities

    Background: 
      Given user login to the application with 'default' credential
 
    Scenario: Create a shift in UI
        And user navigate to the 'Temps' tab
        And user creates a temp with following details 
          | Field         | Value              |
          | FirstName     | <uniqueString>     |
          | LastName      | <uniqueString>     |
          | Status        | Active             |
          | HomeRegion    | JasonTest          |
          | ContractEE    | EE                 |
          | Certification | RN                 |
          | Specialty     | ER                 |
          | PrimaryEmail  | <uniqueEmail>      |
          | Address       | 16801 Addison Road |
          | City          | Addison            |
          | State         | TX                 |
          | Zip           | 75001              |
        And user navigate to the 'Clients' tab
        And user creates a client with following details 
          | Field        | Value              |
          | Field        | Value              |
          | ClientName   | <uniqueString>     |
          | Address      | 16801 Addison Road |
          | City         | Addison            |
          | State        | TX                 |
          | Zip          | 75001              |
          | Status       | Active             |
          | Region       | JasonTest          |
          | QuickbooksId | <uniqueNumber>     |
        And user navigate to the 'Orders' tab
        And user creates a order with following details 
          | Field         | Value                    |
          | ClientName    | <scenario_clientname>    |
          | TempName      | <scenario_tempfirstname> |
          | ShiftDate     | 03/25/2026               |
          | ShiftId       | 8D (1)                   |
          | Certification | RN                       |
          | Specialty     | ER                       |