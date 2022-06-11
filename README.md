# Calculator-With-XUnitTests
# Acceptance tests

The calculator is intended to work similar to a regular desktop calculator, so there’s no need to save the history calculations to an external file after termination.  
The application should be responsive and handle invalid inputs from the user, for example:
If the user enters an invalid math-expression (5,x,q+7b), then an error message should be printed saying: “Invalid input!  Please double check and try again”. </br>
The user gets to choose between three alternatives to use the calculator. 

## Alternative A
The user will firstly choose a calculation method (+ - * /), and then will enter two values to get the result printed in the console afterwards. </br>
And at the end the user will be asked to try another calculation or to return to the main menu </br>
### Example: 
* The user gets to choose calculation method  =>  User enters ‘ + ‘
* Enter the first value  => User enters ‘ 5 ’   
* Enter the second value  => User enters ‘ 2 ‘
* Printed message to the user: ‘5 + 2 = 7’
* The program stores the calculation and asks the user to do another calculation or to return 


## Alternative B
It works similar to ‘Alternative A’ except the user can use the calculator by typing in an math-expression.
### Example: 
* The user enters: 7-3+8*9/7
* Printed message to the user: ‘7-3+8*9/7 = 14.28’
* The program stores the calculation and asks the user to do another calculation or to return 


## Alternative C
The user gets to choose a result from the stored calculations to continue work with and then typing a math-expression, so this alternative works very similar to ‘Alternative B’ 
### Example:
* The user get to choose from the history: </br>
[1] 5 + 7 = 12 </br>
[2] 7 - 6 * 2 / 8 = 5.66 </br>
[3] 18 / 5,3 = 3.39 </br>
* User chooses [1]  and types in  +33*8
* Printed message to the user: ‘12+33*8 = 276’
* The program stores the calculation and asks the user to do another calculation or to return 
