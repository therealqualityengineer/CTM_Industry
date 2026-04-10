Feature: To Verify Client Manager functionalities

    @wip    
    Scenario: Create a client in UI
        Given user login to the application with 'default' credential
        And user navigate to the 'Clients' tab
        And user creates a client with following details 
          | Field        | Value              |
          | ClientName   | <uniqueString>     |
          | Address      | 16801 Addison Road |
          | City         | Addison            |
          | State        | TX                 |
          | Zip          | 75001              |
          | Status       | Active             |
          | Region       | JasonTest          |
          | QuickbooksId | <uniqueNumber>     |
    
    @smoke
    Scenario: Verify subnav links in client profile
        Given user login to the application with 'testuser_01' credential
        And user navigate to the 'Clients' tab
        And user creates a client with following details 
          | Field        | Value              |
          | ClientName   | <uniqueString>     |
          | Address      | 16801 Addison Road |
          | City         | Addison            |
          | State        | TX                 |
          | Zip          | 75001              |
          | Status       | Active             |
          | Region       | JasonTest          |
          | QuickbooksId | <uniqueNumber>     |
        Given user sents 'getClients' request
          | Field    | Value               |
          | tempIdIn | <scenario_clientid> | 
        Then the user verifies the api response which 'clientId' is 'not null'
        Given the user navigate to above created 'client' profile  
        Then the user verifies the following subnav link texts are displayed
          | ExpectedText             |
          | Info                     |
          | Contacts                 |
          | Notes                    |
          | Calendar                 |
          | Orders                   |
          | Long Term                |
          | Journal                  |
          | Temps                    |
          | Evals                    |
          | Docs                     |
          | Settings                 |
          | Reporting                |
          | Time Entry and Approval  |
          | Facility Portal Settings |
          
    
