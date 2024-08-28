Feature: HomePage

  As a new user
  I want to sign up for an account
  So that I can access the platform

  Scenario: Successful Sign Up
    Given I am on the Sign Up page
    When I enter the following details:
      | Field            | Value                  |
      | Gender           | Male                   |
      | Email Address    | john.doe@example.com   |
      | Username         | johndoe                |
      | Known As         | John                   |
      | Date Of Birth    | 1990-01-01             |
      | City             | New York               |
      | Country          | USA                    |
      | Password         | 1TestApp                |
      | Confirm Password | 1TestApp             |
    And I submit the sign-up form
    Then I should see a welcome message
