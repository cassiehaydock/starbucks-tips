# Tip Distribution Calculator
## Introduction
This is a personal project written in C# to track and calculate the tip distribution specifically for a local Starbucks. This is not meant to be used in commercial settings, and may contain data security issues.
## Contents
### Workers.cs 
Defines the worker object with properties for their name, the amount of tips they received, the hours they worked and if the tips have been distributed.
### DLL.cs (DLL = Doubly Linked List)
Personally defined Doubly Linked List data structure to hold the worker objects. Methods are AddLast(), GetCount(), UpdateHoursAll(), UpdateHoursOne(), Delete(), DisplayAll().
### Program.cs 
Holds main whose purpose is to prompt the user for an integer input that is attached to a specifc action through a case statment. The different cases will call the approite methods from DLL.cs to complete the action.
