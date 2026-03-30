Feature: To Verify Temp Manager functionalities

    Background: 
        Given user login to the application with 'default' credential
 
    @regression
    Scenario: Create a temp in UI
        And user navigate to the 'Temps' tab
        And user navigate to 'index2.cfm?action=Temps.Search' page
        And user creates a temp with following details 
          | Field         | Value              |
          | FirstName     | <uniqueString>     |
          | LastName      | <uniqueString>     |
          | Status        | Active             |
          | HomeRegion    | JasonTest          |
          | ContractEE    | EE                 |
          | Certification | RN                 |
          | Specialty     | ER                 |
          | PrimaryEmail  | <uniqueEmail>     |
          | Address       | 16801 Addison Road |
          | City          | Addison            |
          | State         | TX                 |
          | Zip           | 75001              |
    
    @smoke      
    Scenario: Verify newly created temp using getTemp CC method
        And user navigate to the 'Temps' tab
        And user navigate to 'index2.cfm?action=Temps.Search' page
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
        Given user sents 'getTemps' request
          | Field    | Value             |
          | tempIdIn | <scenario_tempid> |
        