Feature: To Verify Temp Manager functionalities

    @wip
    Scenario: Create a temp in UI
        Given user login to the application with 'default' credential
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
    
    @wip      
    Scenario: Verify newly created temp using getTemp CC method
        Given user login to the application with 'default' credential
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
      Then the user verifies the api response which 'tempId' is 'not null'  

  @regression      
  Scenario: Verify subnav links in temp profile
    Given user login to the application with 'testuser_04' credential
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
    Then the user verifies the api response which 'tempId' is 'not null'
    Given the user navigate to above created 'temp' profile    
    Then the user verifies the following subnav link texts are displayed
      | ExpectedText |
      | Info         |
      | Cal          |
      | Journal      |
      | Facilities   |
      | Evals        |
      | Credentials  |
      | Docs         |
      | Taxes        |
      | Pay          |
      | Adjustments  |
      | Reporting    |
      | History      |
      | New          |
      | Avail        |
      
  @regression
  Scenario: Enable Flat Pay and Bill for Temp
    Given user login to the application with 'testuser_05' credential
    And user navigate to the 'Temps' tab
    And the user creates default temp
    And the user enabled the flat pay and bill with following amount
    | Filed    | Value |
    | PayFlat  | 50    |
    | BillFlat | 100   |
    Then the user verifies flat pay bill setting 'Enabled' for temp with following amounts
    | ExpectedAmount |
    |  Pay $50.00    |
    |  Bill $100.00  |