Feature: To Verify Order Manager functionalities

    @regression
    Scenario: Create a shift in UI
        Given user login to the application with 'testuser_02' credential
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
          
  @api
  Scenario: Create a shift by clearconnect
    Given user login to the application with 'default' credential
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
    Given user sents 'insertOrder' request
      | Field          | Value               |
      | customerID     | <scenario_clientid> |
      | filledBy       | <scenario_tempid>   |
      | status         | Filled              |
      | nursetype      | RN                  |
      | specialty      | ER                  |
      | jobDateStart   | 2026-03-25          |
      | jobDateEnd     | 2026-03-25          |
      | shiftStartTime | 07:00               |
      | shiftEndTime   | 15:00               |
      | shiftId        | 1                   |
      | orderType      | 1                   |
    Then the user verifies the api response which 'success' is '1'
    Then the user verifies the api response which 'orderid' is 'not null'
    Then the user verifies the api response which 'message' is 'New ord345er record inserted successfully.'
    