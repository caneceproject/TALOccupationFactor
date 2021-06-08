# TALOccupationFactor
Simple form that accepts some details and calculates occupation factor rate


## Overview

Screen 1. Personal Data UI 
- Contains fields to enter Name, Date of birth 
- **Next** button that navigates to screen 2 upon validation

Screen 2. Calculate Data UI
- Contains fields to enter Occupation, Sum Insured, Monthly Expenses, State, Post code
- **Previous** button to navigate to last screen (screen 1) and retain all values
- **Calculate** button to calculate Total Value with the following formula

  **Total Value  = (Sum Insured * Occupation Rating Factor) /(100 * 12 * Age)**
- Show Total value

## Assumption
- All fields are required even though some fields are not used by the calculation
- Age is determined by the date of birth to reduce repetitive data entry and prevent clashing in data

The below components are not covered:
- Authentication
- Logging
- Data storage
- Unit tests

## Technologies

| Dependency | Version
| :--- | ---:
| .NET Framework | 4.7.2
| ASP.NET MVC | 5.2.7

## Design Patterns

Model-View-ViewModel  

## Getting Started

1. Download or clone this repository.
2. Open the solution in Visual Studio 2019
3. Select the **TALOccupationFactor** project.
4. Run the project or publish the project for deployment
