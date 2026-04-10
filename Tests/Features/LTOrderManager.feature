Feature: To Verify LongTerm Order Manager functionalities
    
    @api @20003
    Scenario: Create a Assignment by clearconnect
        Given user sents 'insertTempRecords' request
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
        Given user sents 'insertLTorder' request
          | Field          | Value               |
          | clientid       | <scenario_clientid> |
          | tempId         | <scenario_tempid>   |
          | status         | Filled              |
          | nursetype      | RN                  |
          | specialty      | ER                  |
          | date_start     | 2026-03-25          |
          | date_end       | 2026-03-31          |
          | shiftStartTime | 07:00               |
          | shiftEndTime   | 15:00               |
          | shiftId        | 1                   |
          | orderType      | 1                   |
        Then the user verifies the api response which 'success' is '1'
        Then the user verifies the api response which 'lt_orderId' is 'not null'
        Then the user verifies the api response which 'message' is 'New LT order record inserted successfully.'
        
        