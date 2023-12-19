# ProjectChallenge

## Soil Moisture Calculator System

This is a simple soil moisture calculator system developed in C# (.NET Core). The system determines recommended actions based on the soil type and reported moisture levels.

##How to Run
Prerequisites:

###Make sure you have the .NET Core SDK installed on your machine.

**Clone the Repository:**

bash | Copy code
git clone https://github.com/your-username/soil-moisture-calculator.git
cd soil-moisture-calculator


**Run the Program:**

bash | Copy code
dotnet run

**Follow the instructions in the console to provide the soil type and moisture levels.**

##Available Soil Types
The system currently supports three soil types:

Fine - Clay
Medium - Loamy
Coarse - Sandy
System Messages

The system provides informative messages based on moisture levels and the selected soil type. Messages include irrigation instructions, low or high moisture alerts, and general recommendations.

##Possible Use Cases

The Soil Moisture Calculation System offers various practical applications and can be implemented in different scenarios. Some possible use cases include:

1 - Agricultural Monitoring:

2 - Connected to soil sensors, the system can continuously monitor moisture levels. This is especially useful in agriculture, where optimal moisture conditions are essential for crop growth.
Automated Alerts:

3 - The system can be configured to issue automatic alerts when moisture levels reach critical values. These alerts can be sent via text messages, emails, or other forms of notification.
Integration with Agricultural Machinery:

4 - If connected to tractors or other agricultural machinery, the system can automate irrigation processes based on soil moisture readings, optimizing water usage.
Garden and Landscaping Control:

5 - In residential or commercial settings, the system can be applied to monitor and control garden and landscaping irrigation, ensuring efficient "maaintenance"".
Scientific Research:

6 - Scientists and researchers can use the system to collect data on soil moisture in studies and experiments related to agriculture, ecology, or environmental sciences.


Parameters Table: Ideal Moisture levels (Delmhorst's KS-D1)

## Parameters Table: Ideal Moisture Levels (Delmhorst's KS-D1)

| Soil Type      | No Irrigation Needed | Irrigation to Be Applied | Dangerously Low Soil Moisture | Dangerously Upper Level |
| -------------- | -------------------- | ------------------------ | ----------------------------- | ------------------------ |
| Fine (Clay)    | 80-100               | 60-80                    | Below 60                      | 101-200                  |
| Medium (Loamy) | 88-100               | 70-88                    | Below 70                      | 101-200                  |
| Coarse (Sandy) | 90-100               | 80-90                    | Below 80                      | 101-200                  |

## Equivalence Partitioning Table

| Input: Soil Type   | Input: Moisture Level | Expected Output            |
| ------------------ | ---------------------- | --------------------------- |
| 1 (Fine - Clay)    | 60                     | Low Alert                   |
| 2 (Medium - Loamy) | 90                     | Irrigation Instruction      |
| 3 (Coarse - Sandy) | 110                    | High Alert                  |
| 4 (Invalid Type)   | -10                    | Error: Invalid Moisture Level |
| 5 (Invalid Type)   | 201                    | Error: Invalid Moisture Level |

## Decision Table

| Rule | Soil Type | Moisture Level | Expected Output             |
| ---- | --------- | --------------- | ---------------------------- |
| R1   | 1         | 60              | Low Alert                    |
| R2   | 2         | 90              | Irrigation Instruction       |
| R3   | 3         | 110             | High Alert                   |
| R4   | 4         | -10             | Error: Invalid Moisture Level |
| R5   | 5         | 200             | Error: Invalid Moisture Level |

## TestProject Analysis
Equivalence Partitioning Test Cases:

**Test Case | Soil Type | Moisture Level | Expected Output**
|------------|-----------|-----------------|-------------------------|
| 1          | 1         | 0               | No Irrigation Instruction |
| 2          | 1         | 150             | No Irrigation Instruction |
| 3          | 1         | 151             | Drainage Required Instruction |
| 4          | 2         | 70              | No Irrigation Instruction |
| 5          | 2         | 87              | No Irrigation Instruction |
| 6          | 2         | 88              | Irrigation Instruction |
| 7          | 3         | 80              | No Irrigation Instruction |
| 8          | 3         | 89              | No Irrigation Instruction |
| 9          | 3         | 90              | Irrigation Instruction |
| 10         | 3         | 101             | Drainage Required Instruction |
| 11         | 3         | 200             | Error: Invalid Moisture Level |



##Boundary Value Analysis Test Cases:

**Test Case | Soil Type | Moisture Level | Expected Output**
|------------|-----------|-----------------|-------------------------|
| 1          | 1         | 0               | No Irrigation Instruction |
| 2          | 1         | 150             | No Irrigation Instruction |
| 3          | 1         | 151             | Drainage Required Instruction |
| 4          | 2         | 70              | No Irrigation Instruction |
| 5          | 2         | 87              | No Irrigation Instruction |
| 6          | 2         | 88              | Irrigation Instruction |
| 7          | 3         | 80              | No Irrigation Instruction |
| 8          | 3         | 89              | No Irrigation Instruction |
| 9          | 3         | 90              | Irrigation Instruction |
| 10         | 3         | 101             | Drainage Required Instruction |
| 11         | 3         | 200             | Error: Invalid Moisture Level |

        
##Invalid Test Cases:

**Test Case | Soil Type | Moisture Level | Expected Output**
|------------|-----------|-----------------|-------------------------|
| 1          | 1         | -2              | Error: Invalid Soil Type |
| 2          | 4         | 0               | Error: Invalid Soil Type |
| 3          | 2         | -1              | Error: Invalid Moisture Level |
| 4          | 1         | 201             | Error: Invalid Moisture Level |
| 5          | 3         | 1000            | Error: Invalid Moisture Level |
| 6          | 6         | -0              | Error: Invalid Type |
| 7          | 3         | -1              | Error: Invalid Soil Type |
| 8          | 2         | 99999           | Error: Invalid Moisture Level |
| 9          | 1         | -99999          | Error: Invalid Moisture Level |


**Developer**
Juli


