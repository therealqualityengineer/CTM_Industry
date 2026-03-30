Feature: To Verify Client Manager functionalities

    Background: 
        Given user login to the application with 'default' credential
     
    @smoke    
    Scenario: Create a client in UI
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