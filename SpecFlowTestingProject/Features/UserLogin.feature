Feature: Login functionality
  As a user of My Hot Rave
  I want to be able to log in using my username and password
  So that I can access the application

  Scenario: Successful login with valid credentials
    Given I am on the My Hot Rave login page
    When I enter a valid username and passord field
    | Field    | Value                   |
    | Username | t10o6gri9g@hotterrt.com |
    | Password | 1TestApp                |
    And I click on the "Login" button
    Then I should be redirected to the homepage

