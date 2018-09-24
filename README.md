# premex
Premex assignment
Premex Group: FizzBuzz Challenge
All code submitted must be written in C# and committed to a publicly hosted source control system.
=================================[Completed]===================================================
1.	Write a console application that satisfies the following:
For every number between 1 and 100, if the number is a multiple of 3, output the word “Fizz”, if the number is a multiple of 5 output the word “Buzz”, if the number is a multiple of both 3 and 5, output the word “FizzBuzz” and if the number does not meet any of these conditions, output the number itself.
The expected output is as follows:
1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
16
17
Etc…..

=================================[Completed]===================================================
2.	Do the above challenge using a Test Driven Development (TDD) approach. Show how each code path can be tested. You may use any test framework of choice (e.g. MSTest, NUnit)
=================================[Completed]===================================================
3.	Do the above challenge using TDD as per #2 and in addition to TDD apply SOLID development principles (https://en.wikipedia.org/wiki/SOLID).

The FizzBuzz Class          solves one problem (Single Responsibility Principle)
The FizzBuzz Class          implements the interface IFizzBuzz (Open for Extension Not for Modification). 
The FizzBuzz Class          romotes composition over inheritance.
The WebAPI                  uses Dependency Injection and Interface Segregation Principle (IFizzBuzz)
Desgin Patterns             Dispose Design Pattern on FizzBuzz Class

=================================[Completed]===================================================
4.	Do the above challenge using TDD and SOLID and in addition, write a RESTful Web API that can be invoked as follows:

<baseURL>/api/fizzbuzz

This will return a JSON formatted array with values as per challenge number 1 above.

The expected output will be similar to the following:

["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz","16","17","Fizz","19","Buzz","Fizz","22","23","Fizz","Buzz","26","Fizz","28","29","FizzBuzz","31","32","Fizz","34","Buzz","Fizz","37","38","Fizz","Buzz","41","Fizz","43","44","FizzBuzz","46","47","Fizz","49","Buzz","Fizz","52","53","Fizz","Buzz","56","Fizz","58","59","FizzBuzz","61","62","Fizz","64","Buzz","Fizz","67","68","Fizz","Buzz","71","Fizz","73","74","FizzBuzz","76","77","Fizz","79","Buzz","Fizz","82","83","Fizz","Buzz","86","Fizz","88","89","FizzBuzz","91","92","Fizz","94","Buzz","Fizz","97","98","Fizz","Buzz"]

=================================[Completed]===================================================
5.	In addition to the above, provide a solution to the FizzBuzz challenget adopts one or more standard design patterns.
=================================[Completed]===================================================
6.	In addition to #5, using TDD and SOLID, expand the above solution to also provide a RESTful Web API that can be invoked as follows:
<baseURL>/api/fizzbuzz/{id}
where {id} is an integer.
The return value should be a JSON formatted return string based on challenge number 1 above. E.g.
<baseURL>/api/fizzbuzz/3 
should return Fizz
<baseURL>/api/fizzbuzz/15
should return FizzBuzz



