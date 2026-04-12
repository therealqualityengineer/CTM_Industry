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
        
    @regression @20004
    Scenario: Create a Ratesheet 
        Given user login to the application with 'default' credential
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
          | Field      | Value                     |
          | clientName | <uniqueString>            |
          | Address    | 234 Crooked Creek Parkway |
          | City       | Durham                    |
          | State      | NC                        |
          | Zip        | 27713                     |
          | status     | Active                    |
          | regionId   | 1                         |
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
        Given user navigate to 'index2.cfm?action=assignments.search' page
        And the user filter following details in new search box
          | Filter       | Value                |
          | AssignmentId | <scenario_ltorderid> |
        And the user creates default Ratesheet for the selected LTorder
        
    @regression @wip
    Scenario: Create a Ratesheet with Taxable item
        Given user login to the application with 'default' credential
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
          | Field      | Value                     |
          | clientName | <uniqueString>            |
          | Address    | 234 Crooked Creek Parkway |
          | City       | Durham                    |
          | State      | NC                        |
          | Zip        | 27713                     |
          | status     | Active                    |
          | regionId   | 1                         |
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
        Given user navigate to 'index2.cfm?action=assignments.search' page
        And the user filter following details in new search box
          | Filter       | Value                |
          | AssignmentId | <scenario_ltorderid> |
        And the user creates default Ratesheet for the selected LTorder    
        And the user open the '<scenario_ratesheetid>' ratesheet    
        And the user adds the following 'Taxable Item' to the ratesheet
          | Item      | Pay Frequency | Amount | Days per Week | Defer to Date | Prorate / Cap | Hours per Period |
          | Allowance | One-Time      | 5      | N/A           | N/A           | N/A           | 40               |
          | Bonus     | Weekly        | 5      | N/A           | N/A           | N/A           | 36               |
        Then the user saves the ratesheet
  