Feature: CLI Version Command
  Validate the real application can run and return version information.

  Scenario: Run version command
    Given the genocs CLI project is available
    When I run the version command
    Then the command should exit with code 0
    And the command output should contain a semantic version
