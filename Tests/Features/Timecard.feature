Feature: To Verify Timecard functionalities
    
@regression @20003
    Scenario: Timecard reconcile 
        Given user login to the application with 'default' credential
        And user sents 'insertTempRecords' request
          | Field         | Value              |
          | firstName     | <uniqueString>     |
          | lastName      | <uniqueString>     |
          | status        | Active             |
          | homeregion    | 1                  |
          | certification | RN                 |
          | specialty     | ER                 |
          | Email         | <uniqueEmail>      |
          | Address       | 16801 Addison Road |
          | City          | Addison            |
          | State         | TX                 |
          | Zip           | 75001              |
        Then the user verifies the api response which 'success' is '1'
        Then the user verifies the api response which 'tempId' is 'not null'
        Given user sents 'insertClients' request
          | Field      | Value              |
          | clientName | <uniqueString>     |
          | Address    | 16801 Addison Road |
          | City       | Addison            |
          | State      | TX                 |
          | Zip        | 75001              |
          | status     | Active             |
          | regionId   | 1                  |
        Then the user verifies the api response which 'success' is '1'
        Then the user verifies the api response which 'clientId' is 'not null'
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
        And the user verifies the api response which 'orderid' is 'not null'
        And the user verifies the api response which 'message' is 'New order record inserted successfully.'      
        Given the user reconciled the '<scenario_orderid>' in staffing timecard popup
        
        